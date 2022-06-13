using TicketMachineSystem.Domains.Entities;
using TicketMachineSystem.Domains.Repositories;

namespace TicketMachineSystem.Infrastructures.Sqlite
{
    /// <summary>
    /// メニューSqliteリポジトリ
    /// </summary>
    public class MenuSqlite : IMenuRepository
    {
        /// <summary>
        /// 全メニュー取得
        /// </summary>
        /// <returns>全メニュー</returns>
        public IEnumerable<Menu> GetAllMenu()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// メインメニュー取得
        /// </summary>
        /// <returns>メインメニュー</returns>
        public IEnumerable<Menu> GetMainMenu()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// オプション取得
        /// </summary>
        /// <returns>オプション</returns>
        public IEnumerable<Menu> GetOption()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// サイドメニュー1取得
        /// </summary>
        /// <returns>サイドメニュー1</returns>
        public IEnumerable<Menu> GetSide1()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// サイドメニュー2取得
        /// </summary>
        /// <returns>サイドメニュー2</returns>
        public IEnumerable<Menu> GetSide2()
        {
            throw new NotImplementedException();
        }
    }
}