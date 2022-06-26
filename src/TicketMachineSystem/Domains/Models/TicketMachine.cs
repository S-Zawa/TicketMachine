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
                    { CategoryNo.Option, () => new OptionMenu(this._categories.First(x => x.No == CategoryNo.Option), this._menuRepository.GetByCategoryNo(CategoryNo.Option).ToList()) },
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
        /// メインメニュー表示
        /// </summary>
        public void ShowMainMenu()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// オプション表示
        /// </summary>
        public void ShowOption()
        {
            throw new NotImplementedException();
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
        /// カテゴリ別メニューセット
        /// </summary>
        /// <exception cref="NotSupportedException">不正な分類番号</exception>
        private void SetCategoryMenus()
        {
            foreach (var category in this._categories)
            {
                if (!this._categoryMenuTable.ContainsKey(category.No))
                {
                    throw new NotSupportedException();
                }

                this._categoryMenus.Add(this._categoryMenuTable[category.No]());
            }
        }

        /// <summary>
        /// メニュー一覧の表示
        /// </summary>
        public void Show()
        {
            for (var i = 0; i < _categoryMenus.Count;)
            {
                var items = _categoryMenus[i].Show();
                foreach (var item in items)
                {
                    Console.WriteLine(item);
                }

                Console.Write(">Noを入力してください:");

                var input = Console.ReadLine();

                if (int.TryParse(input, out var no))
                {
                    var selectedMenu = _categoryMenus[i].GetMenu(no);
                    if (selectedMenu is not null)
                    {
                        this._selectedMenu.Add(selectedMenu);

                        i++;
                    }
                }
            }
        }
    }
}