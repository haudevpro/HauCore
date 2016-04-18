#region  ******** Copyright © 2016 HauCore ********
using HauCore.Utility;
using System;
using System.Collections.Generic;
using System.Data;
#endregion  ******** Copyright © 2016 HauCore ********

namespace HauCore.Extensions
{
    /// <summary>
    /// Phương thức mở rộng cho DataTable
    /// </summary>
    public static class DataTableExtension
    {
        /// <summary>
        /// Convert ToList
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static List<T> ToList<T>(this DataTable table, bool ignoreCase = false, Action<T> action = null) where T : new()
        {
            return Model<T>.ParseToList(table, ignoreCase, action);
        }

        /// <summary>
        /// Cast to IEnumerable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <param name="ignoreCase"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static IEnumerable<T> Cast<T>(this DataTable table, bool ignoreCase, Action<T> action = null) where T : new()
        {
            return Model<T>.Cast(table, ignoreCase, action);
        }

        /// <summary>
        /// Convert Item với row đầu tiên
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static T GetFirstItem<T>(this DataTable table, bool ignoreCase) where T : class, new()
        {
            return table.Rows.Count == 0 ? null : Model<T>.Parse(table.Rows[0], ignoreCase);
        }
    }
}
