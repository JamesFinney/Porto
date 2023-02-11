using Porto.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Porto.Tests
{
    [TestFixture]
    public class EnvironmentVariableParserTests
    {
        [TearDown] 
        public void TearDown()
        {
            Environment.SetEnvironmentVariable("BoolVariable", null);
            Environment.SetEnvironmentVariable("ByteVariable", null);
            Environment.SetEnvironmentVariable("SByteVariable", null);
            Environment.SetEnvironmentVariable("CharVariable", null);
            Environment.SetEnvironmentVariable("DecimalVariable", null);
            Environment.SetEnvironmentVariable("DoubleVariable", null);
            Environment.SetEnvironmentVariable("FloatVariable", null);
            Environment.SetEnvironmentVariable("IntVariable", null);
            Environment.SetEnvironmentVariable("UintVariable", null);
            Environment.SetEnvironmentVariable("LongVariable", null);
            Environment.SetEnvironmentVariable("UlongVariable", null);
            Environment.SetEnvironmentVariable("ShortVariable", null);
            Environment.SetEnvironmentVariable("UshortVariable", null);
            Environment.SetEnvironmentVariable("StringVariable", null);
            Environment.SetEnvironmentVariable("ListStringVariable", null);
            Environment.SetEnvironmentVariable("ArrayStringVariable", null);
        }
        
        [Test]
        public void data_types_test()
        {
            // Arrange 
            Environment.SetEnvironmentVariable("BoolVariable", "true");
            Environment.SetEnvironmentVariable("ByteVariable", "42");
            Environment.SetEnvironmentVariable("SByteVariable", "24");
            Environment.SetEnvironmentVariable("CharVariable", "C");
            Environment.SetEnvironmentVariable("DecimalVariable", "1.234");
            Environment.SetEnvironmentVariable("DoubleVariable", "2.345");
            Environment.SetEnvironmentVariable("FloatVariable", "3.456");
            Environment.SetEnvironmentVariable("IntVariable", "123");
            Environment.SetEnvironmentVariable("UintVariable", "234");
            Environment.SetEnvironmentVariable("LongVariable", "123456789");
            Environment.SetEnvironmentVariable("UlongVariable", "123456789");
            Environment.SetEnvironmentVariable("ShortVariable", "123");
            Environment.SetEnvironmentVariable("UshortVariable", "234"); 
            Environment.SetEnvironmentVariable("StringVariable", "This is a test string");
            Environment.SetEnvironmentVariable("ListStringVariable", "A,B,C");
            Environment.SetEnvironmentVariable("ArrayStringVariable", "D,E,F");

            // Act 
            var parsed = EnvironmentVariableParser.Parse<TestClass>();

            // Assert
            Assert.That(parsed, Is.Not.Null);
            Assert.That(parsed.BoolVariable, Is.True);
            Assert.That(parsed.ByteVariable, Is.EqualTo(42));

            Assert.That(parsed.SByteVariable, Is.EqualTo(24));
            Assert.That(parsed.CharVariable, Is.EqualTo('C'));
            Assert.That(parsed.DecimalVariable, Is.EqualTo(1.234m));
            Assert.That(parsed.DoubleVariable, Is.EqualTo(2.345));
            Assert.That(parsed.FloatVariable, Is.EqualTo(3.456f));       // parsing number as decimal
            Assert.That(parsed.IntVariable, Is.EqualTo(123));
            Assert.That(parsed.UintVariable, Is.EqualTo(234u));
            Assert.That(parsed.LongVariable, Is.EqualTo(123456789L));
            Assert.That(parsed.UlongVariable, Is.EqualTo(123456789UL));
            Assert.That(parsed.ShortVariable, Is.EqualTo(123));
            Assert.That(parsed.UshortVariable, Is.EqualTo(234));
            Assert.That(parsed.StringVariable, Is.EqualTo("This is a test string"));
            CollectionAssert.AreEqual(new List<string> { "A", "B", "C" }, parsed.ListStringVariable);
            CollectionAssert.AreEqual(new string[] { "D", "E", "F" }, parsed.ArrayStringVariable);
        }

        [Test]
        public void throws_when_mandatory_environment_vars_not_set()
        {
            // Arrange 
            Environment.SetEnvironmentVariable("BoolVariable", "true");

            // Act / Assert
            Assert.Throws<Exception>(() => EnvironmentVariableParser.Parse<TestClass>());
        }
    }

    public class TestClass
    {
        [EnvironmentVariable("BoolVariable")]
        public bool BoolVariable { get; set; }

        [EnvironmentVariable("ByteVariable")]
        public byte ByteVariable { get; set; }

        [EnvironmentVariable("SByteVariable")]
        public sbyte SByteVariable { get; set; }

        [EnvironmentVariable("CharVariable")]
        public char CharVariable { get; set; }

        [EnvironmentVariable("DecimalVariable")]
        public decimal DecimalVariable { get; set; }

        [EnvironmentVariable("DoubleVariable")]
        public double DoubleVariable { get; set; }

        [EnvironmentVariable("FloatVariable")]
        public float FloatVariable { get; set; }

        [EnvironmentVariable("IntVariable")]
        public int IntVariable { get; set; }

        [EnvironmentVariable("UintVariable")]
        public uint UintVariable { get; set; }

        [EnvironmentVariable("LongVariable")]
        public long LongVariable { get; set; }

        [EnvironmentVariable("UlongVariable")]
        public ulong UlongVariable { get; set; }

        [EnvironmentVariable("ShortVariable")]
        public short ShortVariable { get; set; }

        [EnvironmentVariable("UshortVariable")]
        public ushort UshortVariable { get; set; }

        [EnvironmentVariable("StringVariable")]
        public string StringVariable { get; set; }

        [EnvironmentVariable("ListStringVariable")]
        public List<string> ListStringVariable { get; set; }

        [EnvironmentVariable("ArrayStringVariable")]
        public string[] ArrayStringVariable { get; set; }
    }
}
