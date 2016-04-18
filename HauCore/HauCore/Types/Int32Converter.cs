#region  ******** Copyright © 2016 HauCore ********
using HauCore.Extensions;
using System;
using System.ComponentModel;
using System.Globalization;
#endregion  ******** Copyright © 2016 HauCore ********

namespace HauCore.Types
{
    public class Int32Converter : TypeConverterBase
    {
        public override Type[] TypeTager
        {
            get
            {
                return new[] { typeof(int), typeof(int?) };
            }
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value, TypeCode typeCode)
        {
            switch (typeCode)
            {
                case TypeCode.String: return value.ToString().IsNull() ? 0 : Convert.ToInt32(value);

                case TypeCode.Int16:
                case TypeCode.Byte:
                case TypeCode.Decimal:
                case TypeCode.Int64:
                case TypeCode.Double: return Convert.ToInt32(value);

                case TypeCode.Int32: return value;
                case TypeCode.Boolean: return (bool)value==true ? 1 : 0;

                case TypeCode.DBNull: return 0;
            }
            return base.ConvertFrom(context, culture, value, typeCode);
        }
        public override TypeCode GetTypeCodeCanConvert()
        {
            return TypeCode.String | TypeCode.Double | TypeCode.Int32 | TypeCode.Int16 | TypeCode.Byte | TypeCode.Boolean | TypeCode.Int64 | TypeCode.DBNull;
        }
    }
}
