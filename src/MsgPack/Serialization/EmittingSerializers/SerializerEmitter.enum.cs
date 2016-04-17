#region -- License Terms --
//
// MessagePack for CLI
//
// Copyright (C) 2014-2016 FUJIWARA, Yusuke
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
using System.Diagnostics.Contracts;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;

using MsgPack.Serialization.AbstractSerializers;
using MsgPack.Serialization.Reflection;

namespace MsgPack.Serialization.EmittingSerializers
{
	partial class SerializerEmitter
	{
		private static readonly Type[] ContextConstructorParameterTypes = { typeof( SerializationContext ) };
		private static readonly Type[] ContextAndEnumSerializationMethodConstructorParameterTypes =
				{ typeof( SerializationContext ), typeof( EnumSerializationMethod ) };
		private readonly EnumSerializationMethod _defaultEnumSerializationMethod;

		/// <summary>
		///		Initializes a new instance of the <see cref="SerializerEmitter"/> class for enum.
		/// </summary>
		/// <param name="context">A <see cref="SerializationContext"/>.</param>
		/// <param name="host">The host <see cref="ModuleBuilder"/>.</param>
		/// <param name="specification">The specification of the serializer.</param>
		/// <param name="isDebuggable">Set to <c>true</c> when <paramref name="host"/> is debuggable.</param>
		public SerializerEmitter( SerializationContext context, ModuleBuilder host, SerializerSpecification specification, bool isDebuggable )
			: this( host, specification, typeof( EnumMessagePackSerializer<> ).MakeGenericType( specification.TargetType ), isDebuggable )
		{
			Tracer.Emit.TraceEvent( Tracer.EventType.DefineType, Tracer.EventId.DefineType, "Create {0}", specification.SerializerTypeFullName );

			this._defaultEnumSerializationMethod = context.EnumSerializationMethod;
		}

		/// <summary>
		///		Creates the serializer type built now and returns its new instance.
		/// </summary>
		/// <param name="context">The <see cref="SerializationContext"/> to holds serializers.</param>
		/// <param name="targetType">Target type to be serialized/deserialized.</param>
		/// <param name="serializationMethod">The <see cref="EnumSerializationMethod"/> which determines serialization form of the enums.</param>
		/// <returns>
		///		Newly built <see cref="MessagePackSerializer{T}"/> instance.
		///		This value will not be <c>null</c>.
		///	</returns>
		public MessagePackSerializer CreateEnumInstance( SerializationContext context, Type targetType, EnumSerializationMethod serializationMethod )
		{
			return this.CreateEnumConstructor( targetType )( context, serializationMethod );
		}

		/// <summary>
		///		Creates instance constructor delegates.
		/// </summary>
		/// <param name="targetType">Target type to be serialized/deserialized.</param>
		/// <returns>A delegate for serializer constructor.</returns>
		public Func<SerializationContext, EnumSerializationMethod, MessagePackSerializer> CreateEnumConstructor( Type targetType )
		{
			var methodConstructor =
				this.CreateConstructor(
					MethodAttributes.Public,
					ContextAndEnumSerializationMethodConstructorParameterTypes,
					this.EmitMethodEnumConstructor
				);
			this.CreateConstructor(
				MethodAttributes.Public,
				ContextConstructorParameterTypes,
				( _, il ) => this.EmitDefaultEnumConstructor( methodConstructor, il )
			);
			var ctor = 
				this._typeBuilder
#if !NETSTD_11 && !NETSTD_13
				.CreateType()
#else
				.CreateTypeInfo().AsType()
#endif // !NETSTD_11 && !NETSTD_13
				.GetRuntimeConstructor( ContextAndEnumSerializationMethodConstructorParameterTypes );
			var contextParameter = Expression.Parameter( typeof( SerializationContext ), "context" );
			var methodParameter = Expression.Parameter( typeof( EnumSerializationMethod ), "method" );
#if DEBUG
			Contract.Assert( ctor != null, "ctor != null" );
#endif
			return
				Expression.Lambda<Func<SerializationContext, EnumSerializationMethod, MessagePackSerializer>>(
					Expression.New(
						ctor,
						contextParameter,
						methodParameter
					),
					contextParameter,
					methodParameter
				).Compile();
		}

		private void EmitDefaultEnumConstructor( ConstructorBuilder methodConstructor, TracingILGenerator il )
		{
			/*
			 *	.ctor( SerializationContext c ) 
			 *	  : this( c, DEFAULT_METHOD )
			 *	{
			 *	}
			 */
			// : this( c, DEFAULT_METHOD )
			il.EmitLdarg_0();
			il.EmitLdarg_1();
			il.EmitAnyLdc_I4( ( int )this._defaultEnumSerializationMethod );

			il.EmitCallConstructor( methodConstructor );

			il.EmitRet();
		}

		private void EmitMethodEnumConstructor( Type baseType, TracingILGenerator il )
		{
			/*
			 *	.ctor( SerializationContext c, EnumSerializerMethod method ) 
			 *	  : base( c, method )
			 *	{
			 *	}
			 */
			// : base( c, method )
			il.EmitLdarg_0();
			il.EmitLdarg_1();
			il.EmitLdarg_2();

			il.EmitCallConstructor(
				baseType.GetRuntimeConstructor( ContextAndEnumSerializationMethodConstructorParameterTypes )
			);

			il.EmitRet();
		}
	}
}