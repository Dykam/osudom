#if DEBUG
using System;
using NUnit.Framework;

namespace TreeCore.Debug
{
    [TestFixture]
    public class LinkedNodeListTest
    {
        [Test]
        public void TestConstruct()
        {
            INodeList nodeList = new LinkedNodeList();
            Assert.That(nodeList.Length, Is.EqualTo(0));
        }
        [Test]
        public void TestSingleConstruct()
        {
            INodeList nodeList = new LinkedNodeList(new Node());
            Assert.That(nodeList.Length, Is.EqualTo(1));
        }
        [Test]
        public void TestMultiConstruct()
        {
            INodeList nodeListToAdd = new LinkedNodeList(new Node());
            nodeListToAdd.Add(new Node());
            nodeListToAdd.Add(new Node());
            INodeList nodeList = new LinkedNodeList(nodeListToAdd);
            Assert.That(nodeList.Length, Is.EqualTo(3));
        }
    }
}
#endif