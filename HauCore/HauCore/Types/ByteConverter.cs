#region  ******** Copyright © 2016 HauCore ********
using System;
using System.ComponentModel;
using System.Globalization;
#endregion

namespace HauCore.Types
{
    public class ByteConverter : TypeConverterBase
    {
        public override Type[] TypeTager
        {
            get
            {
                return new[] { typeof(byte) };
            }
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value, HTypeCode typeCode)
        {
            switch (typeCode)
            {
                case HTypeCode.Int32:
                case HTypeCode.String: return Convert.ToByte(value);
                case HTypeCode.Byte: return value;
                case HTypeCode.DBNull: return 0;
            }

            return base.ConvertFrom(context, culture, value, typeCode);
        }
        public override HTypeCode GetTypeCodeCanConvert()
        {
            return HTypeCode.Byte |HTypeCode.String |HTypeCode.Int32 |HTypeCode.DBNull;
        }
    }
}
