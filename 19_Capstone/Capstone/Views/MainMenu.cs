using Capstone.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using Capstone;

namespace Capstone.Views
{
    /// <summary>
    /// The top-level menu in our Market Application
    /// </summary>
    public class MainMenu : CLIMenu
    {
        private VendingMachine vend1;
        private Purchase purchase1;

        /// <summary>
        /// Constructor adds items to the top-level menu
        /// </summary>

        public MainMenu(VendingMachine vend1, Purchase purchase1) : base()
        {
            this.Title = "*** Main Menu ***";
            this.menuOptions.Add("1", "Display Vending Machine Items");
            this.menuOptions.Add("2", "Purchase");
            this.menuOptions.Add("3", "Exit");

            this.vend1 = vend1;
            this.purchase1 = purchase1;
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
                    break;
                case "2":
                    // Get some input form the user, and then do something

                    SubMenu sm = new SubMenu(vend1, purchase1);
                sm.Run();
                Pause("");
                break;
                case "3":
                    Console.WriteLine("Thanks for shopping!");
                    Console.ReadLine();
                    break;
            }
            return false;
        }
    }
}
