using System;
using System.IO;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Test
{
    [TestClass]
    public class JsonTest
    {
        [TestMethod]
        public void JsonDeSerialize()
        {
            var original = new TestMe { AString = "a string", ADate = DateTime.Now };
            original.SubTestMe.AString = "a sub string";
            original.SubTestMe.ADate = DateTime.Now.AddDays(+1);
            var json = original.ToJson();


            var challenge = new TestMe();
            challenge.FromJson(new JsonTextReader(new StringReader(json)));

            Assert.AreEqual(original.AString, challenge.AString);
            Assert.AreEqual(original.ADate, challenge.ADate);
            Assert.AreEqual(original.SubTestMe.AString, challenge.SubTestMe.AString);
            Assert.AreEqual(original.SubTestMe.ADate, challenge.SubTestMe.ADate);
        }
    }
}
