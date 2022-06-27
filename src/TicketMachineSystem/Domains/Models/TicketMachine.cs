using TicketMachineSystem.Domains.Entities;
using TicketMachineSystem.Domains.Repositories;
using TicketMachineSystem.Infrastructures;

namespace TicketMachineSystem.Domains.Models
{
    /// <summary>
    /// 券売機クラス
    /// </summary>
    public class TicketMachine
    {
        private IMenuRepository _menuRepository;

        private ICategoryRepository _categoryRepository;

        /// <summary>
        /// 選択したメニュー
        /// </summary>
        private SelectedMenu _selectedMenu;

        /// <summary>
        /// カテゴリ別メニュー
        /// </summary>
        private List<CategoryMenu> _categoryMenus;

        /// <summary>
        /// オプション
        /// </summary>
        private OptionMenu _optionMenu;

        /// <summary>
        /// カテゴリ
        /// </summary>
        private List<Category> _categories;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TicketMachine()
            : this(Factories.CreateMenuRepository(), Factories.CreateCategoryRepository())
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="menuRepository">メニューリポジトリ</param>
        /// <param name="categoryRepository">カテゴリリポジトリ</param>
        public TicketMachine(IMenuRepository menuRepository, ICategoryRepository categoryRepository)
        {
            this._menuRepository = menuRepository;
            this._categoryRepository = categoryRepository;

            this._categoryMenus = new List<CategoryMenu>();
            this._categories = this._categoryRepository.GetAll().ToList();

            this.SetCategoryMenus();

            this._selectedMenu = new SelectedMenu();
        }

        /// <summary>
        /// 全メニュー
        /// </summary>
        private IEnumerable<Menu> _allMenus
        {
            get
            {
                return this._categoryMenus.SelectMany(x => x.Menus);
            }
        }

        /// <summary>
        /// カテゴリ別メニュー関数テーブル
        /// </summary>
        private Dictionary<CategoryNo, Func<CategoryMenu>> _categoryMenuTable
        {
            get
            {
                return new Dictionary<CategoryNo, Func<CategoryMenu>>()
                {
                    { CategoryNo.Main, () => new MainMenu(this._categories.First(x => x.No == CategoryNo.Main), this._menuRepository.GetByCategoryNo(CategoryNo.Main).ToList()) },
                    { CategoryNo.Side1, () => new SideMenu1(this._categories.First(x => x.No == CategoryNo.Side1), this._menuRepository.GetByCategoryNo(CategoryNo.Side1).ToList()) },
                    { CategoryNo.Side2, () => new SideMenu2(this._categories.First(x => x.No == CategoryNo.Side2), this._menuRepository.GetByCategoryNo(CategoryNo.Side2).ToList()) },
                };
            }
        }

        /// <summary>
        /// 選択されたメニューの合計金額算出
        /// </summary>
        /// <returns>合計金額</returns>
        public int GetTotalPrice()
        {
            return this._selectedMenu.TotalPrice;
        }

        /// <summary>
        /// 選択されたメニューの表示用合計金額算出
        /// </summary>
        /// <returns>表示用合計金額</returns>
        public string GetDisplayTotalPrice()
        {
            return this._selectedMenu.DisplayTotalPrice;
        }

        /// <summary>
        /// 選択したメニューを全てクリア
        /// </summary>
        public void ClearSelectedMenu()
        {
            this._selectedMenu.Clear();
        }

        /// <summary>
        /// 入力番号を元に選択したメニューに追加
        /// </summary>
        /// <param name="no">入力番号</param>
        /// <returns>有効な入力番号か</returns>
        public bool AddSelectedMenu(int no)
        {
            var selectedMenu = this._allMenus?.FirstOrDefault(x => x?.No == no);

            if (selectedMenu is null)
            {
                return false;
            }

            this._selectedMenu.Add(selectedMenu);
            return true;
        }

        /// <summary>
        /// 注文した商品一覧
        /// </summary>
        public void DisplaySelectedMenuSummary()
        {
            Console.WriteLine("注文した商品");

            foreach (var menu in this._selectedMenu.Menus)
            {
                Console.WriteLine($"{menu.Name}:{menu.DisplayPrice}");
            }

            if (this._selectedMenu.IsDiscount)
            {
                Console.WriteLine($"値引き有り");
            }

            var total = this.GetDisplayTotalPrice();
            Console.WriteLine($"合計金額:{total}");
        }

        /// <summary>
        /// オプション注文
        /// </summary>
        /// <param name="selectedMenu">選択したメニュー</param>
        public void OrderOption(Menu selectedMenu)
        {
            var isExist = this._optionMenu.IsExistOptions(selectedMenu);

            if (!isExist)
            {
                return;
            }

            var optionMenus = this._optionMenu.GetDisplayMenus(selectedMenu);

            if (optionMenus == null || !optionMenus.Any())
            {
                return;
            }

            foreach (var optionMenu in optionMenus)
            {
                Console.WriteLine(optionMenu);
            }

            Console.Write(">Noを入力してください:");
            var input = Console.ReadLine();

            if (int.TryParse(input, out var no))
            {
                var selectedOption = this._optionMenu.GetMenu(no);

                if (selectedOption == null)
                {
                    this.OrderOption(selectedMenu);
                    return;
                }

                this._selectedMenu.Add(selectedOption);
                return;
            }
            else
            {
                this.OrderOption(selectedMenu);
            }
        }

        /// <summary>
        /// 注文
        /// </summary>
        public void Order()
        {
            for (var i = 0; i < this._categoryMenus.Count;)
            {
                var items = this._categoryMenus[i].GetDisplayMenus();
                foreach (var item in items)
                {
                    Console.WriteLine(item);
                }

                Console.Write(">Noを入力してください:");

                var input = Console.ReadLine();

                if (int.TryParse(input, out var no))
                {
                    var selectedMenu = this._categoryMenus[i].GetMenu(no);
                    if (selectedMenu != null)
                    {
                        this._selectedMenu.Add(selectedMenu);
                        this.OrderOption(selectedMenu);

                        i++;
                    }
                }
            }
        }

        /// <summary>
        /// カテゴリ別メニューセット
        /// </summary>
        /// <exception cref="NotSupportedException">不正な分類番号</exception>
        private void SetCategoryMenus()
        {
            foreach (var category in this._categories)
            {
                if (category.No == CategoryNo.Option)
                {
                    this._optionMenu = new OptionMenu(this._categories.First(x => x.No == CategoryNo.Option), this._menuRepository.GetByCategoryNo(CategoryNo.Option).ToList());
                    continue;
                }

                if (!this._categoryMenuTable.ContainsKey(category.No))
                {
                    throw new NotSupportedException();
                }

                this._categoryMenus.Add(this._categoryMenuTable[category.No]());
            }
        }
    }
}