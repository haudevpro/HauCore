#region  ******** Copyright © 2016 HauCore ********
using HauCore.Reflectors;
using HauCore.Utility;
using System;
using System.Collections.Generic;
using System.Reflection;
#endregion  ******** Copyright © 2016 HauCore ********

namespace HauCore.Extensions
{
    /// <summary>
    /// Phương thức mở rộng cho Type
    /// </summary>
    public static class TypeExtension
    {
        /// <summary>
        /// Lấy ra danh sách PropertyInfo của một type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static List<PropertyInfo> GetListProperties(this Type type)
        {
            return ReflectTypeListProperty.Inst[type];
        }
        public static List<Pair<PropertyInfo, TAttribute>> GetListPairPropertyAttribute<TAttribute>(this Type type) where TAttribute : Attribute
        {
            return  ReflectTypeListPropertyWithAttribute<TAttribute>.Inst[type];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public static List<Pair<PropertyInfo, List<TAttribute>>> GetListPairPropertyListAttribute<TAttribute>(this Type type) where TAttribute : Attribute
        {
            return ReflectTypeListPropertyWithListAttribute<TAttribute>.Inst[type];
        }
    }
}
