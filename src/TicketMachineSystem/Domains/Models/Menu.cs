namespace TicketMachineSystem.Domains.Models
{
    /// <summary>
    /// メニュークラス
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="categoryType">分類番号</param>
        /// <param name="name">名前</param>
        /// <param name="n">N</param>
        /// <param name="s">S</param>
        /// <param name="o">O</param>
        /// <param name="price">価格</param>
        public Menu(int id, CategoryType categoryType, string name, CategoryType n, int s, int o, int price)
        {
            this.Id = id;
            this.CategoryType = categoryType;
            this.Name = name;
            this.N = n;
            this.S = s;
            this.O = o;
            this.Price = price;
        }

        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// 分類番号
        /// </summary>
        public CategoryType CategoryType { get; }

        /// <summary>
        /// 商品名
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 分類番号
        /// </summary>
        public CategoryType N { get; }

        public int S { get; }

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
                return this.Price.ToString("C");
            }
        }
    }
}