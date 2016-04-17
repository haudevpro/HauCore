using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HauCore.Types;
using HauCore.Extensions;

namespace HauCore.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string value = "1234";
            var to = value.To<int>();
        }
    }
}
