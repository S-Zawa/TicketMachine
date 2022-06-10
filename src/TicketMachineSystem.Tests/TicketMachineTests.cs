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
            Assert.Equal("����", ticketMachine?.SelectedMenus?.FirstOrDefault()?.Name);
        }

        [Fact]
        public void AddSelectedMenu_NotExistingMenu()
        {
            var ticketMachine = new TicketMachine(new MenuCsv());

            // �����ȏ��i�ԍ�
            var isValid = ticketMachine.AddSelectedMenu(999);
            Assert.False(isValid);
            Assert.Empty(ticketMachine.SelectedMenus);

            // �L���ȏ��i�ԍ�
            isValid = ticketMachine.AddSelectedMenu(1);
            Assert.True(isValid);
            Assert.Single(ticketMachine.SelectedMenus);

            // �����ȏ��i�ԍ�
            isValid = ticketMachine.AddSelectedMenu(999);
            Assert.False(isValid);
            Assert.Single(ticketMachine.SelectedMenus);

            Assert.Equal("����", ticketMachine?.SelectedMenus?.FirstOrDefault()?.Name);
        }
    }
}