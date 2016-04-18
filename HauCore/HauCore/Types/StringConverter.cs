#region  ******** Copyright © 2016 HauCore ********
using System;
using System.ComponentModel;
using System.Globalization;
#endregion  ******** Copyright © 2016 HauCore ********

namespace HauCore.Types
{
    public class StringConverter : TypeConverterBase
    {
        public override Type[] TypeTager
        {
            get
            {
                return new[] { typeof(string) } ;
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
                default: return value.ToString();
                case TypeCode.DBNull: return string.Empty;
            }
        }

        public override TypeCode GetTypeCodeCanConvert()
        {
            return TypeCode.Empty;
        }

        /// <summary>
        /// Có thể  Convert được từ Type nào
        /// </summary>
        /// <param name="context"></param>
        /// <param name="sourceType"></param>
        /// <returns></returns>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return true;
        }
    }
}
