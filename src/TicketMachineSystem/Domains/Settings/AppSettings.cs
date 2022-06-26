namespace TicketMachineSystem.Domains.Settings
{
    /// <summary>
    /// appsettings.json
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// Elasticsearch接続情報
        /// </summary>
        public ElasticsearchConnectionSettings ElasticsearchConnectionSettings { get; set; }
    }
}