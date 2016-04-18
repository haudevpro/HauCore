#region  ******** Copyright © 2016 HauCore ********
#endregion  ******** Copyright © 2016 HauCore ********

namespace HauCore.Utility
{
    /// <summary>
    /// Cặp đôi giá trị
    /// </summary>
    /// <typeparam name="T1Value"></typeparam>
    /// <typeparam name="T2Value"></typeparam>
    public class Pair<T1Value, T2Value>
    {
        public T1Value T1 { set; get; }
        public T2Value T2 { set; get; }
    }
}
