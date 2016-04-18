#region  ******** Copyright © 2016 HauCore ********
using HauCore.Extensions;
using System;
using System.ComponentModel;
using System.Globalization;
#endregion  ******** Copyright © 2016 HauCore ********

namespace HauCore.Types
{
    public class DateTimeConverter : TypeConverterBase
    {
        public override Type[] TypeTager
        {
            get
            {
                return new[]{ typeof(DateTime), typeof(DateTime?) };
            }
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value, HTypeCode typeCode)
        {
            switch (typeCode)
            {
                case HTypeCode.String: return value.ToString().Trim().IsNull() ? (DateTime?)null : Convert.ToDateTime(value, CultureInfo.GetCultureInfo("vi-VN"));
                case HTypeCode.DateTime: return value;
                case HTypeCode.DBNull: return null;
            }
            return base.ConvertFrom(context, culture, value, typeCode);
        }
        public override HTypeCode GetTypeCodeCanConvert()
        {
            return HTypeCode.DateTime | HTypeCode.String | HTypeCode.DBNull;
        }
    }
}
