/*
 * Gemaakt met SharpDevelop.
 * Gebruiker: 8008
 * Datum: 4-2-2009
 * Tijd: 14:30
 * 
 * Dit sjabloon wijzigen: Extra | Opties |Coderen | Standaard kop bewerken.
 */
#if DEBUG
using NUnit.Framework;
using System;
using TreeCore;

namespace TreeCore.Debug
{
    [TestFixture]
    public class LinkedListNodeTest
    {
        [Test]
        [Category("LinkedListNode")]
        public void TestCreation()
        {
            LinkedListNode<int> subject = new LinkedListNode<int>(0);
            Assert.That(subject.Length, Is.EqualTo(1));
        }

        [Test]
        [Category("LinkedListNode")]
        public void TestSingleAdd()
        {
            LinkedListNode<int> subject = new LinkedListNode<int>(1);
            subject.Append(new LinkedListNode<int>(2));
            Assert.That(subject.Value, Is.EqualTo(1));
            Assert.That(subject.Next.Value, Is.EqualTo(2));
        }

        [Test]
        [Category("LinkedListNode")]
        public void TestMultiAdd()
        {
            LinkedListNode<int> subject = new LinkedListNode<int>(5);
            for (int i = 1; i <= 4; i++)
            {
                subject.Append(new LinkedListNode<int>(i));
            }
            LinkedListNode<int> current = subject;
            for (int i = current.Length; i > 0; i--)
            {
                Assert.That(current.Value, Is.EqualTo(i));
                current = current.Next;
            }
        }
        [Test]
        [Category("LinkedListNode")]
        public void TestHugeMultiCreation()
        {
            LinkedListNode<int> subject = new LinkedListNode<int>(100);
            for (int i = 1; i < 100; i++)
            {
                subject.Append(new LinkedListNode<int>(i));
            }
            LinkedListNode<int> current = subject;
            for (int i = current.Length; i > 0; i--)
            {
                Assert.That(current.Value, Is.EqualTo(i));
                current = current.Next;
            }
        }
        [Test]
        [Category("LinkedListNode")]
        public void TestMergeSingles()
        {
            LinkedListNode<int> subject = new LinkedListNode<int>(1);
            LinkedListNode<int> mergable = new LinkedListNode<int>(2);
            subject.Append(mergable);
            Assert.That(subject.Value, Is.EqualTo(1));
            Assert.That(subject.Next.Value, Is.EqualTo(2));
            Assert.That(subject.Next.Next.Value, Is.EqualTo(1));
            Assert.That(subject.Next.Next.Next.Value, Is.EqualTo(2));
        }
        [Test]
        [Category("LinkedListNode")]
        public void TestMergeHybrid()
        {
            LinkedListNode<int> subject = new LinkedListNode<int>(6);
            LinkedListNode<int> mergable = new LinkedListNode<int>(5);         
            for (int i = 1; i <= 4; i++)
            {
                mergable.Append(new LinkedListNode<int>(i));
            }
            subject.Append(mergable);
            LinkedListNode<int> current = subject;
            for (int i = current.Length; i > 0; i--)
            {
                Assert.That(current.Value, Is.EqualTo(i));
                current = current.Next;
            }
        }
        [Test]
        [Category("LinkedListNode")]
        public void TestMergeRings()
        {
            LinkedListNode<int> subject = new LinkedListNode<int>(10);
            for (int i = 1; i <= 4; i++)
            {
                subject.Append(new LinkedListNode<int>(i));
            }
            LinkedListNode<int> mergable = new LinkedListNode<int>(9);
            for (int i = 5; i <= 8; i++)
            {
                mergable.Append(new LinkedListNode<int>(i));
            }
            subject.Append(mergable);
            LinkedListNode<int> current = subject;
            for (int i = current.Length; i > 0; i--)
            {
                Assert.That(current.Value, Is.EqualTo(i));
                current = current.Next;
            }
        }
        [Test]
        [Category("LinkedListNode")]
        public void TestJump()
        {
            LinkedListNode<int> subject = new LinkedListNode<int>(5);
            for (int i = 1; i <= 4; i++)
            {
                subject.Append(new LinkedListNode<int>(i));
            }
            Assert.That(subject.Jump((int)subject.Length).Value, Is.EqualTo(subject.Jump(-2).Jump(2).Value));
        }

        #region Split
        [Test]
        [Category("LinkedListNode")]
        public void TestSplitZero()
        {
            LinkedListNode<uint> subject = new LinkedListNode<uint>(6);
            for (uint i = 8; i > 1; i--)
            {
                subject.Append(new LinkedListNode<uint>(i));
            }
            LinkedListNode<uint> splitted = subject.Split(0);
            Assert.That(subject.Length, Is.EqualTo(1));
            Assert.That(splitted.Length, Is.EqualTo(7));
        }
        [Test]
        [Category("LinkedListNode")]
        public void TestSplitMiddle()
        {
            LinkedListNode<uint> subject = new LinkedListNode<uint>(1);
            for (uint i = 8; i > 1; i--)
            {
                subject.Append(new LinkedListNode<uint>(i));
            }
            LinkedListNode<uint> splitted = subject.Split(3);
            Assert.That(subject.Length, Is.EqualTo(4));
            Assert.That(splitted.Length, Is.EqualTo(4));
        }
        [Test]
        [Category("LinkedListNode")]
        public void TestSplitEnd()
        {
            LinkedListNode<uint> subject = new LinkedListNode<uint>(6);
            for (uint i = 8; i > 1; i--)
            {
                subject.Append(new LinkedListNode<uint>(i));
            }
            LinkedListNode<uint> splitted = subject.Split(7);
            Assert.That(subject.Length, Is.EqualTo(8));
            Assert.That(splitted.Length, Is.EqualTo(8));
        }
        [Test]
        [Category("LinkedListNode")]
        public void TestSplitLenght()
        {
            LinkedListNode<uint> subject = new LinkedListNode<uint>(6);
            for (uint i = 8; i > 1; i--)
            {
                subject.Append(new LinkedListNode<uint>(i));
            }
            LinkedListNode<uint> splitted = subject.Split((int)subject.Length);
            Assert.That(subject.Length, Is.EqualTo(1));
            Assert.That(splitted.Length, Is.EqualTo(7));
        }

        internal String PrintValues<T>(LinkedListNode<T> subject)
        {
            String result = "\"Values: [";
            for (uint i = 0; i < subject.Length; i++)
            {
                result += subject.ToString();
                subject = subject.Next;
            }
            return result + "]\"" + Environment.NewLine + "\tNtP: ["
                + subject.Next.ToString() + " | "
                + subject.ToString() + " | "
                + subject.Previous.ToString() + " ] ";
        }
        #endregion
        internal String PrintValues<T>(LinkedListNode<T> subject, String name)
        {
            String result = "\"Values of " + name + ": [";
            for (int i = 0; i < subject.Length; i++)
            {
                result += subject.ToString();
                subject = subject.Next;
            }
            return result + "]\"" + Environment.NewLine + "\tNtP: ["
                + subject.Next.ToString() + " | "
                + subject.ToString() + " | "
                + subject.Previous.ToString() + " ] ";
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
#endif