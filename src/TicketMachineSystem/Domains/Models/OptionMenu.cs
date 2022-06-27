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

        /// <inheritdoc/>
        public override IEnumerable<string> GetDisplayMenus()
        {
            var showItems = new List<string>();
            showItems.Add(this.Category.DisplayName);
            showItems.AddRange(
                this.Menus
                .Select(y => $"{y.No}:{y.Name} / {y.DisplayPrice}"));

            return showItems;
        }

        /// <summary>
        /// オプション有り
        /// </summary>
        /// <param name="menu">メニュー</param>
        /// <returns>true / false</returns>
        public bool IsExistOptions(Menu menu)
        {
            return this.Menus.Any(x => x.O == menu.O);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetDisplayMenus(Menu menu)
        {
            var showItems = new List<string>();
            var options = this.GetOptionMenus(menu);
            if (options == null || !options.Any())
            {
                return new List<string>();
            }

            showItems.Add(this.Category.DisplayName);

            showItems.AddRange(
                options.Select(
                    y => $"{y.No}:{y.Name} / {y.DisplayPrice}"));
            return showItems;
        }

        /// <summary>
        /// メニュー対応したオプションを取得
        /// </summary>
        /// <param name="menu">メニュー</param>
        /// <returns>オプション</returns>
        public IEnumerable<Menu> GetOptionMenus(Menu menu)
        {
            return this.Menus.Where(x => x.O == menu.O);
        }
    }
}