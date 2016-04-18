#region  ******** Copyright © 2016 HauCore ********
using HauCore.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
#endregion  ******** Copyright © 2016 HauCore ********

namespace HauCore.Reflectors
{
    /// <summary>
    /// Reflect để lấy được danh sách PropertyInfo của một Type
    /// </summary>
    public class ReflectTypeListProperty : DictionaryCacheBase<Type, List<PropertyInfo>, ReflectTypeListProperty>
    {
        protected override List<PropertyInfo> GetValueForDic(Type key)
        {
            return key.GetProperties().ToList();
        }
    }
}
