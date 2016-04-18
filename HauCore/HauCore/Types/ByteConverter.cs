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
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value, TypeCode typeCode)
        {
            switch (typeCode)
            {
                case TypeCode.Int32:
                case TypeCode.String: return Convert.ToByte(value);
                case TypeCode.Byte: return value;
                case TypeCode.DBNull: return 0;
            }

            return base.ConvertFrom(context, culture, value, typeCode);
        }
        public override TypeCode GetTypeCodeCanConvert()
        {
            return TypeCode.Byte | TypeCode.String | TypeCode.Int32 | TypeCode.DBNull;
        }
    }
}
