﻿//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MsgPack.Serialization.GeneratedSerializers {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("MsgPack.Serialization.CodeDomSerializers.CodeDomSerializerBuilder", "0.7.0.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    public class MsgPack_Serialization_PlainClassSerializer : MsgPack.Serialization.MessagePackSerializer<MsgPack.Serialization.PlainClass> {
        
        private MsgPack.Serialization.MessagePackSerializer<System.Collections.Generic.List<int>> _serializer0;
        
        private System.Action<MsgPack.Packer, MsgPack.Serialization.PlainClass> this_PackValueOfCollectionReadOnlyPropertyDelegate;
        
        private MsgPack.Serialization.MessagePackSerializer<int> _serializer1;
        
        private System.Action<MsgPack.Packer, MsgPack.Serialization.PlainClass> this_PackValueOfPublicFieldDelegate;
        
        private System.Action<MsgPack.Packer, MsgPack.Serialization.PlainClass> this_PackValueOfPublicPropertyDelegate;
        
        private System.Collections.Generic.IList<System.Action<MsgPack.Packer, MsgPack.Serialization.PlainClass>> _packOperationList;
        
        private System.Collections.Generic.IDictionary<string, System.Action<MsgPack.Packer, MsgPack.Serialization.PlainClass>> _packOperationTable;
        
        private System.Func<MsgPack.Packer, MsgPack.Serialization.PlainClass, System.Threading.CancellationToken, System.Threading.Tasks.Task> this_PackValueOfCollectionReadOnlyPropertyAsyncDelegate;
        
        private System.Func<MsgPack.Packer, MsgPack.Serialization.PlainClass, System.Threading.CancellationToken, System.Threading.Tasks.Task> this_PackValueOfPublicFieldAsyncDelegate;
        
        private System.Func<MsgPack.Packer, MsgPack.Serialization.PlainClass, System.Threading.CancellationToken, System.Threading.Tasks.Task> this_PackValueOfPublicPropertyAsyncDelegate;
        
        private System.Collections.Generic.IList<System.Func<MsgPack.Packer, MsgPack.Serialization.PlainClass, System.Threading.CancellationToken, System.Threading.Tasks.Task>> _packOperationListAsync;
        
        private System.Collections.Generic.IDictionary<string, System.Func<MsgPack.Packer, MsgPack.Serialization.PlainClass, System.Threading.CancellationToken, System.Threading.Tasks.Task>> _packOperationTableAsync;
        
        private System.Action<MsgPack.Serialization.PlainClass, System.Collections.Generic.List<int>> this_SetUnpackedValueOfCollectionReadOnlyPropertyDelegate;
        
        private System.Action<MsgPack.Unpacker, MsgPack.Serialization.PlainClass, int, int> this_UnpackValueOfCollectionReadOnlyPropertyDelegate;
        
        private System.Action<MsgPack.Serialization.PlainClass, int> this_SetUnpackedValueOfPublicFieldDelegate;
        
        private System.Func<MsgPack.Unpacker, System.Type, string, int> MsgPack_Serialization_UnpackHelpers_UnpackInt32ValueDelegate;
        
        private System.Action<MsgPack.Unpacker, MsgPack.Serialization.PlainClass, int, int> this_UnpackValueOfPublicFieldDelegate;
        
        private System.Action<MsgPack.Serialization.PlainClass, int> this_SetUnpackedValueOfPublicPropertyDelegate;
        
        private System.Action<MsgPack.Unpacker, MsgPack.Serialization.PlainClass, int, int> this_UnpackValueOfPublicPropertyDelegate;
        
        private System.Collections.Generic.IList<string> _memberNames;
        
        private System.Collections.Generic.IList<System.Action<MsgPack.Unpacker, MsgPack.Serialization.PlainClass, int, int>> _unpackOperationList;
        
        private System.Collections.Generic.IDictionary<string, System.Action<MsgPack.Unpacker, MsgPack.Serialization.PlainClass, int, int>> _unpackOperationTable;
        
        private System.Func<MsgPack.Unpacker, MsgPack.Serialization.PlainClass, int, int, System.Threading.CancellationToken, System.Threading.Tasks.Task> this_UnpackValueOfCollectionReadOnlyPropertyAsyncDelegate;
        
        private System.Func<MsgPack.Unpacker, System.Type, string, System.Threading.CancellationToken, System.Threading.Tasks.Task<int>> MsgPack_Serialization_UnpackHelpers_UnpackInt32ValueAsyncDelegate;
        
        private System.Func<MsgPack.Unpacker, MsgPack.Serialization.PlainClass, int, int, System.Threading.CancellationToken, System.Threading.Tasks.Task> this_UnpackValueOfPublicFieldAsyncDelegate;
        
        private System.Func<MsgPack.Unpacker, MsgPack.Serialization.PlainClass, int, int, System.Threading.CancellationToken, System.Threading.Tasks.Task> this_UnpackValueOfPublicPropertyAsyncDelegate;
        
        private System.Collections.Generic.IList<System.Func<MsgPack.Unpacker, MsgPack.Serialization.PlainClass, int, int, System.Threading.CancellationToken, System.Threading.Tasks.Task>> _unpackOperationListAsync;
        
        private System.Collections.Generic.IDictionary<string, System.Func<MsgPack.Unpacker, MsgPack.Serialization.PlainClass, int, int, System.Threading.CancellationToken, System.Threading.Tasks.Task>> _unpackOperationTableAsync;
        
        public MsgPack_Serialization_PlainClassSerializer(MsgPack.Serialization.SerializationContext context) : 
                base(context) {
            MsgPack.Serialization.PolymorphismSchema schema0 = default(MsgPack.Serialization.PolymorphismSchema);
            schema0 = null;
            this._serializer0 = context.GetSerializer<System.Collections.Generic.List<int>>(schema0);
            MsgPack.Serialization.PolymorphismSchema schema1 = default(MsgPack.Serialization.PolymorphismSchema);
            schema1 = null;
            this._serializer1 = context.GetSerializer<int>(schema1);
            System.Action<MsgPack.Packer, MsgPack.Serialization.PlainClass>[] packOperationList = default(System.Action<MsgPack.Packer, MsgPack.Serialization.PlainClass>[]);
            packOperationList = new System.Action<MsgPack.Packer, MsgPack.Serialization.PlainClass>[3];
            packOperationList[0] = new System.Action<MsgPack.Packer, MsgPack.Serialization.PlainClass>(this.PackValueOfCollectionReadOnlyProperty);
            packOperationList[1] = new System.Action<MsgPack.Packer, MsgPack.Serialization.PlainClass>(this.PackValueOfPublicField);
            packOperationList[2] = new System.Action<MsgPack.Packer, MsgPack.Serialization.PlainClass>(this.PackValueOfPublicProperty);
            this._packOperationList = packOperationList;
            System.Func<MsgPack.Packer, MsgPack.Serialization.PlainClass, System.Threading.CancellationToken, System.Threading.Tasks.Task>[] packOperationListAsync = default(System.Func<MsgPack.Packer, MsgPack.Serialization.PlainClass, System.Threading.CancellationToken, System.Threading.Tasks.Task>[]);
            packOperationListAsync = new System.Func<MsgPack.Packer, MsgPack.Serialization.PlainClass, System.Threading.CancellationToken, System.Threading.Tasks.Task>[3];
            packOperationListAsync[0] = new System.Func<MsgPack.Packer, MsgPack.Serialization.PlainClass, System.Threading.CancellationToken, System.Threading.Tasks.Task>(this.PackValueOfCollectionReadOnlyPropertyAsync);
            packOperationListAsync[1] = new System.Func<MsgPack.Packer, MsgPack.Serialization.PlainClass, System.Threading.CancellationToken, System.Threading.Tasks.Task>(this.PackValueOfPublicFieldAsync);
            packOperationListAsync[2] = new System.Func<MsgPack.Packer, MsgPack.Serialization.PlainClass, System.Threading.CancellationToken, System.Threading.Tasks.Task>(this.PackValueOfPublicPropertyAsync);
            this._packOperationListAsync = packOperationListAsync;
            System.Collections.Generic.Dictionary<string, System.Action<MsgPack.Packer, MsgPack.Serialization.PlainClass>> packOperationTable = default(System.Collections.Generic.Dictionary<string, System.Action<MsgPack.Packer, MsgPack.Serialization.PlainClass>>);
            packOperationTable = new System.Collections.Generic.Dictionary<string, System.Action<MsgPack.Packer, MsgPack.Serialization.PlainClass>>(3);
            packOperationTable["CollectionReadOnlyProperty"] = new System.Action<MsgPack.Packer, MsgPack.Serialization.PlainClass>(this.PackValueOfCollectionReadOnlyProperty);
            packOperationTable["PublicField"] = new System.Action<MsgPack.Packer, MsgPack.Serialization.PlainClass>(this.PackValueOfPublicField);
            packOperationTable["PublicProperty"] = new System.Action<MsgPack.Packer, MsgPack.Serialization.PlainClass>(this.PackValueOfPublicProperty);
            this._packOperationTable = packOperationTable;
            System.Collections.Generic.Dictionary<string, System.Func<MsgPack.Packer, MsgPack.Serialization.PlainClass, System.Threading.CancellationToken, System.Threading.Tasks.Task>> packOperationTableAsync = default(System.Collections.Generic.Dictionary<string, System.Func<MsgPack.Packer, MsgPack.Serialization.PlainClass, System.Threading.CancellationToken, System.Threading.Tasks.Task>>);
            packOperationTableAsync = new System.Collections.Generic.Dictionary<string, System.Func<MsgPack.Packer, MsgPack.Serialization.PlainClass, System.Threading.CancellationToken, System.Threading.Tasks.Task>>(3);
            packOperationTableAsync["CollectionReadOnlyProperty"] = new System.Func<MsgPack.Packer, MsgPack.Serialization.PlainClass, System.Threading.CancellationToken, System.Threading.Tasks.Task>(this.PackValueOfCollectionReadOnlyPropertyAsync);
            packOperationTableAsync["PublicField"] = new System.Func<MsgPack.Packer, MsgPack.Serialization.PlainClass, System.Threading.CancellationToken, System.Threading.Tasks.Task>(this.PackValueOfPublicFieldAsync);
            packOperationTableAsync["PublicProperty"] = new System.Func<MsgPack.Packer, MsgPack.Serialization.PlainClass, System.Threading.CancellationToken, System.Threading.Tasks.Task>(this.PackValueOfPublicPropertyAsync);
            this._packOperationTableAsync = packOperationTableAsync;
            System.Action<MsgPack.Unpacker, MsgPack.Serialization.PlainClass, int, int>[] unpackOperationList = default(System.Action<MsgPack.Unpacker, MsgPack.Serialization.PlainClass, int, int>[]);
            unpackOperationList = new System.Action<MsgPack.Unpacker, MsgPack.Serialization.PlainClass, int, int>[3];
            unpackOperationList[0] = new System.Action<MsgPack.Unpacker, MsgPack.Serialization.PlainClass, int, int>(this.UnpackValueOfCollectionReadOnlyProperty);
            unpackOperationList[1] = new System.Action<MsgPack.Unpacker, MsgPack.Serialization.PlainClass, int, int>(this.UnpackValueOfPublicField);
            unpackOperationList[2] = new System.Action<MsgPack.Unpacker, MsgPack.Serialization.PlainClass, int, int>(this.UnpackValueOfPublicProperty);
            this._unpackOperationList = unpackOperationList;
            System.Func<MsgPack.Unpacker, MsgPack.Serialization.PlainClass, int, int, System.Threading.CancellationToken, System.Threading.Tasks.Task>[] unpackOperationListAsync = default(System.Func<MsgPack.Unpacker, MsgPack.Serialization.PlainClass, int, int, System.Threading.CancellationToken, System.Threading.Tasks.Task>[]);
            unpackOperationListAsync = new System.Func<MsgPack.Unpacker, MsgPack.Serialization.PlainClass, int, int, System.Threading.CancellationToken, System.Threading.Tasks.Task>[3];
            unpackOperationListAsync[0] = new System.Func<MsgPack.Unpacker, MsgPack.Serialization.PlainClass, int, int, System.Threading.CancellationToken, System.Threading.Tasks.Task>(this.UnpackValueOfCollectionReadOnlyPropertyAsync);
            unpackOperationListAsync[1] = new System.Func<MsgPack.Unpacker, MsgPack.Serialization.PlainClass, int, int, System.Threading.CancellationToken, System.Threading.Tasks.Task>(this.UnpackValueOfPublicFieldAsync);
            unpackOperationListAsync[2] = new System.Func<MsgPack.Unpacker, MsgPack.Serialization.PlainClass, int, int, System.Threading.CancellationToken, System.Threading.Tasks.Task>(this.UnpackValueOfPublicPropertyAsync);
            this._unpackOperationListAsync = unpackOperationListAsync;
            System.Collections.Generic.Dictionary<string, System.Action<MsgPack.Unpacker, MsgPack.Serialization.PlainClass, int, int>> unpackOperationTable = default(System.Collections.Generic.Dictionary<string, System.Action<MsgPack.Unpacker, MsgPack.Serialization.PlainClass, int, int>>);
            unpackOperationTable = new System.Collections.Generic.Dictionary<string, System.Action<MsgPack.Unpacker, MsgPack.Serialization.PlainClass, int, int>>(3);
            unpackOperationTable["CollectionReadOnlyProperty"] = new System.Action<MsgPack.Unpacker, MsgPack.Serialization.PlainClass, int, int>(this.UnpackValueOfCollectionReadOnlyProperty);
            unpackOperationTable["PublicField"] = new System.Action<MsgPack.Unpacker, MsgPack.Serialization.PlainClass, int, int>(this.UnpackValueOfPublicField);
            unpackOperationTable["PublicProperty"] = new System.Action<MsgPack.Unpacker, MsgPack.Serialization.PlainClass, int, int>(this.UnpackValueOfPublicProperty);
            this._unpackOperationTable = unpackOperationTable;
            System.Collections.Generic.Dictionary<string, System.Func<MsgPack.Unpacker, MsgPack.Serialization.PlainClass, int, int, System.Threading.CancellationToken, System.Threading.Tasks.Task>> unpackOperationTableAsync = default(System.Collections.Generic.Dictionary<string, System.Func<MsgPack.Unpacker, MsgPack.Serialization.PlainClass, int, int, System.Threading.CancellationToken, System.Threading.Tasks.Task>>);
            unpackOperationTableAsync = new System.Collections.Generic.Dictionary<string, System.Func<MsgPack.Unpacker, MsgPack.Serialization.PlainClass, int, int, System.Threading.CancellationToken, System.Threading.Tasks.Task>>(3);
            unpackOperationTableAsync["CollectionReadOnlyProperty"] = new System.Func<MsgPack.Unpacker, MsgPack.Serialization.PlainClass, int, int, System.Threading.CancellationToken, System.Threading.Tasks.Task>(this.UnpackValueOfCollectionReadOnlyPropertyAsync);
            unpackOperationTableAsync["PublicField"] = new System.Func<MsgPack.Unpacker, MsgPack.Serialization.PlainClass, int, int, System.Threading.CancellationToken, System.Threading.Tasks.Task>(this.UnpackValueOfPublicFieldAsync);
            unpackOperationTableAsync["PublicProperty"] = new System.Func<MsgPack.Unpacker, MsgPack.Serialization.PlainClass, int, int, System.Threading.CancellationToken, System.Threading.Tasks.Task>(this.UnpackValueOfPublicPropertyAsync);
            this._unpackOperationTableAsync = unpackOperationTableAsync;
            this._memberNames = new string[] {
                    "CollectionReadOnlyProperty",
                    "PublicField",
                    "PublicProperty"};
            this.this_PackValueOfCollectionReadOnlyPropertyDelegate = new System.Action<MsgPack.Packer, MsgPack.Serialization.PlainClass>(this.PackValueOfCollectionReadOnlyProperty);
            this.this_PackValueOfPublicFieldDelegate = new System.Action<MsgPack.Packer, MsgPack.Serialization.PlainClass>(this.PackValueOfPublicField);
            this.this_PackValueOfPublicPropertyDelegate = new System.Action<MsgPack.Packer, MsgPack.Serialization.PlainClass>(this.PackValueOfPublicProperty);
            this.this_PackValueOfCollectionReadOnlyPropertyAsyncDelegate = new System.Func<MsgPack.Packer, MsgPack.Serialization.PlainClass, System.Threading.CancellationToken, System.Threading.Tasks.Task>(this.PackValueOfCollectionReadOnlyPropertyAsync);
            this.this_PackValueOfPublicFieldAsyncDelegate = new System.Func<MsgPack.Packer, MsgPack.Serialization.PlainClass, System.Threading.CancellationToken, System.Threading.Tasks.Task>(this.PackValueOfPublicFieldAsync);
            this.this_PackValueOfPublicPropertyAsyncDelegate = new System.Func<MsgPack.Packer, MsgPack.Serialization.PlainClass, System.Threading.CancellationToken, System.Threading.Tasks.Task>(this.PackValueOfPublicPropertyAsync);
            this.this_SetUnpackedValueOfCollectionReadOnlyPropertyDelegate = new System.Action<MsgPack.Serialization.PlainClass, System.Collections.Generic.List<int>>(this.SetUnpackedValueOfCollectionReadOnlyProperty);
            this.this_UnpackValueOfCollectionReadOnlyPropertyDelegate = new System.Action<MsgPack.Unpacker, MsgPack.Serialization.PlainClass, int, int>(this.UnpackValueOfCollectionReadOnlyProperty);
            this.this_SetUnpackedValueOfPublicFieldDelegate = new System.Action<MsgPack.Serialization.PlainClass, int>(this.SetUnpackedValueOfPublicField);
            this.MsgPack_Serialization_UnpackHelpers_UnpackInt32ValueDelegate = new System.Func<MsgPack.Unpacker, System.Type, string, int>(MsgPack.Serialization.UnpackHelpers.UnpackInt32Value);
            this.this_UnpackValueOfPublicFieldDelegate = new System.Action<MsgPack.Unpacker, MsgPack.Serialization.PlainClass, int, int>(this.UnpackValueOfPublicField);
            this.this_SetUnpackedValueOfPublicPropertyDelegate = new System.Action<MsgPack.Serialization.PlainClass, int>(this.SetUnpackedValueOfPublicProperty);
            this.this_UnpackValueOfPublicPropertyDelegate = new System.Action<MsgPack.Unpacker, MsgPack.Serialization.PlainClass, int, int>(this.UnpackValueOfPublicProperty);
            this.this_UnpackValueOfCollectionReadOnlyPropertyAsyncDelegate = new System.Func<MsgPack.Unpacker, MsgPack.Serialization.PlainClass, int, int, System.Threading.CancellationToken, System.Threading.Tasks.Task>(this.UnpackValueOfCollectionReadOnlyPropertyAsync);
            this.MsgPack_Serialization_UnpackHelpers_UnpackInt32ValueAsyncDelegate = new System.Func<MsgPack.Unpacker, System.Type, string, System.Threading.CancellationToken, System.Threading.Tasks.Task<int>>(MsgPack.Serialization.UnpackHelpers.UnpackInt32ValueAsync);
            this.this_UnpackValueOfPublicFieldAsyncDelegate = new System.Func<MsgPack.Unpacker, MsgPack.Serialization.PlainClass, int, int, System.Threading.CancellationToken, System.Threading.Tasks.Task>(this.UnpackValueOfPublicFieldAsync);
            this.this_UnpackValueOfPublicPropertyAsyncDelegate = new System.Func<MsgPack.Unpacker, MsgPack.Serialization.PlainClass, int, int, System.Threading.CancellationToken, System.Threading.Tasks.Task>(this.UnpackValueOfPublicPropertyAsync);
        }
        
        private void PackValueOfCollectionReadOnlyProperty(MsgPack.Packer packer, MsgPack.Serialization.PlainClass objectTree) {
            this._serializer0.PackTo(packer, objectTree.CollectionReadOnlyProperty);
        }
        
        private void PackValueOfPublicField(MsgPack.Packer packer, MsgPack.Serialization.PlainClass objectTree) {
            this._serializer1.PackTo(packer, objectTree.PublicField);
        }
        
        private void PackValueOfPublicProperty(MsgPack.Packer packer, MsgPack.Serialization.PlainClass objectTree) {
            this._serializer1.PackTo(packer, objectTree.PublicProperty);
        }
        
        protected internal override void PackToCore(MsgPack.Packer packer, MsgPack.Serialization.PlainClass objectTree) {
            if ((this.OwnerContext.SerializationMethod == MsgPack.Serialization.SerializationMethod.Array)) {
                MsgPack.Serialization.PackHelpers.PackToArray(packer, objectTree, this._packOperationList);
            }
            else {
                MsgPack.Serialization.PackHelpers.PackToMap(packer, objectTree, this._packOperationTable);
            }
        }
        
        private System.Threading.Tasks.Task PackValueOfCollectionReadOnlyPropertyAsync(MsgPack.Packer packer, MsgPack.Serialization.PlainClass objectTree, System.Threading.CancellationToken cancellationToken) {
            return this._serializer0.PackToAsync(packer, objectTree.CollectionReadOnlyProperty, cancellationToken);
        }
        
        private System.Threading.Tasks.Task PackValueOfPublicFieldAsync(MsgPack.Packer packer, MsgPack.Serialization.PlainClass objectTree, System.Threading.CancellationToken cancellationToken) {
            return this._serializer1.PackToAsync(packer, objectTree.PublicField, cancellationToken);
        }
        
        private System.Threading.Tasks.Task PackValueOfPublicPropertyAsync(MsgPack.Packer packer, MsgPack.Serialization.PlainClass objectTree, System.Threading.CancellationToken cancellationToken) {
            return this._serializer1.PackToAsync(packer, objectTree.PublicProperty, cancellationToken);
        }
        
        protected internal override System.Threading.Tasks.Task PackToAsyncCore(MsgPack.Packer packer, MsgPack.Serialization.PlainClass objectTree, System.Threading.CancellationToken cancellationToken) {
            if ((this.OwnerContext.SerializationMethod == MsgPack.Serialization.SerializationMethod.Array)) {
                return MsgPack.Serialization.PackHelpers.PackToArrayAsync(packer, objectTree, this._packOperationListAsync, cancellationToken);
            }
            else {
                return MsgPack.Serialization.PackHelpers.PackToMapAsync(packer, objectTree, this._packOperationTableAsync, cancellationToken);
            }
        }
        
        private void SetUnpackedValueOfCollectionReadOnlyProperty(MsgPack.Serialization.PlainClass unpackingContext, System.Collections.Generic.List<int> unpackedValue) {
            System.Collections.Generic.List<int> existent = default(System.Collections.Generic.List<int>);
            existent = unpackingContext.CollectionReadOnlyProperty;
            System.Collections.Generic.List<int>.Enumerator enumerator = unpackedValue.GetEnumerator();
            int current;
            try {
                for (
                ; enumerator.MoveNext(); 
                ) {
                    current = enumerator.Current;
                    existent.Add(current);
                }
            }
            finally {
                enumerator.Dispose();
            }
        }
        
        private void UnpackValueOfCollectionReadOnlyProperty(MsgPack.Unpacker unpacker, MsgPack.Serialization.PlainClass unpackingContext, int indexOfItem, int itemsCount) {
            MsgPack.Serialization.UnpackHelpers.UnpackReferenceTypeValue(unpacker, unpackingContext, this._serializer0, itemsCount, indexOfItem, typeof(System.Collections.Generic.List<int>), "CollectionReadOnlyProperty", MsgPack.Serialization.NilImplication.MemberDefault, null, this.this_SetUnpackedValueOfCollectionReadOnlyPropertyDelegate);
        }
        
        private void SetUnpackedValueOfPublicField(MsgPack.Serialization.PlainClass unpackingContext, int unpackedValue) {
            unpackingContext.PublicField = unpackedValue;
        }
        
        private void UnpackValueOfPublicField(MsgPack.Unpacker unpacker, MsgPack.Serialization.PlainClass unpackingContext, int indexOfItem, int itemsCount) {
            MsgPack.Serialization.UnpackHelpers.UnpackValueTypeValue(unpacker, unpackingContext, this._serializer1, itemsCount, indexOfItem, typeof(int), "PublicField", MsgPack.Serialization.NilImplication.MemberDefault, this.MsgPack_Serialization_UnpackHelpers_UnpackInt32ValueDelegate, this.this_SetUnpackedValueOfPublicFieldDelegate);
        }
        
        private void SetUnpackedValueOfPublicProperty(MsgPack.Serialization.PlainClass unpackingContext, int unpackedValue) {
            unpackingContext.PublicProperty = unpackedValue;
        }
        
        private void UnpackValueOfPublicProperty(MsgPack.Unpacker unpacker, MsgPack.Serialization.PlainClass unpackingContext, int indexOfItem, int itemsCount) {
            MsgPack.Serialization.UnpackHelpers.UnpackValueTypeValue(unpacker, unpackingContext, this._serializer1, itemsCount, indexOfItem, typeof(int), "PublicProperty", MsgPack.Serialization.NilImplication.MemberDefault, this.MsgPack_Serialization_UnpackHelpers_UnpackInt32ValueDelegate, this.this_SetUnpackedValueOfPublicPropertyDelegate);
        }
        
        protected internal override MsgPack.Serialization.PlainClass UnpackFromCore(MsgPack.Unpacker unpacker) {
            MsgPack.Serialization.PlainClass result = default(MsgPack.Serialization.PlainClass);
            result = new MsgPack.Serialization.PlainClass();
            if (unpacker.IsArrayHeader) {
                return MsgPack.Serialization.UnpackHelpers.UnpackFromArray(unpacker, result, MsgPack.Serialization.UnpackHelpers.GetIdentity<MsgPack.Serialization.PlainClass>(), this._memberNames, this._unpackOperationList);
            }
            else {
                return MsgPack.Serialization.UnpackHelpers.UnpackFromMap(unpacker, result, MsgPack.Serialization.UnpackHelpers.GetIdentity<MsgPack.Serialization.PlainClass>(), this._unpackOperationTable);
            }
        }
        
        private System.Threading.Tasks.Task UnpackValueOfCollectionReadOnlyPropertyAsync(MsgPack.Unpacker unpacker, MsgPack.Serialization.PlainClass unpackingContext, int indexOfItem, int itemsCount, System.Threading.CancellationToken cancellationToken) {
            return MsgPack.Serialization.UnpackHelpers.UnpackReferenceTypeValueAsync(unpacker, unpackingContext, this._serializer0, itemsCount, indexOfItem, typeof(System.Collections.Generic.List<int>), "CollectionReadOnlyProperty", MsgPack.Serialization.NilImplication.MemberDefault, null, this.this_SetUnpackedValueOfCollectionReadOnlyPropertyDelegate, cancellationToken);
        }
        
        private System.Threading.Tasks.Task UnpackValueOfPublicFieldAsync(MsgPack.Unpacker unpacker, MsgPack.Serialization.PlainClass unpackingContext, int indexOfItem, int itemsCount, System.Threading.CancellationToken cancellationToken) {
            return MsgPack.Serialization.UnpackHelpers.UnpackValueTypeValueAsync(unpacker, unpackingContext, this._serializer1, itemsCount, indexOfItem, typeof(int), "PublicField", MsgPack.Serialization.NilImplication.MemberDefault, this.MsgPack_Serialization_UnpackHelpers_UnpackInt32ValueAsyncDelegate, this.this_SetUnpackedValueOfPublicFieldDelegate, cancellationToken);
        }
        
        private System.Threading.Tasks.Task UnpackValueOfPublicPropertyAsync(MsgPack.Unpacker unpacker, MsgPack.Serialization.PlainClass unpackingContext, int indexOfItem, int itemsCount, System.Threading.CancellationToken cancellationToken) {
            return MsgPack.Serialization.UnpackHelpers.UnpackValueTypeValueAsync(unpacker, unpackingContext, this._serializer1, itemsCount, indexOfItem, typeof(int), "PublicProperty", MsgPack.Serialization.NilImplication.MemberDefault, this.MsgPack_Serialization_UnpackHelpers_UnpackInt32ValueAsyncDelegate, this.this_SetUnpackedValueOfPublicPropertyDelegate, cancellationToken);
        }
        
        protected internal override System.Threading.Tasks.Task<MsgPack.Serialization.PlainClass> UnpackFromAsyncCore(MsgPack.Unpacker unpacker, System.Threading.CancellationToken cancellationToken) {
            MsgPack.Serialization.PlainClass result = default(MsgPack.Serialization.PlainClass);
            result = new MsgPack.Serialization.PlainClass();
            if (unpacker.IsArrayHeader) {
                return MsgPack.Serialization.UnpackHelpers.UnpackFromArrayAsync(unpacker, result, MsgPack.Serialization.UnpackHelpers.GetIdentity<MsgPack.Serialization.PlainClass>(), this._memberNames, this._unpackOperationListAsync, cancellationToken);
            }
            else {
                return MsgPack.Serialization.UnpackHelpers.UnpackFromMapAsync(unpacker, result, MsgPack.Serialization.UnpackHelpers.GetIdentity<MsgPack.Serialization.PlainClass>(), this._unpackOperationTableAsync, cancellationToken);
            }
        }
    }
}