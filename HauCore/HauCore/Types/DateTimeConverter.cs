using HauCore.Extensions;
using System;
using System.ComponentModel;
using System.Globalization;

namespace HauCore.Types
{
    public class DateTimeConverter : TypeConverterBase
    {
        public override Type[] TypeTager
        {
            get
            {
                return new[]{ typeof(DateTime), typeof(DateTime?) };
            }
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value, TypeCode typeCode)
        {
            switch (typeCode)
            {
                case TypeCode.String: return value.ToString().Trim().IsNull() ? (DateTime?)null : Convert.ToDateTime(value, CultureInfo.GetCultureInfo("vi-VN"));
                case TypeCode.DateTime: return value;
                case TypeCode.DBNull: return null;
            }
            return base.ConvertFrom(context, culture, value, typeCode);
        }
        public override TypeCode GetTypeCodeCanConvert()
        {
            return TypeCode.DateTime | TypeCode.String | TypeCode.DBNull;
        }
    }
}
