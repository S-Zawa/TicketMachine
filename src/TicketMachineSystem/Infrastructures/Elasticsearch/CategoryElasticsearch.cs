using Nest;
using TicketMachineSystem.Domains.Entities;
using TicketMachineSystem.Domains.Helpers;
using TicketMachineSystem.Domains.Repositories;
using TicketMachineSystem.Domains.Settings;

namespace TicketMachineSystem.Infrastructures.Elasticsearch
{
    /// <inheritdoc/>
    public sealed class CategoryElasticsearch : ICategoryRepository
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="appSettings">AppSettings</param>
        public CategoryElasticsearch(AppSettings appSettings)
        {
            this.AppSettings = appSettings;
        }

        /// <summary>
        /// AppSettings
        /// </summary>
        public AppSettings AppSettings { get; }

        /// <summary>
        /// ConnectionSettings
        /// </summary>
        public ConnectionSettings ConnectionSettings
        {
            get
            {
                return new ConnectionSettings(new Uri(this.AppSettings.ElasticsearchConnectionSettings.Uri))
                    .BasicAuthentication(this.AppSettings.ElasticsearchConnectionSettings.UserId, this.AppSettings.ElasticsearchConnectionSettings.Password.Base64Decode());
            }
        }

        /// <inheritdoc/>
        public IEnumerable<Category> GetAll()
        {
            var client = new ElasticClient(this.ConnectionSettings);

            var searchResults = client.Search<Category>(x => x.Index(this.AppSettings.ElasticsearchConnectionSettings.Index).MatchAll());

            return searchResults.Documents.ToList();
        }
    }
}