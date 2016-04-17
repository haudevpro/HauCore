using System;
using System.ComponentModel;
using System.Globalization;

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
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value, TypeCode typeCode)
        {
            switch (typeCode)
            {
                case TypeCode.String:
                case TypeCode.Byte: return Convert.ToInt16(value);
                case TypeCode.Int16: return value;
                case TypeCode.DBNull: return 0;
            }
            return base.ConvertFrom(context, culture, value, typeCode);
        }
        public override TypeCode GetTypeCodeCanConvert()
        {
            return TypeCode.Int16 | TypeCode.String | TypeCode.Byte | TypeCode.DBNull;
        }
    }
}
