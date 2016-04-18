#region  ******** Copyright © 2016 HauCore ********
using System;
#endregion  ******** Copyright © 2016 HauCore ********

namespace HauCore.Types
{
    /// <summary>
    /// Type code định nghĩa
    /// </summary>
    [Flags]
    public enum HTypeCode
    {
        [TypeCodeOf(typeof(int))]
        Int32,

        [TypeCodeOf(typeof(long))]
        Int64,

        [TypeCodeOf(typeof(string))]
        String,

        [TypeCodeOf(typeof(decimal))]
        Decimal,

        [TypeCodeOf(typeof(bool))]
        Boolean,

        [TypeCodeOf(typeof(DateTime))]
        DateTime,

        [TypeCodeOf(typeof(TimeSpan))]
        TimeSpan,

        [TypeCodeOf(typeof(byte))]
        Byte,

        [TypeCodeOf(typeof(double))]
        Double,

        [TypeCodeOf(typeof(Guid))]
        Guid,

        [TypeCodeOf(typeof(short))]
        Int16,

        [TypeCodeOf(typeof(float))]
        Single,

        [TypeCodeOf(typeof(DBNull))]
        DBNull,

        UnKnown
    }
    /// <summary>
    /// Mở rộng phương thức cho TypeCode
    /// </summary>
    public static class HTypeCodeExtender
    {
        /// <summary>
        /// Kiểm tra xem Type Code có hợp lệ, có nằm trong list Type Code cần check
        /// </summary>
        /// <param name="typeCode"></param>
        /// <param name="typeCodeChecking"></param>
        /// <returns></returns>
        public static bool IsSet(this HTypeCode typeCode, HTypeCode typeCodeChecking)
        {
            return (typeCode & typeCodeChecking) == typeCodeChecking;
        }
    }
}
