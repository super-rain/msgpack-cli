﻿#region -- License Terms --
//
// MessagePack for CLI
//
// Copyright (C) 2016 FUJIWARA, Yusuke
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
using System.Text;
using System.Threading.Tasks;
#if !MSTEST
using NUnit.Framework;
#else
using TestFixtureAttribute = Microsoft.VisualStudio.TestPlatform.UnitTestFramework.TestClassAttribute;
using TestAttribute = Microsoft.VisualStudio.TestPlatform.UnitTestFramework.DataTestMethodAttribute;
using TestCaseAttribute = Microsoft.VisualStudio.TestPlatform.UnitTestFramework.DataRowAttribute;
using TimeoutAttribute = NUnit.Framework.TimeoutAttribute;
using Assert = NUnit.Framework.Assert;
using Is = NUnit.Framework.Is;
#endif

namespace MsgPack.Serialization
{
	[TestFixture]
	public class DictionaryKeyTransformersTest
	{
		[Test]
		[TestCase( default ( string ), default ( string ) )]
		[TestCase( "", "" )]
		[TestCase( "a", "a" )]
		[TestCase( "A", "a" )]
		[TestCase( "AA", "aA" )]
		[TestCase( "Aa", "aa" )]
		[TestCase( "aa", "aa" )]
		[TestCase( "_a", "_a" )]
		[TestCase( "_A", "_A" )]
		public void TestToLowerCamel( string input, string expected )
		{
			Assert.That( DictionaryKeyTransformers.ToLowerCamel( input ), Is.EqualTo( expected ) );
		}
	}
}
