#region  ******** Copyright © 2016 HauCore ********
using HauCore.Utility;
using System;
using System.Collections.Generic;
using System.Reflection;
#endregion  ******** Copyright © 2016 HauCore ********

namespace HauCore.Reflectors
{
    public class ReflectTypeListPropertyWithListAttribute<TAttribute> : DictionaryCacheBase<Type, List<Pair<PropertyInfo, List<TAttribute>>>, ReflectTypeListPropertyWithListAttribute<TAttribute>> where TAttribute : Attribute
    {
        protected override List<Pair<PropertyInfo, List<TAttribute>>> GetValueForDic(Type key)
        {
            return MemberInfoHelper.GetListPairPropertyListAttribute<TAttribute>(key, true);
        }
    }
}
