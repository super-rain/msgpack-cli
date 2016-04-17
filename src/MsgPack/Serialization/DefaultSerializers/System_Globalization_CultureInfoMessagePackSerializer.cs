#region -- License Terms --
//
// MessagePack for CLI
//
// Copyright (C) 2015-2016 FUJIWARA, Yusuke
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
using System.Globalization;
#if FEATURE_TAP
using System.Threading;
using System.Threading.Tasks;
#endif // FEATURE_TAP

namespace MsgPack.Serialization.DefaultSerializers
{
	// ReSharper disable once InconsistentNaming
	internal sealed class System_Globalization_CultureInfoMessagePackSerializer : MessagePackSerializer<CultureInfo>
	{
		public System_Globalization_CultureInfoMessagePackSerializer( SerializationContext ownerContext )
			: base( ownerContext ) { }

		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", MessageId = "0", Justification = "Validated by caller in base class" )]
		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", MessageId = "1", Justification = "Validated by caller in base class" )]
		protected internal override void PackToCore( Packer packer, CultureInfo objectTree )
		{
			packer.PackString( objectTree.Name );
		}

		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", MessageId = "0", Justification = "Asserted internally" )]
		protected internal override CultureInfo UnpackFromCore( Unpacker unpacker )
		{
#if SILVERLIGHT || NETSTD_11 || NETSTD_13
			return new CultureInfo( unpacker.LastReadData.AsString() );
#else
			return CultureInfo.GetCultureInfo( unpacker.LastReadData.AsString() );
#endif // SILVERLIGHT || NETSTD_11 || NETSTD_13
		}

#if FEATURE_TAP

		protected internal override Task PackToAsyncCore( Packer packer, CultureInfo objectTree, CancellationToken cancellationToken )
		{
			return packer.PackStringAsync( objectTree.Name, cancellationToken );
		}

		protected internal override Task<CultureInfo> UnpackFromAsyncCore( Unpacker unpacker, CancellationToken cancellationToken )
		{
			var tcs = new TaskCompletionSource<CultureInfo>();
			try
			{
				tcs.SetResult( this.UnpackFromCore( unpacker ) );
			}
			catch ( Exception ex )
			{
				tcs.SetException( ex );
			}

			return tcs.Task;
		}

#endif // FEATURE_TAP
	}
}