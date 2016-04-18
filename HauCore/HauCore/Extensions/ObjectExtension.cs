#region  ******** Copyright © 2016 HauCore ********
using HauCore.Types;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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

        public static bool Is<T>(this object obj)
        {
            return obj is T;
        }

        /// <summary>
        /// Cast object dang list ra list object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static List<object> CastToList(this object obj)
        {
            if (obj.Is<string>()) return null;

            // Nếu là IListSource 
            if (obj.Is<IListSource>()) return obj.As<IListSource>().GetList().Cast<object>().ToList();

            // Nếu là IEnumerable thì lấy object
            if (obj.Is<IEnumerable>()) return obj.As<IEnumerable>().Cast<object>().ToList();

            // mặc định là return null
            return null;
        }

        public static bool IsNull(this object obj)
        {
            return obj == null;
        }

        public static bool IsNotNull(this object obj)
        {
            return obj != null;
        }

        public static T As<T>(this object obj)
        {
            return obj.IsNull() ? default(T) : (T)obj;
        }

        /// <summary>
        /// Hàm thiết lập giá trị cho propertyName của đối tượng mà không có validate
        /// Chỉ dùng khi chắc chắn propertyName là có và value là giá trị gán được
        /// </summary>
        public static void SetValueToProperty(this object obj, string propertyName, object value)
        {
            obj.GetType().GetProperty(propertyName).SetValue(obj, value, null);
        }

        public static T WhenNull<T>(this T t, Func<T> action)
        {
            return t.IsNull() ? action() : t;
        }

        public static T WhenValue<T>(this T t, T when, Func<T> action)
        {
            return t.Equals(when) ? action() : t;
        }

        public static TResult WhenNotNull<T, TResult>(this T t, Func<T, TResult> action)
        {
            return t.IsNotNull() ? action(t) : default(TResult);
        }

    }
}
