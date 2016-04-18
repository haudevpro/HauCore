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
                return new[] { typeof(Decimal), typeof(Decimal?) };
            }
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value, TypeCode typeCode)
        {
            switch (typeCode)
            {
                case TypeCode.String:
                    var strValue = value.ToString().GetOnlyDigital();
                    return strValue.IsNull() ? (decimal?)null : Convert.ToDecimal(strValue); // hanhth
                //case TypeCode.String: return value.ToString().Trim().IsNull() ? (decimal?)null : Convert.ToDecimal(value.ToString().Replace(",",""), CultureInfo.GetCultureInfo("vi-VN"));//sonpc
                case TypeCode.Int64:
                case TypeCode.Int32:
                case TypeCode.Int16:
                case TypeCode.Double: return Convert.ToDecimal(value);
                case TypeCode.Decimal: return value;
                // case TypeCode.DBNull: return new Decimal(0);
                case TypeCode.DBNull: return null;
            }
            return base.ConvertFrom(context, culture, value, typeCode);
        }

        public override TypeCode GetTypeCodeCanConvert()
        {
            return TypeCode.Decimal | TypeCode.String | TypeCode.Int64 | TypeCode.Int32 | TypeCode.Int16 | TypeCode.Double | TypeCode.DBNull;
        }
    }
}
