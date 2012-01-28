﻿#region -- License Terms --
//
// MessagePack for CLI
//
// Copyright (C) 2010 FUJIWARA, Yusuke
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
using System.Collections;
using System.Reflection;

namespace MsgPack.Serialization.Metadata
{
	internal static class _IEnumerator
	{
		public static readonly MethodInfo MoveNext = FromExpression.ToMethod( ( IEnumerator enumerator ) => enumerator.MoveNext() );
		public static readonly PropertyInfo Current = FromExpression.ToProperty( ( IEnumerator enumerator ) => enumerator.Current );
	}
}
