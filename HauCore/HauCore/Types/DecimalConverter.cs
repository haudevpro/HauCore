#region  ******** Copyright © 2016 HauCore ********
using HauCore.Extensions;
using System;
using System.ComponentModel;
using System.Globalization;
#endregion  ******** Copyright © 2016 HauCore ********

namespace HauCore.Types
{
    public class DecimalConverter : TypeConverterBase
    {
        public override Type[] TypeTager
        {
            get
            {
                return new[] { typeof(decimal), typeof(Decimal?) };
            }
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value, HTypeCode typeCode)
        {
            switch (typeCode)
            {
                case HTypeCode.String:
                    var strValue = value.ToString().GetOnlyDigital();
                    return strValue.IsNull() ? (decimal?)null : Convert.ToDecimal(strValue); // hanhth
                //caseHTypeCode.String: return value.ToString().Trim().IsNull() ? (decimal?)null : Convert.ToDecimal(value.ToString().Replace(",",""), CultureInfo.GetCultureInfo("vi-VN"));//sonpc
                case HTypeCode.Int64:
                case HTypeCode.Int32:
                case HTypeCode.Int16:
                case HTypeCode.Double: return Convert.ToDecimal(value);
                case HTypeCode.Decimal: return value;
                // caseHTypeCode.DBNull: return new Decimal(0);
                case HTypeCode.DBNull: return null;
            }
            return base.ConvertFrom(context, culture, value, typeCode);
        }

        public override HTypeCode GetTypeCodeCanConvert()
        {
            return HTypeCode.Decimal | HTypeCode.String | HTypeCode.Int64 | HTypeCode.Int32 | HTypeCode.Int16 | HTypeCode.Double | HTypeCode.DBNull;
        }
    }
}
