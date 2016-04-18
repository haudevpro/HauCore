#region  ******** Copyright © 2016 HauCore ********
using HauCore.Utility;
using System;
using System.Collections.Generic;
using System.Reflection;
#endregion  ******** Copyright © 2016 HauCore ********

namespace HauCore.Reflectors
{
    /// <summary>
    /// Reflect để lấy xem property có list Attribute gì
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TAttribute"></typeparam>
    public class ReflectListAttribute<TKey, TAttribute> : DictionaryCacheBase<TKey, List<TAttribute>, ReflectListAttribute<TKey, TAttribute>>
        where TKey : MemberInfo
        where TAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected override List<TAttribute> GetValueForDic(TKey key)
        {
            return MemberInfoHelper.GetAttributes<TAttribute>(key, true);
        }
    }
}
