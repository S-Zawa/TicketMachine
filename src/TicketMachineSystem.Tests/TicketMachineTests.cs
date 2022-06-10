using TicketMachineSystem.Domains.Models;
using TicketMachineSystem.Infrastructures.Csv;

namespace TicketMachineSystem.Tests
{
    public class TicketMachineTests
    {
        [Fact]
        public void AddSelectedMenu_ExistingMenu()
        {
            var ticketMachine = new TicketMachine(new MenuCsv());
            var isValid = ticketMachine.AddSelectedMenu(1);

            Assert.True(isValid);
            Assert.Single(ticketMachine.SelectedMenus);
            Assert.Equal("牛丼", ticketMachine?.SelectedMenus?.FirstOrDefault()?.Name);
        }

        [Fact]
        public void AddSelectedMenu_NotExistingMenu()
        {
            var ticketMachine = new TicketMachine(new MenuCsv());

            // 無効な商品番号
            var isValid = ticketMachine.AddSelectedMenu(999);
            Assert.False(isValid);
            Assert.Empty(ticketMachine.SelectedMenus);

            // 有効な商品番号
            isValid = ticketMachine.AddSelectedMenu(1);
            Assert.True(isValid);
            Assert.Single(ticketMachine.SelectedMenus);

            // 無効な商品番号
            isValid = ticketMachine.AddSelectedMenu(999);
            Assert.False(isValid);
            Assert.Single(ticketMachine.SelectedMenus);

            Assert.Equal("牛丼", ticketMachine?.SelectedMenus?.FirstOrDefault()?.Name);
        }
    }
}