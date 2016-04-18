#region  ******** Copyright © 2016 HauCore ********
using System.Collections.Generic;
using System.Collections.Specialized;
#endregion  ******** Copyright © 2016 HauCore ********

namespace HauCore.Extensions
{
    public static class NameValueCollectionExtension
    {
        /// <summary>
        /// Convert NameValueCollection thành Dictionary<string, object>
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static Dictionary<string, object> ToDic(this NameValueCollection values)
        {
            var dic = new Dictionary<string, object>();
            // Điền dữ liệu vào Dictionary
            for (int i = 0; i < values.AllKeys.Length; i++)
            {
                if (values.AllKeys[i].IsNull()) continue;
                dic[values.AllKeys[i]] = values[values.AllKeys[i]];
            }
            return dic;
        }
    }
}
