using System;
using System.ComponentModel;
using System.Globalization;

namespace HauCore.Types
{
    public class BooleanConverter : TypeConverterBase
    {
        public override Type[] TypeTager
        {
            get
            {
                return new[] { typeof(bool) };
            }
        }
        /// <summary>
        /// Thực hiện Convert
        /// </summary>
        /// <param name="context"></param>
        /// <param name="culture"></param>
        /// <param name="value"></param>
        /// <param name="typeCode"></param>
        /// <returns></returns>
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value, TypeCode typeCode)
        {
            switch (typeCode)
            {
                case TypeCode.String: return value.ToString() == "true" || value.ToString() == "1";
                case TypeCode.Int32: return value.ToString() == "1";
                case TypeCode.Boolean: return value;
                case TypeCode.DBNull: return false;
            }

            // Base
            return base.ConvertFrom(context, culture, value, typeCode);
        }

        public override TypeCode GetTypeCodeCanConvert()
        {
            return TypeCode.Int32 | TypeCode.Boolean | TypeCode.String | TypeCode.DBNull;
        }
    }
}
