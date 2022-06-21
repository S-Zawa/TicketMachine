namespace TicketMachineSystem.Domains.Settings
{
    /// <summary>
    /// Elasticsearch接続情報
    /// </summary>
    public class ElasticsearchConnectionSettings
    {
        /// <summary>
        /// Uri
        /// </summary>
        public string Uri { get; set; }

        /// <summary>
        /// Index
        /// </summary>
        public string Index { get; set; }

        /// <summary>
        /// UserId
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }
    }
}