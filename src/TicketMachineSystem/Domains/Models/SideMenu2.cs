using TicketMachineSystem.Domains.Entities;

namespace TicketMachineSystem.Domains.Models
{
    /// <summary>
    /// サイドメニュー
    /// </summary>
    public class SideMenu2 : CategoryMenu
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="category">カテゴリ</param>
        /// <param name="menus">メニュー</param>
        public SideMenu2(Category category, List<Menu> menus)
            : base(category, menus)
        {
            if (!this.IsValid(category, menus))
            {
                throw new ArgumentException();
            }
        }

        /// <inheritdoc/>
        public override bool IsValid(Category category, List<Menu> menus)
        {
            if (category is null || menus is null)
            {
                return false;
            }

            if (category.No != CategoryNo.Side2)
            {
                return false;
            }

            if (menus.Any(x => x.N != CategoryNo.Side2))
            {
                return false;
            }

            return true;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> Show()
        {
            var showItems = new List<string>();
            showItems.Add(this.Category.DisplayName);
            showItems.AddRange(this.Menus.Select(x => $"{x.No}:{x.Name} / {x.DisplayPrice}"));

            return showItems;
        }
    }
}