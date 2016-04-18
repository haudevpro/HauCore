#region  ******** Copyright © 2016 HauCore ********
using HauCore.Attributes.Validators;
using HauCore.Types;
using HauCore.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
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
        /// <summary>
        /// Phân tích giá trị thuộc tính cho đối tượng
        /// </summary>
        public static void Parse(this object obj, NameValueCollection values, bool ignoreCase)
        {
            obj.Parse(values.ToDic(), ignoreCase);
        }

        /// <summary>
        /// Phân tích giá trị thuộc tính cho đối tượng
        /// </summary>
        public static void Parse(this object obj, DataRow dr, bool ignoreCase)
        {
            // Dùng dic để lưu các giá trị
            var dic = new Dictionary<string, object>();

            // Duyệt qua từng Column
            dr.Table.Columns.Cast<DataColumn>().ToList().ForEach(c => dic[c.ColumnName] = dr[c]);

            // 
            obj.Parse(dic, ignoreCase);
        }

        /// <summary>
        /// Phân tích giá trị thuộc tính cho đối tượng
        /// </summary>
        public static void Parse(this object obj, Dictionary<string, object> dic, bool ignoreCase)
        {
            // Không phân biệt hoa thường ở tên property
            if (ignoreCase) obj.Parse(dic, p => p.Name.ToLower(), name => name.ToLower());

            // Có phân biệt hoa thường ở tên property
            else obj.Parse(dic, p => p.Name, name => name);
        }

        /// <summary>
        /// Phân tích giá trị thuộc tính cho đối tượng
        /// </summary>
        private static void Parse(this object obj, Dictionary<string, object> dic, Func<PropertyInfo, string> getPropertyName, Func<string, string> getKeyName)
        {
            // TypeOfObject
            var type = obj.GetType();

            // danh sách Property của obj
            var pis = type.GetListProperties();

            // Join tìm thuộc tính phù hợp để điền giá trị
            pis.Join(dic, p => getPropertyName(p), d => getKeyName(d.Key), (p, d) =>
            {
                // Lấy ra Converter phù hợp
                var converter = HauType.GetConverter(p.PropertyType);

                // Nếu convert được thì gán giá trị bằng giá trị được convert
                if (converter.CanConvertFrom(d.Value.IsNull() ? typeof(DBNull) : d.Value.GetType()))
                    p.SetValue(obj, converter.ConvertFrom(d.Value), null);

                else if (converter.GetType().Name == typeof(EnumConverter).Name && d.Value.IsNotNull())
                    p.SetValue(obj, converter.ConvertFrom(d.Value.ToString()), null);

                return false;
            }).Count();
        }
        /// <summary>
        /// Thực hiện validate tập giá trị ứng với object
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static ValidatorMessage Validate(this object obj, Dictionary<string, object> values)
        {
            // Danh sách property có chứa attribute thực hiện validate
            var prs = obj.GetType().GetListPairPropertyListAttribute<ValidatorAttribute>();

            // Join để thực hiện validate key trùng với tên property
            var list = values.Join(prs, v => v.Key, p => p.T1.Name, (v, p) => new { V = v, P = p }).ToList();

            for (var i = 0; i < list.Count; i++)
            {
                // Thực hiện validate với property đang xét
                var vm = DoValidate(list[i].P, list[i].V.Value, values, obj.GetType());

                // 
                if (vm != null) return vm;
            }

            // Message thực hiện validate
            return ValidatorMessage.GetDefault();
        }

        /// <summary>
        /// Thực hiện validate tập giá trị ứng với object
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static ValidatorMessage Validate(this object obj, NameValueCollection values)
        {
            return obj.Validate(values.ToDic());
        }

        /// <summary>
        /// Thực hiện validate với một giá trị
        /// </summary>
        /// <param name="pr"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private static ValidatorMessage DoValidate(Pair<PropertyInfo, List<ValidatorAttribute>> pr, object value, Dictionary<string, object> data, Type typeObject)
        {
            // Property quy định alias tên thuộc tính
            // var pif = pr.T1.GetAttribute<PropertyInfoAttribute>();

            // Tên alias
            // var name = pif == null ? pr.T1.Name : pif.Name;
            var name = pr.T1.Name;

            // sắp xếp thứ tự các validator
            var list = pr.T2.OrderBy(v => v.Stt).ToList();

            // Duyệt qua các validator của property
            for (var j = 0; j < list.Count; j++)
            {
                var validator = list[j];

                // Thiết lập giá trị cần thực hiện validate
                validator.SetData(value, name);
                validator.Data = data;
                validator.ObjectType = typeObject;

                // Thực hiện valiate
                if (!validator.Validate()) return new ValidatorMessage
                {
                    Status = ValidatorStatus.InValid,
                    Message = validator.GetMessage(),
                    FieldName = pr.T1.Name
                };
            }
            return null;
        }

        public static ValidatorMessage Validate(this object obj)
        {
            // Danh sách property có chứa attribute thực hiện validate
            var prs = obj.GetType().GetListPairPropertyListAttribute<ValidatorAttribute>();
            return obj.Validate(prs.ToDictionary(p => p.T1.Name, p => p.T1.GetValue(obj)));
        }

    }
}
