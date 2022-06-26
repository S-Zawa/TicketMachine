using System.Text;

namespace TicketMachineSystem.Domains.Helpers
{
    /// <summary>
    /// Base64Extensions
    /// </summary>
    public static class Base64Extensions
    {
        /// <summary>
        /// Base64Decode
        /// </summary>
        /// <param name="this">@this to act on</param>
        /// <returns>plantext</returns>
        public static string Base64Decode(this string @this)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(@this);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        /// <summary>
        /// Base64Encode
        /// </summary>
        /// <param name="this">@this to act on</param>
        /// <returns>base64</returns>
        public static string Base64Encode(this string @this)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(@this);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}