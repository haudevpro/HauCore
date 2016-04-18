#region  ******** Copyright © 2016 HauCore ********
using HauCore.Attributes.Validators;
using HauCore.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
#endregion  ******** Copyright © 2016 HauCore ********

namespace HauCore.Utility
{
    public class Model<T> where T : new()
    {
        public static T Parse(Dictionary<string, object> dicValues, bool ignoreCase)
        {
            return New(t => t.Parse(dicValues, ignoreCase));
        }

        public static T ParseWithValidate(Dictionary<string, object> dicValues)
        {
            return New(t =>
            {
                var vm = t.Validate(dicValues);
                if (!vm.IsValid) throw new ValidatorException(vm);
                t.Parse(dicValues, false);
            });
        }

        public static T ParseWithValidate(NameValueCollection values)
        {
            return ParseWithValidate(values.ToDic());
        }

        public static T Parse(NameValueCollection values, bool ignoreCase)
        {
            return New(t => t.Parse(values, ignoreCase));
        }

        public static T Parse(DataRow dr, bool ignoreCase)
        {
            return New(t => t.Parse(dr, ignoreCase));
        }

        public static List<T> ParseToList(DataTable table, bool ignoreCase, Action<T> action = null)
        {
            return Cast(table, ignoreCase, action).ToList();
        }

        public static IEnumerable<T> Cast(DataTable table, bool ignoreCase, Action<T> action = null)
        {
            return table.AsEnumerable().Select(dr =>
            {
                var t = Parse(dr, ignoreCase);
                if (action != null) action(t);
                return t;
            });
        }

        public static T New(Action<T> func = null)
        {
            T t = new T();
            if (func != null) func(t);
            return t;
        }
    }
}
