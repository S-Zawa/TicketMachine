using TicketMachineSystem.Domains.Entities;

namespace TicketMachineSystem.Domains.Models
{
    /// <summary>
    /// カテゴリ別メニュー
    /// </summary>
    public abstract class CategoryMenu
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="category">分類</param>
        /// <param name="menus">メニュー</param>
        public CategoryMenu(Category category, List<Menu> menus)
        {
            this.Category = category;
            this.Menus = menus;
        }

        /// <summary>
        /// 分類
        /// </summary>
        public Category Category { get; }

        /// <summary>
        /// メニュー
        /// </summary>
        public List<Menu> Menus { get; }

        /// <summary>
        /// バリデーション
        /// </summary>
        /// <param name="category">分類</param>
        /// <param name="menus">メニュー</param>
        /// <returns>有効/無効</returns>
        public virtual bool IsValid(Category category, List<Menu> menus)
        {
            return true;
        }

        /// <summary>
        /// メニュー一覧表示
        /// </summary>
        /// <returns>表示用メニュー一覧</returns>
        public abstract IEnumerable<string> Show();

        /// <summary>
        /// 入力されたNoのメニューを取得
        /// </summary>
        /// <param name="no">No</param>
        /// <returns>入力されたメニュー</returns>
        public Menu? GetMenu(int no)
        {
            return this.Menus.FirstOrDefault(x => x.No == no);
        }
    }
}