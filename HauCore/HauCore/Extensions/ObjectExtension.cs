#region  ******** Copyright © 2016 HauCore ********
using HauCore.Types;
#endregion  ******** Copyright © 2016 HauCore ********

namespace HauCore.Extensions
{
    /// <summary>
    /// Cung cấp phương thức mở rộng cho đối các đối tượng
    /// </summary>
    public static class ObjectExtension
    {
        /// <summary>
        /// Chuyển đổi dữ liệu cho một đối tượng
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="default"></param>
        /// <returns></returns>
        public static T To<T>(this object obj, T @default)
        {
            // Nếu bằng null thì return default
            if (obj == null) return @default;

            // Lấy ra Converter của T
            var convert = HauType.GetConverter(typeof(T));

            // Thực hiện Convert
            return convert.CanConvertFrom(obj.GetType()) ? (T)convert.ConvertFrom(obj) : @default;
        }

        /// <summary>
        /// Convert đối tượng sang kiểu khác
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T To<T>(this object obj)
        {
            return obj.To<T>(default(T));
        }
    }
}
