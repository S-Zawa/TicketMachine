﻿using TicketMachineSystem.Domains.Models;
using TicketMachineSystem.Infrastructures.Csv;

namespace TicketMachineSystem // Note: actual namespace depends on the project name.
{
    /// <summary>
    /// Program
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            var ticketMachine = new TicketMachine(new MenuCsv(), new CategoryCsv());
            ticketMachine.ShowMainMenu();
            Console.ReadLine();
            var total = ticketMachine.GetTotalPrice();
            Console.WriteLine($"合計金額:{total}円");
        }
    }
}