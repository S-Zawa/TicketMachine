using TicketMachineSystem.Domains.Entities;

namespace TicketMachineSystem.Domains.Models
{
    /// <summary>
    /// オプション
    /// </summary>
    public class OptionMenu : CategoryMenu
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="category">カテゴリ</param>
        /// <param name="menus">メニュー</param>
        public OptionMenu(Category category, List<Menu> menus)
            : base(category, menus)
        {
        }

        /// <inheritdoc/>
        public override bool IsValid(Category category, List<Menu> menus)
        {
            if (category is null || menus is null)
            {
                return false;
            }

            if (category.No != CategoryNo.Option)
            {
                return false;
            }

            if (menus.Any(x => x.N != CategoryNo.Option))
            {
                return false;
            }

            return true;
        }
    }
}