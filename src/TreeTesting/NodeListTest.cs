/*
 * Gemaakt met SharpDevelop.
 * Gebruiker: 8008
 * Datum: 3-2-2009
 * Tijd: 10:04
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
	public class NodeListTest
	{
		[SetUp]
		public void Init()
		{
			
		}
		[Test]
		public void EmptyNodeListTest()
		{
			INodeList nodeList = new NodeList();
			Assert.AreEqual(0, nodeList.Length);
		}
		[Test]
		public void ContructorSingleNodeTest()
		{
			INodeList nodeList = new NodeList(new Node());
			Assert.AreEqual(1, nodeList.Length);
		}
		[Test]
		public void ConstructorMultiNodesTest()
		{
			INodeList newNodeList = new NodeList(new Node());
			newNodeList.Add(new Node());
			newNodeList.Add(new Node());
			INode node = new TestClass();
			newNodeList.Add(node);
			Assert.AreEqual(4, newNodeList.Length);
			uint pos = 0;
			INode foundNode = new Node();
			while(ReferenceEquals(foundNode, node))
			{
				foundNode = newNodeList[pos];
				pos++;
			}
			Assert.AreEqual(newNodeList.Length -1, pos);
			INodeList nodeList = new NodeList(newNodeList);
			Assert.AreEqual(4, nodeList.Length);
		}
		[Test]
		public void AddSingleNodeTest()
		{
			INodeList nodeList = new NodeList();
			nodeList.Add(new Node());
			Assert.AreEqual(1, nodeList.Length);
		}
		[Test]
		public void AddMultiNodesTest()
		{
			INodeList nodeList = new NodeList();
			nodeList.Add(new Node());
			nodeList.Add(new Node());
			nodeList.Add(new Node());
			nodeList.Add(new Node());
			Assert.AreEqual(4, nodeList.Length);
		}
	}
}
