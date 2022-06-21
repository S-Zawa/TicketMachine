using TicketMachineSystem.Domains.Entities;
using TicketMachineSystem.Domains.Models;

namespace TicketMachineSystem.Tests.Domains.Models
{
    public class SelectedMenuTests
    {
        private static readonly List<Menu> Menus1 = new List<Menu>()
        {
            new Menu( 1, "牛丼", CategoryNo.Main, 1, 0, 380),
            new Menu(4,"野菜サラダ",CategoryNo.Side1,2,2,100),
            new Menu(9,"みそ汁",CategoryNo.Side2,1,0,60)
        };

        private static readonly List<Menu> Menus2 = new List<Menu>()
        {
            new Menu( 1, "牛丼", CategoryNo.Main, 1, 0, 380),
            new Menu(4,"野菜サラダ",CategoryNo.Side1,2,2,100),
            new Menu(12,"並",CategoryNo.Option,0,1,0)
        };

        [Fact]
        public void IsEmpty()
        {
            var selectedMenu = new SelectedMenu();

            Assert.True(selectedMenu.IsEmpty());

            selectedMenu.Add(new Menu(1, "牛丼", CategoryNo.Main, 1, 1, 500));
            Assert.False(selectedMenu.IsEmpty());

            selectedMenu.Clear();
            Assert.True(selectedMenu.IsEmpty());
        }

        [Fact]
        public void TotalPrice_DiscountPrice()
        {
            var selectedMenu = new SelectedMenu();
            foreach (var menu in Menus1)
            {
                selectedMenu.Add(menu);
            }

            Assert.Equal(490, selectedMenu.TotalPrice);
            Assert.Equal("¥490", selectedMenu.DisplayTotalPrice);
        }

        [Fact]
        public void TotalPrice_NotDiscountPrice()
        {
            var selectedMenu = new SelectedMenu();
            foreach (var menu in Menus2)
            {
                selectedMenu.Add(menu);
            }
            Assert.Equal(480, selectedMenu.TotalPrice);
            Assert.Equal("¥480", selectedMenu.DisplayTotalPrice);
        }

        [Fact]
        public void TotalPrice_SelectedMenuIsEmpty()
        {
            var selectedMenu = new SelectedMenu();
            Assert.Equal(0, selectedMenu.TotalPrice);
            Assert.Equal("¥0", selectedMenu.DisplayTotalPrice);

            selectedMenu.Add(new Menu(1, "牛丼", CategoryNo.Main, 1, 1, 500));
            Assert.Equal(500, selectedMenu.TotalPrice);
            Assert.Equal("¥500", selectedMenu.DisplayTotalPrice);

            selectedMenu.Clear();
            Assert.Equal(0, selectedMenu.TotalPrice);
            Assert.Equal("¥0", selectedMenu.DisplayTotalPrice);
        }
    }
}