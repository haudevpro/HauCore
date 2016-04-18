#region  ******** Copyright © 2016 HauCore ********
using System;
using System.Reflection;
#endregion  ******** Copyright © 2016 HauCore ********

namespace HauCore.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class FieldInfoAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public FieldInfo FieldInfo { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public object RawValue { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public object FieldValue { set; get; }

        /// <summary>
        /// Tên
        /// </summary>
        public string Name { set; get; }
    }
}
