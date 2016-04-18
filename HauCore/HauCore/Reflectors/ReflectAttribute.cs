#region  ******** Copyright © 2016 HauCore ********
using HauCore.Utility;
using System;
using System.Reflection;
#endregion  ******** Copyright © 2016 HauCore ********

namespace HauCore.Reflectors
{
    /// <summary>
    /// ReflectAttribute
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TAttribute"></typeparam>
    public class ReflectAttribute<TKey, TAttribute> : DictionaryCacheBase<TKey, TAttribute, ReflectAttribute<TKey, TAttribute>>
        where TKey : MemberInfo
        where TAttribute : Attribute
    {
        /// <summary>
        /// GetAttribute
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected override TAttribute GetValueForDic(TKey key)
        {
            return MemberInfoHelper.GetAttribute<TAttribute>(key, true);
        }
    }
}
