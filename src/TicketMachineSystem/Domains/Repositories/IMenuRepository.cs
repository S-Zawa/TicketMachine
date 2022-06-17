using TicketMachineSystem.Domains.Entities;
using TicketMachineSystem.Domains.Models;

namespace TicketMachineSystem.Domains.Repositories
{
    /// <summary>
    /// メニューリポジトリ
    /// </summary>
    public interface IMenuRepository
    {
        /// <summary>
        /// 分類番号でメニューを取得
        /// </summary>
        /// <param name="categoryNo">分類番号</param>
        /// <returns>分類番号に一致したメニュー</returns>
        IEnumerable<Menu> GetByCategoryNo(CategoryNo categoryNo);

        /// <summary>
        /// 全メニュー取得
        /// </summary>
        /// <returns>全メニュー</returns>
        IEnumerable<Menu> GetAllMenu();

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