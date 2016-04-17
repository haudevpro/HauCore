using System;

namespace HauCore.Types
{
    /// <summary>
    /// Mở rộng phương thức cho TypeCode
    /// </summary>
    public static class TypeCodeExtender
        {
            /// <summary>
            /// Kiểm tra xem Type Code có hợp lệ, có nằm trong list Type Code cần check
            /// </summary>
            /// <param name="typeCode"></param>
            /// <param name="typeCodeChecking"></param>
            /// <returns></returns>
            public static bool IsSet(this TypeCode typeCode, TypeCode typeCodeChecking)
            {
                return (typeCode & typeCodeChecking) == typeCodeChecking;
            }
        }
}
