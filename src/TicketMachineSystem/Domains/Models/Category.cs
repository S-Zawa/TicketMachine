namespace TicketMachineSystem.Domains.Models
{
    /// <summary>
    /// カテゴリークラス
    /// </summary>
    internal class Category
    {
        private int _no { get; }

        private List<Menu> _menus = new List<Menu>();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="no">分類番号</param>
        public Category(int no)
        {
            this._no = no;
        }

        /// <summary>
        /// メニュー追加
        /// </summary>
        /// <param name="menu">メニュー</param>
        public void AddMenu(Menu menu)
        {
            this._menus.Add(menu);
        }
    }
}