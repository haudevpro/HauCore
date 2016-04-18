#region  ******** Copyright © 2016 HauCore ********
using System;
using System.ComponentModel;
using System.Globalization;
#endregion  ******** Copyright © 2016 HauCore ********

namespace HauCore.Types
{
    public class SingleConverter : TypeConverterBase
    {
        public override Type[] TypeTager
        {
            get
            {
                return new[] { typeof(float), typeof(float?) };
            }
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value, TypeCode typeCode)
        {
            switch (typeCode)
            {
                case TypeCode.String: return value == null || string.IsNullOrEmpty(value.ToString()) ? 0 : Convert.ToSingle(value);
                case TypeCode.Double: return Convert.ToSingle(value);

                case TypeCode.Single: return value;
                case TypeCode.DBNull: return 0;
            }
            return base.ConvertFrom(context, culture, value, typeCode);
        }
        public override TypeCode GetTypeCodeCanConvert()
        {
            return TypeCode.Single | TypeCode.String | TypeCode.Double | TypeCode.DBNull;
        }
    }
}
