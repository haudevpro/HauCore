#region  ******** Copyright © 2016 HauCore ********
using HauCore.Utility;
using System;
using System.Collections.Generic;
using System.Reflection;
#endregion  ******** Copyright © 2016 HauCore ********

namespace HauCore.Reflectors
{
    public class ReflectTypeListPropertyWithAttribute<TAttribute> : DictionaryCacheBase<Type, List<Pair<PropertyInfo, TAttribute>>, ReflectTypeListPropertyWithAttribute<TAttribute>> where TAttribute : Attribute
    {
        protected override List<Pair<PropertyInfo, TAttribute>> GetValueForDic(Type key)
        {
            return MemberInfoHelper.GetListPairPropertyAttribute<TAttribute>(key, true);
        }
    }
}
