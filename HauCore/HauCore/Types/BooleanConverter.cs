#region  ******** Copyright © 2016 HauCore ********
using System;
using System.ComponentModel;
using System.Globalization;
#endregion  ******** Copyright © 2016 HauCore ********

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
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value, HTypeCode typeCode)
        {
            switch (typeCode)
            {
                case HTypeCode.String: return value.ToString() == "true" || value.ToString() == "1";
                case HTypeCode.Int32: return value.ToString() == "1";
                case HTypeCode.Boolean: return value;
                case HTypeCode.DBNull: return false;
            }

            // Base
            return base.ConvertFrom(context, culture, value, typeCode);
        }

        public override HTypeCode GetTypeCodeCanConvert()
        {
            return HTypeCode.Int32 | HTypeCode.Boolean | HTypeCode.String | HTypeCode.DBNull;
        }
    }
}
