using keysProject;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            Program.InitializeDataStore();
            Program.InitializeTypeStore();
        }

        [Test]
        public void Test1()
        {
            var key = "Delhi";
            var attributeList = new Dictionary<AttributeKey, string>();
            Program.dataStore.Add(key, attributeList);

            Program.HandleAddAttributeCase(key, "pollution", "very high");
            Program.HandleAddAttributeCase(key, "population", "100000");

            Assert.IsTrue(Program.dataStore.Count == 1);
            Assert.IsTrue(Program.dataStore[key].Count == 2);

            Assert.Pass();
        }
    }
}