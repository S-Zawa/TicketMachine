using TicketMachineSystem.Domains.Models;
using TicketMachineSystem.Infrastructures.Csv;

namespace TicketMachineSystem.Tests.Domains.Models
{
    public class TicketMachineTests
    {
        [Fact]
        public void AddSelectedMenu_ExistingMenu()
        {
            var ticketMachine = new TicketMachine(new Infrastructures.Csv.MenuCsv(), new CategoryCsv());
            var isValid = ticketMachine.AddSelectedMenu(1);

            Assert.True(isValid);
        }

        [Fact]
        public void AddSelectedMenu_NotExistingMenu()
        {
            var ticketMachine = new TicketMachine(new MenuCsv(), new CategoryCsv());

            // ñ≥å¯Ç»è§ïiî‘çÜ
            var isValid = ticketMachine.AddSelectedMenu(999);
            Assert.False(isValid);
        }
    }
}