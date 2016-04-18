#region  ******** Copyright © 2016 HauCore ********
using HauCore.Attributes;
using System;
#endregion  ******** Copyright © 2016 HauCore ********

namespace HauCore.Types
{
    public class TypeCodeOfAttribute:FieldInfoAttribute
    {
        private Type type = null;
        /// <summary>
        /// 
        /// </summary>
        public Type Type
        {
            get { return type; }
        }
        public TypeCodeOfAttribute(Type type)
        {
            this.type = type;
        }

    }
}
