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
        private static readonly int DiscountAmount = 50;
        private IMenuRepository _menuRepository;
        private ICategoryRepository _categoryRepository;

        private Category[] _categories = new Category[4];
        private List<Menu> _selectedMenus = new List<Menu>();
        private List<Menu> _menus = new List<Menu>();

        private List<Menu> _mainMenus = new List<Menu>();
        private List<Menu> _options = new List<Menu>();
        private Menu? _lastSelectedMenu = null;

        private SelectedMenu _selectedMenu;

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

            this._menus = this._menuRepository.GetAllMenu().ToList();
            this._mainMenus = this._menuRepository.GetMainMenu().ToList();

            var categories = this._categoryRepository.GetAll().ToList();

            var mainCategory = categories?.FirstOrDefault(x => x.No == CategoryNo.Main);
            this.MainMenu = new MainMenu(mainCategory, this._menuRepository.GetMainMenu().ToList());

            this._selectedMenu = new SelectedMenu();
        }

        public CategoryMenu CategoryMenu { get; }

        /// <summary>
        /// メインメニュー
        /// </summary>
        public MainMenu MainMenu { get; }

        /// <summary>
        /// 選択したメニュー一覧
        /// </summary>
        public List<Menu> SelectedMenus { get; private set; } = new List<Menu>();

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
            return this._selectedMenu.TotalPrice;
        }

        /// <summary>
        /// メインメニュー表示
        /// </summary>
        public void ShowMainMenu()
        {
            Console.WriteLine(this.MainMenu.Category.DisplayName);

            foreach (var mainMenu in this.MainMenu.Menus)
            {
                Console.WriteLine($"{nameof(mainMenu.No)}:{mainMenu.No} {nameof(mainMenu.Name)}:{mainMenu.Name} {nameof(mainMenu.Price)}:{mainMenu.DisplayPrice}");
            }
        }

        /// <summary>
        /// オプション表示
        /// </summary>
        public void ShowOption()
        {
            Console.WriteLine("---オプション---");

            var lastSelectedMenu = this._selectedMenus.LastOrDefault();
            foreach (var option in this._options.Where(x => x.O == lastSelectedMenu?.O))
            {
                Console.WriteLine($"{nameof(option.No)}:{option.No} {nameof(option.Name)}:{option.Name} {nameof(option.Price)}:{option.DisplayPrice}");
            }
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
        /// <param name="id">入力番号</param>
        /// <returns>有効な入力番号か</returns>
        public bool AddSelectedMenu(int id)
        {
            var selectedMenu = this._menus?.FirstOrDefault(x => x?.No == id);

            if (selectedMenu is null)
            {
                return false;
            }

            this._selectedMenu.Add(selectedMenu);
            return true;
        }
    }
}