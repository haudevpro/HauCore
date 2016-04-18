#region  ******** Copyright © 2016 HauCore ********
using HauCore.Reflectors;
using System;
using System.Collections.Generic;
using System.Reflection;
#endregion  ******** Copyright © 2016 HauCore ********

namespace HauCore.Extensions
{
    /// <summary>
    /// Phương thức mở rộng cho MemberInfoExtension
    /// </summary>
    public static class MemberInfoExtension
    {
        /// <summary>
        /// Lấy Attribute
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="mi"></param>
        /// <returns></returns>
        public static TAttribute GetAttribute<TAttribute>(this MemberInfo mi, bool isCache = true) where TAttribute : Attribute
        {
            if (isCache) return ReflectAttribute<MemberInfo, TAttribute>.Inst[mi];

            else
            {
                // Lấy ra attributes
                var attr = mi.GetCustomAttributes(typeof(TAttribute), true);

                // return kết quả
                return attr.Length > 0 ? attr[0].As<TAttribute>() : null;
            }
        }

        /// <summary>
        /// Lấy List Attributes
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="mi"></param>
        /// <returns></returns>
        public static List<TAttribute> GetAttributes<TAttribute>(this MemberInfo mi) where TAttribute : Attribute
        {
            return ReflectListAttribute<MemberInfo, TAttribute>.Inst[mi];
        }
    }
}
