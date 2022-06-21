using System.Globalization;

namespace TicketMachineSystem.Domains.Helpers
{
    /// <summary>
    /// int 拡張メソッド
    /// </summary>
    public static partial class IntExtensions
    {
        /// <summary>
        /// int -> 日本円
        /// </summary>
        /// <param name="this">@this to act on</param>
        /// <returns>日本円</returns>
        public static string ToStringYen(this int @this)
        {
            return @this.ToString("C", new CultureInfo("ja-JP"));
        }
    }
}