#region  ******** Copyright © 2016 HauCore ********
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
#endregion  ******** Copyright © 2016 HauCore ********

namespace HauCore.Utility
{
    public class MemberInfoHelper 
    {
        public static TAttribute GetAttribute<TAttribute>(MemberInfo mi, bool inherit) where TAttribute : Attribute
        {
            var arr = mi.GetCustomAttributes(typeof(TAttribute), inherit);
            return arr.Length == 0 ? null : arr[0] as TAttribute;
        }

        public static List<TAttribute> GetAttributes<TAttribute>(MemberInfo mi, bool inherit) where TAttribute : Attribute
        {
            return mi.GetCustomAttributes(typeof(TAttribute), inherit).Cast<TAttribute>().ToList();
        }

        public static List<Pair<PropertyInfo, TAttribute>> GetListPairPropertyAttribute<TAttribute>(Type type, bool inherit) where TAttribute : Attribute
        {
            return type.GetProperties().Select(p => new Pair<PropertyInfo, TAttribute> { T1 = p, T2 = GetAttribute<TAttribute>(p, inherit) }).Where(pr => pr.T2 != null).ToList();
        }

        public static List<Pair<PropertyInfo, List<TAttribute>>> GetListPairPropertyListAttribute<TAttribute>(Type type, bool inherit) where TAttribute : Attribute
        {
            return type.GetProperties().Select(p => new Pair<PropertyInfo, List<TAttribute>> { T1 = p, T2 = GetAttributes<TAttribute>(p, inherit) }).Where(pr => pr.T2.Count != 0).ToList();
        }
    }
}
