using TicketMachineSystem.Domains.Repositories;
using TicketMachineSystem.Infrastructures.Csv;

namespace TicketMachineSystem.Infrastructures
{
    /// <summary>
    /// リポジトリファクトリクラス
    /// </summary>
    public static class Factories
    {
        /// <summary>
        /// メニューリポジトリ作成
        /// </summary>
        /// <returns>メニューリポジトリ</returns>
        public static IMenuRepository CreateMenuRepository()
        {
            return new MenuCsv();
        }
    }
}