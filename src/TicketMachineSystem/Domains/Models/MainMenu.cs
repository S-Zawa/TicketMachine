using TicketMachineSystem.Domains.Entities;

namespace TicketMachineSystem.Domains.Models
{
    /// <summary>
    /// メインメニュー
    /// </summary>
    public class MainMenu : CategoryMenu
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="category">カテゴリ</param>
        /// <param name="menus">メニュー</param>
        public MainMenu(Category category, List<Menu> menus)
            : base(category, menus)
        {
            if (!this.IsValid(category, menus))
            {
                throw new ArgumentException();
            }
        }

        /// <summary>
        /// バリデーション
        /// </summary>
        /// <param name="category">分類</param>
        /// <param name="menus">メニュー</param>
        /// <returns>有効/無効</returns>
        public override bool IsValid(Category category, List<Menu> menus)
        {
            if (category is null || menus is null)
            {
                return false;
            }

            if (category.No != CategoryNo.Main)
            {
                return false;
            }

            if (menus.Any(x => x.N != CategoryNo.Main))
            {
                return false;
            }

            return true;
        }
    }
}