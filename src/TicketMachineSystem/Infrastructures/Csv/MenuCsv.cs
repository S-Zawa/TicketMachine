using System.Text;
using TicketMachineSystem.Domains.Entities;
using TicketMachineSystem.Domains.Helpers;
using TicketMachineSystem.Domains.Models;
using TicketMachineSystem.Domains.Repositories;

namespace TicketMachineSystem.Infrastructures.Csv
{
    /// <summary>
    /// メニューCSVリポジトリ
    /// </summary>
    public sealed class MenuCsv : IMenuRepository
    {
        /// <inheritdoc/>
        public IEnumerable<Menu> GetAllMenu()
        {
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            return CsvParser.Read<Menu>(@"menu.csv", Encoding.GetEncoding("Shift_JIS"), ",");
        }

        /// <inheritdoc/>
        public IEnumerable<Menu> GetMainMenu()
        {
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            return CsvParser.Read<Menu>(@"menu.csv", Encoding.GetEncoding("Shift_JIS"), ",").Where(x => x.N == CategoryNo.Main);
        }

        /// <inheritdoc/>
        public IEnumerable<Menu> GetOption()
        {
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            return CsvParser.Read<Menu>(@"menu.csv", Encoding.GetEncoding("Shift_JIS"), ",").Where(x => x.N == CategoryNo.Option);
        }

        /// <inheritdoc/>
        public IEnumerable<Menu> GetSide1()
        {
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            return CsvParser.Read<Menu>(@"menu.csv", Encoding.GetEncoding("Shift_JIS"), ",").Where(x => x.N == CategoryNo.Side1);
        }

        /// <inheritdoc/>
        public IEnumerable<Menu> GetSide2()
        {
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            return CsvParser.Read<Menu>(@"menu.csv", Encoding.GetEncoding("Shift_JIS"), ",").Where(x => x.N == CategoryNo.Side2);
        }
    }
}