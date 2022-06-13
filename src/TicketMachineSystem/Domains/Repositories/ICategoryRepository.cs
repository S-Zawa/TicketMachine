using TicketMachineSystem.Domains.Entities;

namespace TicketMachineSystem.Domains.Repositories
{
    /// <summary>
    /// カテゴリリポジトリ
    /// </summary>
    public interface ICategoryRepository
    {
        /// <summary>
        /// 全カテゴリ取得
        /// </summary>
        /// <returns>全カテゴリ</returns>
        public IEnumerable<Category> GetAll();
    }
}