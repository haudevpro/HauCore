#region  ******** Copyright © 2016 HauCore ********
using System;
using System.ComponentModel;
using System.Globalization;
#endregion  ******** Copyright © 2016 HauCore ********

namespace HauCore.Types
{
    public class DoubleConverter : TypeConverterBase
    {
        public override Type[] TypeTager
        {
            get
            {
                return new[] { typeof(double), typeof(double?) };
            }
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value, HTypeCode typeCode)
        {
            switch (typeCode)
            {
                case HTypeCode.String:
                case HTypeCode.Single: return Convert.ToDouble(value);
                case HTypeCode.Double: return value;
                case HTypeCode.DBNull: return 0;
            }
            return base.ConvertFrom(context, culture, value, typeCode);
        }

        public override HTypeCode GetTypeCodeCanConvert()
        {
            return HTypeCode.Double | HTypeCode.String | HTypeCode.DBNull;
        }
    }
}
