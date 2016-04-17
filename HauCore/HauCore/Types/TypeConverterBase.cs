﻿using System;
using System.ComponentModel;

namespace HauCore.Types
{
    public abstract class TypeConverterBase: TypeConverter
    {
        /// <summary>
        /// Kiểu ép kiểu về
        /// </summary>
        public abstract Type[] TypeTager { get; }
        /// <summary>
        /// return những Type Code có thể Convert được
        /// </summary>
        /// <returns></returns>
        public abstract TypeCode GetTypeCodeCanConvert();
        /// <summary>
        /// Xem có thể Convert được từ những kiểu dữ liệu nào
        /// </summary>
        /// <param name="context"></param>
        /// <param name="sourceType"></param>
        /// <returns></returns>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return GetTypeCodeCanConvert().IsSet(Type.GetTypeCode(sourceType));
        }

        /// <summary>
        /// Thực hiện Convert
        /// </summary>
        /// <param name="context"></param>
        /// <param name="culture"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            return ConvertFrom(context, culture, value, value == null ? TypeCode.DBNull : Type.GetTypeCode(value.GetType()));
        }

        /// <summary>
        /// Thực hiện Convert thông qua typeCode
        /// </summary>
        /// <param name="context"></param>
        /// <param name="culture"></param>
        /// <param name="typeCode"></param>
        /// <returns></returns>
        public virtual object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, TypeCode typeCode)
        {

            // Mặc định là Convert theo class Base
            return base.ConvertFrom(context, culture, value);
        }
    } 
}