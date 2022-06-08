namespace TicketMachineSystem.Domains.Models
{
    /// <summary>
    /// メニュークラス
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// 商品名
        /// </summary>
        public string Name { get; }

        public int N { get; }

        public int S { get; }

        public int O { get; }

        /// <summary>
        /// 価格
        /// </summary>
        public int Price { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="name">商品名</param>
        /// <param name="n">N</param>
        /// <param name="s">S</param>
        /// <param name="o">O</param>
        /// <param name="price">価格</param>
        public Menu(string name, int n, int s, int o, int price)
        {
            this.Name = name;
            this.N = n;
            this.S = s;
            this.O = o;
            this.Price = price;
        }
    }
}