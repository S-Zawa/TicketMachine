namespace TicketMachineSystem.Domains.Models
{
    /// <summary>
    /// 券売機クラス
    /// </summary>
    internal class TicketMachine
    {
        private Category[] _categories = new Category[4];
        private List<Menu> _selectedMenus = new List<Menu>();

        /// <summary>
        /// メインメニュー登録
        /// </summary>
        /// <param name="category">カテゴリ</param>
        public void SetMainMenu(Category category)
        {
            this._categories[0] = category;
        }

        /// <summary>
        /// サイド1登録
        /// </summary>
        /// <param name="category">カテゴリ</param>
        public void SetSide1(Category category)
        {
            this._categories[1] = category;
        }

        /// <summary>
        /// サイド2登録
        /// </summary>
        /// <param name="category">カテゴリ</param>
        public void SetSide2(Category category)
        {
            this._categories[2] = category;
        }

        /// <summary>
        /// オプション登録
        /// </summary>
        /// <param name="category">カテゴリ</param>
        public void SetOption(Category category)
        {
            this._categories[3] = category;
        }

        /// <summary>
        /// 選択されたメニューの合計金額算出
        /// </summary>
        /// <returns>合計金額</returns>
        public int GetTotal()
        {
            var total = this._selectedMenus.Sum(selectedMenu => selectedMenu.Price);
            var c1 = this._selectedMenus.Any(x => x.N == 1);
            var c2 = this._selectedMenus.Any(x => x.N == 2);
            var c3 = this._selectedMenus.Any(x => x.N == 3);

            if (c1 && c2 && c3)
            {
                total -= 50;
            }

            return total;
        }
    }
}