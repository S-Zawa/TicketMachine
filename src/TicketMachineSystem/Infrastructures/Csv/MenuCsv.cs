using System.Text;
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
        /// <summary>
        /// 全メニュー取得
        /// </summary>
        /// <returns>全メニュー</returns>
        public IEnumerable<Menu> GetAllMenu()
        {
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            return CsvParser.Read<Menu>(@"menu.csv", Encoding.GetEncoding("Shift_JIS"), ",");
        }

        /// <summary>
        /// メインメニュー取得
        /// </summary>
        /// <returns>取得結果</returns>
        public IEnumerable<Menu> GetMainMenu()
        {
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            return CsvParser.Read<Menu>(@"menu.csv", Encoding.GetEncoding("Shift_JIS"), ",").Where(x => x.N == CategoryType.Main);
        }

        /// <summary>
        /// オプション取得
        /// </summary>
        /// <returns>取得結果</returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<Menu> GetOption()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Menu> GetSide1()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Menu> GetSide2()
        {
            throw new NotImplementedException();
        }
    }
}