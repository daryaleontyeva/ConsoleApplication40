using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HashTable;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var hashtable = new HashTable(3);
            hashtable.PutPair("key1", "value1");
            hashtable.PutPair("key2", "value2");
            hashtable.PutPair("3", "value3");

            var value = hashtable.GetValueByKey("key1");
            Assert.IsTrue("value1" == (string)value);
            value = hashtable.GetValueByKey("key2");
            Assert.IsTrue("value2" == (string)value);
            value = hashtable.GetValueByKey("3");
            Assert.IsTrue("value3" == (string)value);

        }
        [TestMethod]
        public void TestMethod2()
        {
            var hashtable = new HashTable(3);
            hashtable.PutPair("key1", "value1");
            hashtable.PutPair("key1", "value2");


            var value = hashtable.GetValueByKey("key1");
            Assert.AreEqual((string)value, "value2");

        }
        [TestMethod]
        public void TestMethod3()
        {
            var hashtable = new HashTable(10000);
            for (int i = 0; i < 10000; i++)
            {
                hashtable.PutPair("key" + i, "value" + i);
            }
            var value = hashtable.GetValueByKey("key8888");
            Assert.AreEqual((string)value, "value8888");

        }
        [TestMethod]
        public void TestMethod4()
        {
            var hashtable = new HashTable(10000);
            for (int i = 0; i < 10000; i++)
            {
                hashtable.PutPair("key" + i, "value" + i);
            }
            for (int i = 0; i < 1000; i++)
            {
                Assert.AreEqual(hashtable.GetValueByKey(i), null);
            }


        }
    }
}
