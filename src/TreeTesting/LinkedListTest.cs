/*
 * Gemaakt met SharpDevelop.
 * Gebruiker: 8008
 * Datum: 3-2-2009
 * Tijd: 12:23
 * 
 * Dit sjabloon wijzigen: Extra | Opties |Coderen | Standaard kop bewerken.
 */

using System;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using TreeCore;

namespace TreeTesting
{
	[TestFixture]
	public class LinkedListTest
	{
		private LinkedListNode firstNode;
		[SetUp]
		public void Init()
		{
			firstNode = new LinkedListNode(null);
			firstNode.Append(new LinkedListNode(null));
			firstNode.Next.Append(new LinkedListNode(null));
			firstNode.Next.Next.Append(new LinkedListNode(null));
			firstNode.Next.Next.Next.Append(new LinkedListNode(null));
			firstNode.Next.Next.Next.Next.Append(new LinkedListNode(null));
			firstNode.Next.Next.Next.Next.Next.Append(new LinkedListNode(null));
			firstNode.Next.Next.Next.Next.Next.Next.Append(new LinkedListNode(null));
		}
		
		[Test]
		public void MainTest()
		{
			Assert.That(firstNode, Is.SameAs(firstNode.Next.Previous));
			Assert.That(firstNode, Is.SameAs(firstNode.Next.Next.Next.Next.Next.Next.Next.Next));
			Assert.That(firstNode.Lenght, Is.EqualTo(8));
			Assert.That(firstNode.Next.Lenght, Is.EqualTo(8));
		}
	}
}
