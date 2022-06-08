using TicketMachineSystem.Domains.Models;

namespace TicketMachineSystem.Domains.Repositories
{
    /// <summary>
    /// メニューリポジトリ
    /// </summary>
    public interface IMenuRepository
    {
        /// <summary>
        /// メインメニュー取得
        /// </summary>
        /// <returns>メインメニュー</returns>
        IEnumerable<Menu> GetMainMenu();

        /// <summary>
        /// サイドメニュー1取得
        /// </summary>
        /// <returns>サイドメニュー1</returns>
        IEnumerable<Menu> GetSide1();

        /// <summary>
        /// サイドメニュー2取得
        /// </summary>
        /// <returns>サイドメニュー2</returns>
        IEnumerable<Menu> GetSide2();

        /// <summary>
        /// オプション取得
        /// </summary>
        /// <returns>オプション</returns>
        IEnumerable<Menu> GetOption();
    }
}