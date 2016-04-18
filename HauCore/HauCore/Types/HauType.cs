#region  ******** Copyright © 2016 HauCore ********
using System;
using System.Collections.Generic;
using System.ComponentModel;
#endregion  ******** Copyright © 2016 HauCore ********

namespace HauCore.Types
{
    public sealed class HauType
    {
        /// <summary>
        /// Thực hiện lấy Converter
        /// </summary>
        /// <returns></returns>
        public static TypeConverter GetConverter(Type type)
        {
            // Viết lại Converter tại đây
            TypeConverter typeConverter = null;

            // Nếu thực hiện lấy ở dic không thành công thì tạo mới
            return DicType.TryGetValue(type, out typeConverter) ? typeConverter : TypeDescriptor.GetConverter(type);
        }

        private static Dictionary<Type, TypeConverter> dicType;
      
        public static Dictionary<Type, TypeConverter> DicType
        {
            get
            {
                if (dicType == null)
                {
                    dicType = new Dictionary<Type, TypeConverter>();
                        (new List<TypeConverterBase>
                            {
                                new BooleanConverter(),
                                new ByteConverter(),
                                new DateTimeConverter(),
                                new DecimalConverter(),
                                new DoubleConverter(),
                                new GuidConverter(),
                                new Int16Converter(),
                                new Int32Converter(),
                                new Int64Converter(),
                                new SingleConverter(),
                                new StringConverter()
                            }).ForEach(p=> {
                                foreach(var item in p.TypeTager)
                                {
                                    dicType[item] = p;
                                }
                            });
                }
                
                return dicType;
            }
        }
    }
}
