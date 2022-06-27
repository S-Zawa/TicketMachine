using TicketMachineSystem.Domains.Entities;
using TicketMachineSystem.Domains.Helpers;

namespace TicketMachineSystem.Domains.Models
{
    /// <summary>
    /// 選択したメニュー
    /// </summary>
    public class SelectedMenu
    {
        private static readonly int DiscountAmount = 50;

        private List<Menu> menus;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SelectedMenu()
        {
            this.menus = new List<Menu>();
        }

        /// <summary>
        /// メニュー
        /// </summary>
        public List<Menu> Menus
        {
            get => this.menus;
            private set => this.menus = value;
        }

        /// <summary>
        /// 合計金額
        /// </summary>
        public int TotalPrice
        {
            get
            {
                return this.GetTotalPrice();
            }
        }

        /// <summary>
        /// 表示用合計金額
        /// </summary>
        public string DisplayTotalPrice
        {
            get
            {
                return this.TotalPrice.ToStringYen();
            }
        }

        /// <summary>
        /// 値引きあり
        /// </summary>
        public bool IsDiscount
        {
            get
            {
                return this.menus.Select(x => x.N).ToList().ContainsAll(new CategoryNo[] { CategoryNo.Main, CategoryNo.Side1, CategoryNo.Side2 });
            }
        }

        /// <summary>
        /// 選択したメニューに追加
        /// </summary>
        /// <param name="menu">メニュー</param>
        public void Add(Menu menu)
        {
            this.menus.Add(menu);
        }

        /// <summary>
        /// 最後に追加したメニューを取得
        /// </summary>
        /// <returns>最後に追加したメニュー</returns>
        public Menu GetLastSelectedMenu()
        {
            return this.menus.Last();
        }

        /// <summary>
        /// 選択したメニューが空か
        /// </summary>
        /// <returns>true/false</returns>
        public bool IsEmpty()
        {
            return this.menus.Count == 0;
        }

        /// <summary>
        /// 選択したメニューをクリアする
        /// </summary>
        public void Clear()
        {
            if (this.IsEmpty())
            {
                return;
            }

            this.menus = new List<Menu>();
        }

        /// <summary>
        /// 合計金額算出
        /// </summary>
        /// <returns>合計金額</returns>
        private int GetTotalPrice()
        {
            var totalPrice = this.menus.Sum(x => x.Price);

            if (this.IsDiscount)
            {
                return totalPrice - DiscountAmount;
            }

            return totalPrice;
        }
    }
}