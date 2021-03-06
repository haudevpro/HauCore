﻿#region  ******** Copyright © 2016 HauCore ********
using System;
using System.ComponentModel;
using System.Globalization;
#endregion  ******** Copyright © 2016 HauCore ********

namespace HauCore.Types
{
    public class SingleConverter : TypeConverterBase
    {
        public override Type[] TypeTager
        {
            get
            {
                return new[] { typeof(float), typeof(float?) };
            }
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value, HTypeCode typeCode)
        {
            switch (typeCode)
            {
                case HTypeCode.String: return value == null || string.IsNullOrEmpty(value.ToString()) ? 0 : Convert.ToSingle(value);
                case HTypeCode.Double: return Convert.ToSingle(value);

                case HTypeCode.Single: return value;
                case HTypeCode.DBNull: return 0;
            }
            return base.ConvertFrom(context, culture, value, typeCode);
        }
        public override HTypeCode GetTypeCodeCanConvert()
        {
            return HTypeCode.Single |HTypeCode.String |HTypeCode.Double |HTypeCode.DBNull;
        }
    }
}
