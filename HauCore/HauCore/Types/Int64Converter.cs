using HauCore.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value, TypeCode typeCode)
        {
            switch (typeCode)
            {
                case TypeCode.String:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Decimal:
                case TypeCode.Byte: return Convert.ToInt64(value);
                case TypeCode.Int64: return value;
                case TypeCode.DBNull: return 0;
            }
            return base.ConvertFrom(context, culture, value, typeCode);
        }
        public override TypeCode GetTypeCodeCanConvert()
        {
            return TypeCode.Int64 | TypeCode.String | TypeCode.Int16 | TypeCode.Int32 | TypeCode.Byte | TypeCode.Decimal | TypeCode.DBNull;
        }
    }
}
