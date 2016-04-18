#region  ******** Copyright © 2016 HauCore ********
using System;
using System.ComponentModel;
using System.Globalization;
#endregion  ******** Copyright © 2016 HauCore ********

namespace HauCore.Types
{
    public class DoubleConverter : TypeConverterBase
    {
        public override Type[] TypeTager
        {
            get
            {
                return new[] { typeof(Double), typeof(Double?) };
            }
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value, TypeCode typeCode)
        {
            switch (typeCode)
            {
                case TypeCode.String:
                case TypeCode.Single: return Convert.ToDouble(value);
                case TypeCode.Double: return value;
                case TypeCode.DBNull: return 0;
            }
            return base.ConvertFrom(context, culture, value, typeCode);
        }

        public override TypeCode GetTypeCodeCanConvert()
        {
            return TypeCode.Double | TypeCode.String | TypeCode.DBNull;
        }
    }
}
