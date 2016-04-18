#region  ******** Copyright © 2016 HauCore ********
using System;
using System.ComponentModel;
using System.Globalization;
#endregion  ******** Copyright © 2016 HauCore ********
namespace HauCore.Types
{
    public class GuidConverter : TypeConverterBase
    {
        public override Type[] TypeTager
        {
            get
            {
                return new[] { typeof(Guid), typeof(Guid?) };
            }
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value, TypeCode typeCode)
        {
            switch (typeCode)
            {
                case TypeCode.String: return new Guid(value.ToString());
                case TypeCode.Object: return value;
                case TypeCode.DBNull: return Guid.Empty;
            }
            return base.ConvertFrom(context, culture, value, typeCode);
        }

        /// <summary>
        /// Có thể convert được từ những type nào
        /// </summary>
        /// <returns></returns>
        public override TypeCode GetTypeCodeCanConvert()
        {
            return TypeCode.String | TypeCode.Object | TypeCode.DBNull;
        }
    }
}
