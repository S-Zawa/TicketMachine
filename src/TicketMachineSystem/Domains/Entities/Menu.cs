using TicketMachineSystem.Domains.Helpers;
using TicketMachineSystem.Domains.Models;

namespace TicketMachineSystem.Domains.Entities
{
    /// <summary>
    /// メニュークラス
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="no">no</param>
        /// <param name="name">名前</param>
        /// <param name="n">N</param>
        /// <param name="s">S</param>
        /// <param name="o">O</param>
        /// <param name="price">価格</param>
        public Menu(int no, string name, CategoryNo n, int s, int o, int price)
        {
            this.No = no;
            this.Name = name;
            this.N = n;
            this.S = s;
            this.O = o;
            this.Price = price;
        }

        /// <summary>
        /// No
        /// </summary>
        public int No { get; }

        /// <summary>
        /// 商品名
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 分類番号
        /// </summary>
        public CategoryNo N { get; }

        /// <summary>
        /// S
        /// </summary>
        public int S { get; }

        /// <summary>
        /// O
        /// </summary>
        public int O { get; }

        /// <summary>
        /// 価格
        /// </summary>
        public int Price { get; }

        /// <summary>
        /// 表示金額
        /// </summary>
        public string DisplayPrice
        {
            get
            {
                return this.Price.ToStringYen();
            }
        }
    }
}