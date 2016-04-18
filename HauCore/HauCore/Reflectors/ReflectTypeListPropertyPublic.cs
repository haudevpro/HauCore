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
    /// Type với các property public
    /// </summary
    public class ReflectTypeListPropertyPublic : DictionaryCacheBase<Type, List<PropertyInfo>, ReflectTypeListPropertyPublic>
    {
        /// <summary>
        /// Lấy các thuộc tính public
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected override List<PropertyInfo> GetValueForDic(Type key)
        {
            return key.GetProperties(BindingFlags.Public | BindingFlags.Instance).ToList();
        }
    }
}
