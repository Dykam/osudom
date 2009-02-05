/*
 * Gemaakt met SharpDevelop.
 * Gebruiker: 8008
 * Datum: 4-2-2009
 * Tijd: 14:30
 * 
 * Dit sjabloon wijzigen: Extra | Opties |Coderen | Standaard kop bewerken.
 */

using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using System;
using TreeCore;

namespace TreeTest
{
	[TestFixture]
	public class LinkedListNodeTest
	{
		[Test]
		public void TestCreation()
		{
			LinkedListNode<int> subject = new LinkedListNode<int>(0);
			Assert.That(subject.Lenght, Is.EqualTo(1));
		}
		
		[Test]
		public void TestSingleAdd()
		{
			LinkedListNode<int> subject = new LinkedListNode<int>(0);
			subject.Append(new LinkedListNode<int>(0));
			Assert.That(subject.Lenght, Is.EqualTo(2));
		}
		
		[Test]
		public void TestMultiAdd()
		{
			LinkedListNode<int> subject = new LinkedListNode<int>(0);
			for(uint i = 0; i < 4; i++)
			{
				subject.Append(new LinkedListNode<int>(0));
			}
			Assert.That(subject.Lenght, Is.EqualTo(5));
		}
		[Test]
		public void TestHugeMultiCreation()
		{
			LinkedListNode<int> subject = new LinkedListNode<int>(0);
			for(uint i = 0; i < 100; i++)
			{
				subject.Append(new LinkedListNode<int>(0));
			}
			Assert.That(subject.Lenght, Is.EqualTo(101));
			
		}
		[Test]
		public void TestMergeSingles()
		{
			LinkedListNode<int> subject = new LinkedListNode<int>(0);
			LinkedListNode<int> mergable = new LinkedListNode<int>(0);
			subject.Append(mergable);
			Assert.That(subject.Lenght, Is.EqualTo(2));
		}
		[Test]
		public void TestMergeHybrid()
		{
			LinkedListNode<int> subject = new LinkedListNode<int>(0);
			LinkedListNode<int> mergable = new LinkedListNode<int>(0);
			for(uint i = 0; i < 4; i++)
			{
				mergable.Append(new LinkedListNode<int>(0));
			}
			subject.Append(mergable);
			Assert.That(subject.Lenght, Is.EqualTo(6));
		}
		[Test]
		public void TestMergeRings()
		{
			LinkedListNode<int> subject = new LinkedListNode<int>(0);
			for(uint i = 0; i < 4; i++)
			{
				subject.Append(new LinkedListNode<int>(0));
			}
			LinkedListNode<int> mergable = new LinkedListNode<int>(0);
			for(uint i = 0; i < 4; i++)
			{
				mergable.Append(new LinkedListNode<int>(0));
			}
			subject.Append(mergable);
			Assert.That(subject.Lenght, Is.EqualTo(10));
		}
		[Test]
		public void TestTakeOut()
		{
			LinkedListNode<int> subject = new LinkedListNode<int>(0);
			for(uint i = 0; i < 4; i++)
			{
				subject.Append(new LinkedListNode<int>(0));
			}
			subject.Next.TakeOut();
			Assert.That(subject.Next.TakeOut().Lenght, Is.EqualTo(1));
			Assert.That(subject.Lenght, Is.EqualTo(4));
		}
		[Test]
		public void TestJump()
		{
			LinkedListNode<int> subject = new LinkedListNode<int>(0);
			for(uint i = 0; i < 4; i++)
			{
				subject.Append(new LinkedListNode<int>(0));
			}
			LinkedListNode<int> jumped = subject.Jump(2);
			Assert.That(jumped, Is.SameAs(subject.Next.Next));
			Assert.That(subject.Lenght, Is.EqualTo(5));
			Assert.That(jumped.Lenght, Is.EqualTo(5));
		}
		[Test]
		public void TestSplit()
		{
			LinkedListNode<int> subject = new LinkedListNode<int>(0);
			for(uint i = 0; i < 5; i++)
			{
				subject.Append(new LinkedListNode<int>(0));
			}
			LinkedListNode<int> splitted = subject.Split(3);
			Assert.That(subject.Lenght, Is.EqualTo(3));
			Assert.That(splitted.Lenght, Is.EqualTo(3));
		}
		
		[TestFixtureSetUp]
		public void Init()
		{
			// TODO: Add Init code.
		}
		
		[TestFixtureTearDown]
		public void Dispose()
		{
			// TODO: Add tear down code.
		}
	}
}
