using TicketMachineSystem.Domains.Models;

namespace TicketMachineSystem // Note: actual namespace depends on the project name.
{
    /// <summary>
    /// Program
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            var ticketMachine = new TicketMachine();

            var mainMenu = new Category(1);
            mainMenu.AddMenu(new Menu("牛丼", 1, 1, 1, 380));
            mainMenu.AddMenu(new Menu("豚丼", 1, 1, 1, 350));
            mainMenu.AddMenu(new Menu("鮭定食", 1, 1, 0, 450));

            var total = ticketMachine.GetTotal();
            Console.WriteLine($"合計金額:{total}円");
        }
    }
}