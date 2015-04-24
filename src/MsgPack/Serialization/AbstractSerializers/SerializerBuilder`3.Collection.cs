﻿#region -- License Terms --
//
// MessagePack for CLI
//
// Copyright (C) 2015 FUJIWARA, Yusuke
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//
#endregion -- License Terms --

using System;
using System.Collections.Generic;
using System.Linq;
#if !UNITY
using System.Diagnostics.Contracts;
#endif // !UNITY
using System.Reflection;

using MsgPack.Serialization.CollectionSerializers;

namespace MsgPack.Serialization.AbstractSerializers
{
	[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "Well patterned" )]
	partial class SerializerBuilder<TContext, TConstruct, TObject>
	{
		private void BuildCollectionSerializer(
			TContext context,
			Type concreteType,
			PolymorphismSchema schema
		)
		{
#if DEBUG && !UNITY
			Contract.Assert( CollectionTraitsOfThis.DetailedCollectionType != CollectionDetailedKind.Array );
#endif // DEBUG
			bool isUnpackFromRequired;
			Type declaringType;
			DetermineSerializationStrategy( out isUnpackFromRequired, out declaringType );

			if ( isUnpackFromRequired && CollectionTraitsOfThis.AddMethod != null )
			{
				this.BuildCollectionAddItem( context, declaringType );
			}

			if ( isUnpackFromRequired )
			{
				this.BuildCollectionUnpackFromCore( context, concreteType, schema );
			}

			this.BuildCollectionCreateInstance( context, concreteType, declaringType );

			this.BuildRestoreSchema( context, schema );
		}

		private static void DetermineSerializationStrategy( out bool isUnpackFromRequired, out Type declaringType )
		{
			switch ( CollectionTraitsOfThis.DetailedCollectionType )
			{
				case CollectionDetailedKind.NonGenericEnumerable:
				case CollectionDetailedKind.NonGenericCollection:
				{
					isUnpackFromRequired = true;
					declaringType =
						typeof( NonGenericEnumerableMessagePackSerializerBase<> ).MakeGenericType(
							typeof( TObject )
						);
					break;
				}
				case CollectionDetailedKind.NonGenericList:
				{
					isUnpackFromRequired = false;
					declaringType =
						typeof( NonGenericEnumerableMessagePackSerializerBase<> ).MakeGenericType(
							typeof( TObject )
						);
					break;
				}
				case CollectionDetailedKind.NonGenericDictionary:
				{
					isUnpackFromRequired = false;
					declaringType =
						typeof( NonGenericDictionaryMessagePackSerializer<> ).MakeGenericType(
							typeof( TObject )
						);
					break;
				}
				case CollectionDetailedKind.GenericEnumerable:
				{
					isUnpackFromRequired = true;
					declaringType =
						typeof( EnumerableMessagePackSerializerBase<,> ).MakeGenericType(
							typeof( TObject ),
							CollectionTraitsOfThis.ElementType
						);
					break;
				}
				case CollectionDetailedKind.GenericDictionary:
				{
					isUnpackFromRequired = false;
					var keyValurPairGenericArguments = CollectionTraitsOfThis.ElementType.GetGenericArguments();
					declaringType =
						typeof( DictionaryMessagePackSerializer<,,> ).MakeGenericType(
							typeof( TObject ),
							keyValurPairGenericArguments[ 0 ],
							keyValurPairGenericArguments[ 1 ]
						);
					break;
				}
				default:
				{
					isUnpackFromRequired = false;
					declaringType =
						typeof( EnumerableMessagePackSerializerBase<,> ).MakeGenericType(
							typeof( TObject ),
							CollectionTraitsOfThis.ElementType
						);
					break;
				}
			} // switch
		}

		private void BuildCollectionAddItem( TContext context, Type declaringType )
		{
			var addItem = GetCollectionSerializerMethod( "AddItem", declaringType );
			this.EmitMethodPrologue( context, CollectionSerializerMethod.AddItem, addItem );
			TConstruct construct = null;
			try
			{
				construct =
					this.EmitAppendCollectionItem(
						context,
						null,
						CollectionTraitsOfThis,
						context.CollectionToBeAdded,
						context.ItemToAdd
					);
			}
			finally
			{
				this.EmitMethodEpilogue( context, CollectionSerializerMethod.AddItem, construct );
			}
		}

		private void BuildCollectionUnpackFromCore( TContext context, Type concreteType, PolymorphismSchema schema )
		{
			this.EmitMethodPrologue( context, SerializerMethod.UnpackFromCore );

			TConstruct construct = null;
			try
			{
				var instanceType = concreteType ?? typeof( TObject );
				var collection =
					this.DeclareLocal(
						context,
						instanceType,
						"collection"
					);
				construct =
					this.EmitSequentialStatements(
						context,
						collection.ContextType,
						this.EmitCollectionUnpackFromStatements( context, instanceType, schema, collection )
					);
			}
			finally
			{
				this.EmitMethodEpilogue( context, SerializerMethod.UnpackFromCore, construct );
			}
		}

		private IEnumerable<TConstruct> EmitCollectionUnpackFromStatements( TContext context, Type instanceType, PolymorphismSchema schema, TConstruct collection )
		{
			/*
			 * #if ARRAY
			 *	if (!unpacker.IsArrayHeader)
			 * #else
			 *	if (!unpacker.IsMapHeader)
			 * #endif
			 *	{
			 *		throw SerializationExceptions.NewIsNotArrayHeader();
			 *	}
			 *	int capacity = ITEMS_COUNT(unpacker);
			 *	TCollection collection = new ...;
			 * #if HAS_ADD_IN_TYPE
			 *	this.UnpackToCore(unpacker, array);
			 * #else // Add only exists in concrete type
			 *  UNPACK_TO_SPECIFIED_COLLECTION
			 * #endif
			 *	return collection;
			 */
			var ctor = GetCollectionConstructor( instanceType );

			yield return
				CollectionTraitsOfThis.CollectionType == CollectionKind.Array
					? this.EmitCheckIsArrayHeaderExpression( context, context.Unpacker )
					: this.EmitCheckIsMapHeaderExpression( context, context.Unpacker );

			var itemsCount = this.DeclareLocal( context, typeof( int ), "itemsCount" );

			yield return itemsCount;
			yield return
				this.EmitStoreVariableStatement(
					context, 
					itemsCount,
					this.EmitGetItemsCountExpression( context, context.Unpacker )
				);
			yield return collection;

			if ( CollectionTraitsOfThis.CollectionType == CollectionKind.Array && CollectionTraitsOfThis.AddMethod == null )
			{
				// deserialize with concrete collection's UnpackTo.
				yield return
					this.EmitStoreVariableStatement(
						context,
						collection,
						this.EmitCreateNewObjectExpression(
							context,
							collection,
							ctor,
							ctor.GetParameters().Length == 0
								? NoConstructs
								: new[] { itemsCount }
						)
					);

				yield return
					this.EmitForLoop(
						context,
						itemsCount,
						flc =>
							this.EmitUnpackToCollectionLoopBody(
								context,
								flc,
								instanceType.GetCollectionTraits(),
								context.Unpacker,
								collection,
								( schema ?? PolymorphismSchema.Default ).ItemSchema
							)
					);
			}
			else
			{
				// use generated AddItem override.
				yield return
					this.EmitUnpackCollectionWithUnpackToExpression(
						context,
						ctor,
						itemsCount,
						context.Unpacker,
						collection
					);
			}

			yield return
				this.EmitRetrunStatement(
					context,
					this.EmitLoadVariableExpression( context, collection )
				);
		}

		private void BuildCollectionCreateInstance( TContext context, Type concreteType, Type declaringType )
		{
			var createInstance = GetCollectionSerializerMethod( "CreateInstance", declaringType );
			this.EmitMethodPrologue( context, CollectionSerializerMethod.CreateInstance, createInstance );
			TConstruct construct = null;
			try
			{
				var instanceType = concreteType ?? typeof( TObject );
				var collection =
					this.DeclareLocal(
						context,
						typeof( TObject ),
						"collection"
					);
				var ctor = GetCollectionConstructor( instanceType );
				construct =
					this.EmitSequentialStatements(
						context,
						typeof( TObject ),
						collection,
						this.EmitRetrunStatement(
							context,
							this.EmitCreateNewObjectExpression(
								context,
								collection,
								ctor,
							ctor.GetParameters().Length == 0
								? NoConstructs
								: new[] { context.InitialCapacity }
							)
						)
					);
			}
			finally
			{
				this.EmitMethodEpilogue( context, CollectionSerializerMethod.CreateInstance, construct );
			}
		}

		private void BuildRestoreSchema( TContext context, PolymorphismSchema schema )
		{
			this.EmitMethodPrologue( context, CollectionSerializerMethod.RestoreSchema, null );
			TConstruct construct = null;
			try
			{
				var storage =
					this.DeclareLocal(
						context,
						typeof( PolymorphismSchema ),
						"schema"
					);
				construct =
					this.EmitSequentialStatements(
						context,
						typeof( PolymorphismSchema ),
						new [] { storage }
						.Concat( this.EmitConstructPolymorphismSchema( context, storage, schema ) )
						.Concat( new[] { this.EmitRetrunStatement( context, this.EmitLoadVariableExpression( context, storage ) ) } )
					);
			}
			finally
			{
				this.EmitMethodEpilogue( context, CollectionSerializerMethod.RestoreSchema, construct );
			}
		}


		private static MethodInfo GetCollectionSerializerMethod( string name, Type declaringType )
		{
#if !NETFX_CORE
			return declaringType.GetMethod( name, BindingFlags.NonPublic | BindingFlags.Instance );
#else
			return declaringType.GetRuntimeMethods().Single( m => m.Name == name );
#endif
		}

		private TConstruct EmitPutArrayHeaderExpression( TContext context, TConstruct length )
		{
			return
				this.EmitInvokeVoidMethod( context, context.Packer, Metadata._Packer.PackArrayHeader, length );
		}

		private TConstruct EmitPutMapHeaderExpression( TContext context, TConstruct collectionCount )
		{
			return
				this.EmitInvokeVoidMethod( context, context.Packer, Metadata._Packer.PackMapHeader, collectionCount );
		}

		private TConstruct EmitCheckIsArrayHeaderExpression( TContext context, TConstruct unpacker )
		{
			return
				this.EmitConditionalExpression(
					context,
					this.EmitNotExpression(
						context,
						this.EmitGetPropertyExpression( context, unpacker, Metadata._Unpacker.IsArrayHeader )
					),
					this.EmitThrowExpression(
						context,
						typeof( Unpacker ),
						SerializationExceptions.NewIsNotArrayHeaderMethod
					),
					null
				);
		}

		private TConstruct EmitCheckIsMapHeaderExpression( TContext context, TConstruct unpacker )
		{
			return
				this.EmitConditionalExpression(
					context,
					this.EmitNotExpression(
						context,
						this.EmitGetPropertyExpression( context, unpacker, Metadata._Unpacker.IsMapHeader )
					),
					this.EmitThrowExpression(
						context,
						typeof( Unpacker ),
						SerializationExceptions.NewIsNotMapHeaderMethod
					),
					null
				);
		}

		private TConstruct EmitUnpackToCollectionLoopBody( TContext context, ForLoopContext forLoopContext, CollectionTraits traitsOfTheCollection, TConstruct unpacker, TConstruct collection, PolymorphismSchema itemsSchema )
		{
			/*
			    if ( !unpacker.Read() )
				{
					throw SerializationExceptions.NewMissingItem( i );
				}

				T item;
				if ( !unpacker.IsArrayHeader && !unpacker.IsMapHeader )
				{
					item = serializer.UnpackFrom( unpacker );
				}
				else
				{
					using ( Unpacker subtreeUnpacker = unpacker.ReadSubtree() )
					{
						item = serializer.UnpackFrom( subtreeUnpacker );
					}
				}

				addition( item );
			 */

			return
				this.EmitUnpackItemValueExpression(
					context,
					traitsOfTheCollection.ElementType,
					context.CollectionItemNilImplication,
					unpacker,
					forLoopContext.Counter,
					this.EmitInvariantStringFormat( context, "item{0}", forLoopContext.Counter ),
					null,
					null,
					null,
					itemsSchema,
					unpackedItem =>
						this.EmitAppendCollectionItem(
							context,
							null,
							traitsOfTheCollection,
							collection,
							unpackedItem
						)
				);
		}
	}
}