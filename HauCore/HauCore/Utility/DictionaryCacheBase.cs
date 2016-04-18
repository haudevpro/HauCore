#region ******** Copyright © 2016 HauCore ********
using System.Collections.Concurrent;
#endregion ******** Copyright © 2016 HauCore ********

namespace HauCore.Utility
{
    /// <summary>
    /// DictionaryBase dùng để cache
    /// </summary>
    public abstract class DictionaryCacheBase<TKey, TValue, TInst> where TInst : new()
    {
        public static TInst Inst { get { return Singleton<TInst>.Inst; } }

        /// <summary>
        /// Dic để lưu trữ các giá trị
        /// </summary>
        private ConcurrentDictionary<TKey, TValue> dic = new ConcurrentDictionary<TKey, TValue>();

        /// <summary>
        /// indexer để lấy giá trị theo key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public TValue this[TKey key]
        {
            get
            {
                // giá trị cần lấy ra
                TValue value;

                // nếu giá trị chưa có thì thực hiện lấy dữ liệu
                // và đưa vào dic
                if (!dic.TryGetValue(key, out value)) dic[key] = value = GetValueForDic(key);

                // return kết quả
                return value;
            }
        }

        /// <summary>
        /// Phương thức nội bộ để lấy được giá trị với một Key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected abstract TValue GetValueForDic(TKey key);

        /// <summary>
        /// Clear toàn bộ cache
        /// </summary>
        public void Clear() { dic.Clear(); }
    }
}
