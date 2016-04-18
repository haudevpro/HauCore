#region  ******** Copyright © 2016 HauCore ********
using System;
using System.ComponentModel;
using System.Globalization;
#endregion  ******** Copyright © 2016 HauCore ********

namespace HauCore.Types
{
    public class Int64Converter : TypeConverterBase
    {
        public override Type[] TypeTager
        {
            get
            {
                return new[] { typeof(long), typeof(long?) };
            }
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value, HTypeCode typeCode)
        {
            switch (typeCode)
            {
                case HTypeCode.String:
                case HTypeCode.Int16:
                case HTypeCode.Int32:
                case HTypeCode.Decimal:
                case HTypeCode.Byte: return Convert.ToInt64(value);
                case HTypeCode.Int64: return value;
                case HTypeCode.DBNull: return 0;
            }
            return base.ConvertFrom(context, culture, value, typeCode);
        }
        public override HTypeCode GetTypeCodeCanConvert()
        {
            return HTypeCode.Int64 | HTypeCode.String | HTypeCode.Int16 | HTypeCode.Int32 | HTypeCode.Byte | HTypeCode.Decimal | HTypeCode.DBNull;
        }
    }
}
