using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using HauCore.Extensions;

namespace HauCore.Test
{
    [TestClass]
    public class UnitTestParse
    {
        [TestMethod]
        public void TestMethod1()
        {
            DataTable dt= new DataTable();
            dt.Columns.Add("Id",typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Alo", typeof(string));
            for(int i = 0; i < 10; i++)
            {
                dt.Rows.Add(i, "Số "+i.To<string>(), "Địa chỉ "+(i*10).To<string>());
            }
            var DataList = dt.ToList<DataTesst>();
        }
    }
    public class DataTesst
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Alo { get; set; }
    }
}
