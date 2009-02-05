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
using NUnit.Framework.SyntaxHelpers;
using System;
using TreeCore;

namespace TreeTest
{
    [TestFixture]
    public class LinkedListNodeTest
    {
        [Test]
        [Category("LinkedListNode")]
        public void TestCreation()
        {
            LinkedListNode<uint> subject = new LinkedListNode<uint>(0);
            Assert.That(subject.Lenght, Is.EqualTo(1));
        }

        [Test]
        [Category("LinkedListNode")]
        public void TestSingleAdd()
        {
            LinkedListNode<uint> subject = new LinkedListNode<uint>(1);
            subject.Append(new LinkedListNode<uint>(2));
            Assert.That(subject.Value, Is.EqualTo(1));
            Assert.That(subject.Next.Value, Is.EqualTo(2));
        }

        [Test]
        [Category("LinkedListNode")]
        public void TestMultiAdd()
        {
            LinkedListNode<uint> subject = new LinkedListNode<uint>(5);
            for (uint i = 1; i <= 4; i++)
            {
                subject.Append(new LinkedListNode<uint>(i));
            }
            LinkedListNode<uint> current = subject;
            for (uint i = current.Lenght; i > 0; i--)
            {
                Assert.That(current.Value, Is.EqualTo(i));
                current = current.Next;
            }
        }
        [Test]
        [Category("LinkedListNode")]
        public void TestHugeMultiCreation()
        {
            LinkedListNode<uint> subject = new LinkedListNode<uint>(100);
            for (uint i = 1; i < 100; i++)
            {
                subject.Append(new LinkedListNode<uint>(i));
            }
            LinkedListNode<uint> current = subject;
            for (uint i = current.Lenght; i > 0; i--)
            {
                Assert.That(current.Value, Is.EqualTo(i));
                current = current.Next;
            }
        }
        [Test]
        [Category("LinkedListNode")]
        public void TestMergeSingles()
        {
            LinkedListNode<uint> subject = new LinkedListNode<uint>(1);
            LinkedListNode<uint> mergable = new LinkedListNode<uint>(2);
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
            LinkedListNode<uint> subject = new LinkedListNode<uint>(6);
            LinkedListNode<uint> mergable = new LinkedListNode<uint>(5);         
            for (uint i = 1; i <= 4; i++)
            {
                mergable.Append(new LinkedListNode<uint>(i));
            }
            subject.Append(mergable);
            LinkedListNode<uint> current = subject;
            for (uint i = current.Lenght; i > 0; i--)
            {
                Assert.That(current.Value, Is.EqualTo(i));
                current = current.Next;
            }
        }
        [Test]
        [Category("LinkedListNode")]
        public void TestMergeRings()
        {
            LinkedListNode<uint> subject = new LinkedListNode<uint>(10);
            for (uint i = 1; i <= 4; i++)
            {
                subject.Append(new LinkedListNode<uint>(i));
            }
            LinkedListNode<uint> mergable = new LinkedListNode<uint>(9);
            for (uint i = 5; i <= 8; i++)
            {
                mergable.Append(new LinkedListNode<uint>(i));
            }
            subject.Append(mergable);
            LinkedListNode<uint> current = subject;
            for (uint i = current.Lenght; i > 0; i--)
            {
                Assert.That(current.Value, Is.EqualTo(i));
                current = current.Next;
            }
        }
        [Test]
        [Category("LinkedListNode")]
        public void TestJump()
        {
            LinkedListNode<uint> subject = new LinkedListNode<uint>(5);
            for (uint i = 1; i <= 4; i++)
            {
                subject.Append(new LinkedListNode<uint>(i));
            }
            Assert.That(subject.Jump((int)subject.Lenght).Value, Is.EqualTo(subject.Jump(-2).Jump(2).Value));
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
            Assert.That(subject.Lenght, Is.EqualTo(1));
            Assert.That(splitted.Lenght, Is.EqualTo(7));
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
            Assert.That(subject.Lenght, Is.EqualTo(4));
            Assert.That(splitted.Lenght, Is.EqualTo(4));
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
            Assert.That(subject.Lenght, Is.EqualTo(8));
            Assert.That(splitted.Lenght, Is.EqualTo(8));
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
            LinkedListNode<uint> splitted = subject.Split((int)subject.Lenght);
            Assert.That(subject.Lenght, Is.EqualTo(1));
            Assert.That(splitted.Lenght, Is.EqualTo(7));
        }

        public String PrintValues<T>(LinkedListNode<T> subject)
        {
            String result = "\"Values: [";
            for (uint i = 0; i < subject.Lenght; i++)
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
        public String PrintValues<T>(LinkedListNode<T> subject, String name)
        {
            String result = "\"Values of " + name + ": [";
            for (uint i = 0; i < subject.Lenght; i++)
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