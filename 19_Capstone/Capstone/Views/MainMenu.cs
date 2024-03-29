﻿using Capstone.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using Capstone;
using System.IO;

namespace Capstone.Views
{
    /// <summary>
    /// The top-level menu in our Market Application
    /// </summary>
    public class MainMenu : CLIMenu
    {

        private VendingMachine vend1;
  

        /// <summary>
        /// Constructor adds items to the top-level menu
        /// </summary>

        public MainMenu(VendingMachine vend1) : base()
        {
            this.Title = "************ Main Menu ************";
            this.menuOptions.Add("1", "Display Vending Machine Items");
            this.menuOptions.Add("2", "Purchase");
            this.menuOptions.Add("3", "Exit");
            this.menuOptions.Add("4", "Sales Report");

            this.vend1 = vend1;
        }


        /// <summary>
        /// The override of ExecuteSelection handles whatever selection was made by the user.
        /// This is where any business logic is executed.
        /// </summary>
        /// <param name="choice">"Key" of the user's menu selection</param>
        /// <returns></returns>
        protected override bool ExecuteSelection(string choice)
        {
            switch (choice)
            {
                //Display Vending Machine Items
                case "1":
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine($"Slot  Item                 Count      Price");
                    Console.WriteLine("===========================================");
                    foreach (KeyValuePair<string, Slot> entry in vend1.inventory)
                    {
                        string currentCount = entry.Value.Count.ToString();
                        if (currentCount == "0")
                        {
                            currentCount = "SOLD OUT";
                        }
                        Console.WriteLine($"{entry.Key, -5} {entry.Value.Item.Name, -20} {currentCount, -10} ${entry.Value.Item.Price}", -10);
                    }
                    Console.ReadLine();
                    return true;
                case "2":
                    // Get some input form the user, and then do something

                    SubMenu sm = new SubMenu(vend1);
                sm.Run();
                Pause("");
                break;
                case "3":
                    Console.WriteLine("Thanks for shopping!");
                    Console.ReadLine();
                    break;
                case "4":
                    using (StreamWriter sw = new StreamWriter("..\\..\\..\\..\\" + "SalesReport" + DateTime.Now.ToString("yyyy-MM-ddTHH-mm-ss") + ".txt"))
                    {
                        foreach (KeyValuePair<string, Slot> entry in vend1.inventory)
                        {
                            sw.WriteLine(entry.Value.Item.Name + "|" + (5 - entry.Value.Count));
                        }
                        sw.WriteLine();
                        sw.WriteLine($"Total Sales: ${vend1.totalSales}");
                    }
                    break;
            }
            return false;
        }
    }
}
