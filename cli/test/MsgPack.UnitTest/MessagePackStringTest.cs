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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Security;
using System.Security.Policy;
using System.Security.Permissions;
using System.Diagnostics;

namespace MsgPack
{
	[TestFixture]
	public class MessagePackStringTest
	{
		[Test]
		public void TestEqualsFullTrust()
		{
			var result = TestEqualsCore();
			Assert.That( MessagePackString.IsFastEqualsDisabled, Is.False );
			Console.WriteLine( "TestEqualsFullTrust" );
			ShowResult( result );
		}

		private void ShowResult( Tuple<double, double, double, double> result )
		{
			Console.WriteLine( "Tiny(few bytes)      : {0:#,0.0} usec", result.Item1 );
			Console.WriteLine( "Small(16 chars)      : {0:#,0.0} usec", result.Item2 );
			Console.WriteLine( "Medium(1,000 chars)  : {0:#,0.0} usec", result.Item3 );
			Console.WriteLine( "Large(100,000 chars) : {0:#,0.0} usec", result.Item4 );
		}

		private static StrongName GetStrongName( Type type )
		{
			var assemblyName = type.Assembly.GetName();
			return new StrongName( new StrongNamePublicKeyBlob( assemblyName.GetPublicKey() ), assemblyName.Name, assemblyName.Version );
		}

		[Test]
		public void TestEqualsPartialTrust()
		{
			var appDomainSetUp = new AppDomainSetup() { ApplicationBase = AppDomain.CurrentDomain.SetupInformation.ApplicationBase };
			var evidence = new Evidence();
			evidence.AddHostEvidence( new Zone( SecurityZone.Internet ) );
			var permisions = SecurityManager.GetStandardSandbox( evidence );
			AppDomain workerDomain = AppDomain.CreateDomain( "PartialTrust", evidence, appDomainSetUp, permisions, GetStrongName( this.GetType() ) );
			try
			{
				workerDomain.DoCallBack( TestEqualsWorker );

				Assert.That( ( bool )workerDomain.GetData( "MessagePackString.IsFastEqualsDisabled" ), Is.True );
				Console.WriteLine( "TestEqualsPartialTrust" );
				ShowResult( workerDomain.GetData( "TestEqualsWorker.Performance" ) as Tuple<double, double, double, double> );
			}
			finally
			{
				AppDomain.Unload( workerDomain );
			}
		}

		public static void TestEqualsWorker()
		{
			var result = TestEqualsCore();
			AppDomain.CurrentDomain.SetData( "TestEqualsWorker.Performance", result );
			AppDomain.CurrentDomain.SetData( "MessagePackString.IsFastEqualsDisabled", MessagePackString.IsFastEqualsDisabled );
		}

		private static Tuple<double, double, double, double> TestEqualsCore()
		{
			var values =
				new[] 
				{ 
					new MessagePackString( new byte[ 0 ] ), 
					new MessagePackString( new byte[] { 0x20 } ), 
					new MessagePackString( new byte[] { 0xff } ),
					new MessagePackString( new byte[] { 1, 2, 3 } ), 
					new MessagePackString( new byte[] { 3, 2, 1 } ) 
			};

			const int iteration = 10;
			double tinyAvg = Double.MaxValue;
			double smallAvg = Double.MaxValue;
			double mediumAvg = Double.MaxValue;
			double largeAvg = Double.MaxValue;

			var sw = new Stopwatch();
			for ( int i = 0; i < iteration; i++ )
			{
				sw.Restart();
				for ( int x = 0; x < values.Length; x++ )
				{
					Assert.That( values[ x ].Equals( null ), Is.False );

					for ( int y = 0; y < values.Length; y++ )
					{
						Assert.That( values[ x ].Equals( values[ y ] ), Is.EqualTo( x == y ) );
					}
				}
				sw.Stop();
				tinyAvg = Math.Min( tinyAvg, sw.Elapsed.Ticks * 10.0 / ( values.Length * values.Length ) );
			}

			var smallX = new MessagePackString( new String( 'A', 16 ) );
			var smallY = new MessagePackString( MessagePackConvert.EncodeString( new String( 'A', 16 ) ) );

			for ( int i = 0; i < iteration; i++ )
			{
				sw.Restart();
				Assert.That( smallX.Equals( smallY ), Is.True );
				sw.Stop();
				smallAvg = Math.Min( smallAvg, sw.Elapsed.Ticks * 10.0 );
			}

			var mediumX = new MessagePackString( new String( 'A', 1000 ) );
			var mediumY = new MessagePackString( MessagePackConvert.EncodeString( new String( 'A', 1000 ) ) );

			for ( int i = 0; i < iteration; i++ )
			{
				sw.Restart();
				Assert.That( mediumX.Equals( mediumY ), Is.True );
				sw.Stop();
				mediumAvg = Math.Min( mediumAvg, sw.Elapsed.Ticks * 10.0 );
			}

			var largeX = new MessagePackString( new String( 'A', 100000 ) );
			var largeY = new MessagePackString( MessagePackConvert.EncodeString( new String( 'A', 100000 ) ) );

			for ( int i = 0; i < iteration; i++ )
			{
				sw.Restart();
				Assert.That( largeX.Equals( largeY ), Is.True );
				sw.Stop();
				largeAvg = Math.Min( largeAvg, sw.Elapsed.Ticks * 10.0 );
			}

			return Tuple.Create( tinyAvg, smallAvg, mediumAvg, largeAvg );
		}
	}
}