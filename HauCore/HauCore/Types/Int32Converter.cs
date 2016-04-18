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
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value, HTypeCode typeCode)
        {
            switch (typeCode)
            {
                case HTypeCode.String: return value.ToString().IsNull() ? 0 : Convert.ToInt32(value);

                case HTypeCode.Int16:
                case HTypeCode.Byte:
                case HTypeCode.Decimal:
                case HTypeCode.Int64:
                case HTypeCode.Double: return Convert.ToInt32(value);

                case HTypeCode.Int32: return value;
                case HTypeCode.Boolean: return (bool)value==true ? 1 : 0;

                case HTypeCode.DBNull: return 0;
            }
            return base.ConvertFrom(context, culture, value, typeCode);
        }
        public override HTypeCode GetTypeCodeCanConvert()
        {
            return HTypeCode.String | HTypeCode.Double | HTypeCode.Int32 | HTypeCode.Int16 | HTypeCode.Byte | HTypeCode.Boolean | HTypeCode.Int64 | HTypeCode.DBNull;
        }
    }
}
