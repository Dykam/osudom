#if DEBUG
namespace TreeCore.Debug
{
    using NUnit.Framework;
    using System;
    using TreeCore;

    [TestFixture(typeof(LinkedNodeList))]
    public class NodeListTest<NodeList> where NodeList : INodeList, new()
    {
        [Test]
        public void TestDoubleAdd()
        {
            INodeList nodeList = new NodeList();
            nodeList.Add(new Node());
            nodeList.Add(new Node());
            Assert.That(nodeList.Length, Is.EqualTo(2));
        }

        [Test]
        public void TestMultiAdd()
        {
            INodeList nodeList = new NodeList();
            INodeList nodeListToAdd = new NodeList();
            nodeListToAdd.Add(new Node());
            nodeListToAdd.Add(new Node());
            nodeList.Add(new Node());
            nodeList.Add(new Node());
            nodeList.Add(nodeListToAdd);
            Assert.That(nodeList.Length, Is.EqualTo(4));
        }

        [Test]
        public void TestSingleAdd()
        {
            INodeList nodeList = new NodeList();
            nodeList.Add(new Node());
            Assert.That(nodeList.Length, Is.EqualTo(1));
        }
        [Test]
        public void TestSingleInsertion()
        {
            INodeList nodeList = new NodeList();
            nodeList.InsertAt(0, new NumberedNode(0));
            Assert.That(nodeList.Length, Is.EqualTo(1));
            for (int i = 0; i < nodeList.Length; i++)
            {
                Assert.That(((NumberedNode)nodeList[i]).Value, Is.EqualTo(i));
            }
        }
        [Test]
        public void TestDoubleInsertion()
        {
            INodeList nodeList = new NodeList();
            nodeList.Add(new NumberedNode(2));
            nodeList.InsertAt(1, new NumberedNode(3));
            nodeList.InsertAt(2, new NumberedNode(4));
            nodeList.InsertAt(3, new NumberedNode(5));
            nodeList.InsertAt(4, new NumberedNode(6));
            nodeList.InsertAt(0, new NumberedNode(1));
            nodeList.InsertAt(0, new NumberedNode(0));
            Assert.That(nodeList.Length, Is.EqualTo(7));
            for (int i = 0; i < nodeList.Length; i++)
            {
                Assert.That(((NumberedNode)nodeList[i]).Value, Is.EqualTo(i));
            }
        }
        [Test]
        public void TestMultiMiddleInsertion()
        {
            Console.WriteLine("TestMultiMiddleInsertion");
            INodeList firstNodeList = new NodeList(), secondNodeList = new NodeList();
            INodeList resultingNodeList = new NodeList();
            for (int i = 0; i < 8; i++)
            {
                (i < 2 || i >= 6 ? firstNodeList : secondNodeList).Add(new NumberedNode(i));
            }
            for (int i = 0; i < firstNodeList.Length; i++)
            {
                resultingNodeList.Add(firstNodeList[i]);
            }
            resultingNodeList.InsertAt(2, secondNodeList);
            foreach (INode node in resultingNodeList)
            {
                Console.WriteLine(node);
            }
            for (int i = 0; i < 8; ++i)
            {
                Assert.That(((NumberedNode)resultingNodeList[i]).Value, Is.EqualTo(i));
            }
            Console.WriteLine(" === ");
        }
        [Test]
        public void TestMultiFrontInsertion()
        {
            Console.WriteLine("TestMultiFrontInsertion");
            INodeList firstNodeList = new NodeList(), secondNodeList = new NodeList();
            INodeList resultingNodeList = new NodeList();
            for (int i = 0; i < 8; i++)
            {
                (i >= 4 ? firstNodeList : secondNodeList).Add(new NumberedNode(i));
            }
            for (int i = 0; i < firstNodeList.Length; i++)
            {
                resultingNodeList.Add(firstNodeList[i]);
            }
            resultingNodeList.InsertAt(0, secondNodeList);
            foreach (INode node in resultingNodeList)
            {
                Console.WriteLine(node);
            }
            for (int i = 0; i < 8; ++i)
            {
                Assert.That(((NumberedNode)resultingNodeList[i]).Value, Is.EqualTo(i));
            }
            Console.WriteLine(" === ");
        }
        [Test]
        public void TestMultiBackInsertion()
        {
            Console.WriteLine("TestMultiBackInsertion");
            INodeList firstNodeList = new NodeList(), secondNodeList = new NodeList();
            INodeList resultingNodeList = new NodeList();
            for (int i = 0; i < 8; i++)
            {
                ( i < 4 ? firstNodeList : secondNodeList).Add(new NumberedNode(i));
            }
            for (int i = 0; i < firstNodeList.Length; i++)
            {
                resultingNodeList.Add(firstNodeList[i]);
            }
            resultingNodeList.InsertAt(4, secondNodeList);
            foreach (INode node in resultingNodeList)
            {
                Console.WriteLine(node);
            }
            for (int i = 0; i < 8; ++i)
            {
                Assert.That(((NumberedNode)resultingNodeList[i]).Value, Is.EqualTo(i));
            }
            Console.WriteLine(" === ");
        }

        DateTime startTime, latestPrint;

        [SetUp]
        public void TestSetup()
        {
            latestPrint = startTime = DateTime.Now;
        }

        [Theory]
        [Category("Performance")]
        public void PerformanceComparison()
        {
            INodeList nodeList;
            int testLenght = 100;
            DateTime start = DateTime.Now, insertTestEndTime, addTestEndTime;
            nodeList = new NodeList();
            for (int i = 0; i < 100; ++i)
            {
                nodeList.Add(new NumberedNode(i));
            }
        }

        [Test]
        [Category("Performance")]
        public void MaxAddTest()
        {
            PrintTimeStatistics();
            Console.WriteLine("Init MaxAddTest");
            int length = 10000;
            INodeList nodeList = new NodeList(), secondNodeList = new NodeList(), nodes = new NodeList();
            PrintTimeStatistics();
            Console.WriteLine("Init MaxAddTest baselist");
            for (int i = 0; i < length; ++i)
            {
                nodes.Add(new NumberedNode(i));
            }
            PrintTimeStatistics();
            Console.WriteLine("Do massadding single nodes at MaxAddTest");
            for (int i = 0; i < nodes.Length / 2; ++i)
            {
                nodeList.Add(nodes[i]);
                secondNodeList.Add(nodes[length / 2 + i]);
            }
            Assert.That(nodeList.Length, Is.EqualTo(length / 2));
            Assert.That(secondNodeList.Length, Is.EqualTo(length / 2));
            PrintTimeStatistics();
            Console.WriteLine("Test massadding single nodes at MaxAddTest");
            for (int i = 0; i < nodes.Length / 2; ++i)
            {
                Assert.That(nodeList[i], Is.EqualTo(nodes[i]));
                Assert.That(secondNodeList[i], Is.EqualTo(nodes[length / 2 + i]));
            }
            nodeList.Add(secondNodeList);
            Assert.That(nodeList.Length, Is.EqualTo(length));
            PrintTimeStatistics();
            Console.WriteLine("Test after merging all stuff MaxAddTest");
            for (int i = 0; i < nodes.Length; ++i)
            {
                Assert.That(nodeList[i], Is.EqualTo(nodes[i]));
            }
            PrintTimeStatistics();
        }

        private void PrintTimeStatistics()
        {
            Console.Write("Start[");
            Console.Write(startTime);
            Console.Write("]|Now[");
            Console.Write(DateTime.Now);
            Console.Write("]|Since Start[");
            Console.Write(DateTime.Now - startTime);
            Console.Write("]|Since Last Print[");
            Console.Write(latestPrint - startTime);
            latestPrint = DateTime.Now;
            Console.WriteLine("]|[END]");
        }
    }
}
#endif