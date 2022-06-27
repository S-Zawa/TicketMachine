using Microsoft.Extensions.Configuration;
using TicketMachineSystem.Domains.Models;
using TicketMachineSystem.Domains.Settings;
using TicketMachineSystem.Infrastructures.Csv;
using TicketMachineSystem.Infrastructures.Elasticsearch;

namespace TicketMachineSystem // Note: actual namespace depends on the project name.
{
    /// <summary>
    /// Program
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var appSettings = configuration.Get<AppSettings>();

            var ticketMachine = new TicketMachine(new MenuCsv(), new CategoryElasticsearch(appSettings));
            ticketMachine.Order();

            ticketMachine.DisplaySelectedMenuSummary();

        }
    }
}