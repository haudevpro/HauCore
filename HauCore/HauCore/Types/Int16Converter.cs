#region  ******** Copyright © 2016 HauCore ********
using System;
using System.ComponentModel;
using System.Globalization;
#endregion  ******** Copyright © 2016 HauCore ********

namespace HauCore.Types
{
    public class Int16Converter : TypeConverterBase
    {
        public override Type[] TypeTager
        {
            get
            {
                return new[] { typeof(short) ,typeof(short?)};
            }
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value, HTypeCode typeCode)
        {
            switch (typeCode)
            {
                case HTypeCode.String:
                case HTypeCode.Byte: return Convert.ToInt16(value);
                case HTypeCode.Int16: return value;
                case HTypeCode.DBNull: return 0;
            }
            return base.ConvertFrom(context, culture, value, typeCode);
        }
        public override HTypeCode GetTypeCodeCanConvert()
        {
            return HTypeCode.Int16 | HTypeCode.String | HTypeCode.Byte | HTypeCode.DBNull;
        }
    }
}
