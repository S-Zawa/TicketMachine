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
        /// メインメニュー取得
        /// </summary>
        /// <returns>取得結果</returns>
        public IEnumerable<Menu> GetMainMenu()
        {
            return CsvParser.Read<Menu>(@"menu.csv", Encoding.GetEncoding("Shift_JIS"), ",").Where(x => x.N == 1);
        }

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