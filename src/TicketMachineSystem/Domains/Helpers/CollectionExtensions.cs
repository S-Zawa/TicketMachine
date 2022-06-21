namespace TicketMachineSystem.Domains.Helpers
{
    /// <summary>
    /// Collection 拡張メソッド
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// 複数の要素のすべてがコレクションに格納されているかどうかを判定します。
        /// </summary>
        /// <typeparam name="T">対象の型</typeparam>
        /// <param name="this">対象のコレクション</param>
        /// <param name="items">追加する要素</param>
        /// <returns>要素を追加できた場合に true を返します。</returns>
        public static bool ContainsAll<T>(this ICollection<T> @this, params T[] items)
        {
            foreach (T item in items)
            {
                if (!@this.Contains(item))
                {
                    return false;
                }
            }

            return true;
        }
    }
}