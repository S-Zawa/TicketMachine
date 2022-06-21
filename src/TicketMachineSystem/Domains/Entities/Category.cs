using TicketMachineSystem.Domains.Models;

namespace TicketMachineSystem.Domains.Entities
{
    /// <summary>
    /// カテゴリークラス
    /// </summary>
    public class Category
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="no">分類番号</param>
        /// <param name="name">カテゴリ名</param>
        public Category(CategoryNo no, string name)
        {
            this.No = no;
            this.Name = name;
        }

        /// <summary>
        /// 分類番号
        /// </summary>
        public CategoryNo No { get; }

        /// <summary>
        /// カテゴリ名
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 表示用カテゴリ名
        /// </summary>
        public string DisplayName
        {
            get
            {
                return $"----------{this.Name}----------";
            }
        }
    }
}