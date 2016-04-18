#region  ******** Copyright © 2016 HauCore ********
using System;
using System.Text.RegularExpressions;
#endregion  ******** Copyright © 2016 HauCore ********

namespace HauCore.Extensions
{
    public static class StringExtension
    {
        public static string Frmat(this string str, params object[] @params)
        {
            return string.Format(str, @params);
        }

        public static bool IsNull(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        public static bool IsNotNull(this string str)
        {
            return !string.IsNullOrEmpty(str);
        }

        public static string WhenEmpty(this string str, Func<string> action)
        {
            return str.IsNull() ? action() : str;
        }

        public static string WhenEmpty(this string str, string whenEmpty)
        {
            return str.WhenEmpty(() => whenEmpty);
        }
        public static string GetOnlyDigital(this string str)
        {
            return Regex.Replace(str, @"[^\d]", string.Empty);
        }

    }
}
