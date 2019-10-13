using Capstone.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Views
{
    public class SubMenu : CLIMenu
    {
        public decimal totalSales = 0;
        private VendingMachine vend1;


        /// <summary>
        /// Constructor adds items to the top-level menu
        /// </summary>
        public SubMenu(VendingMachine vend1) : base()
        {
            this.Title = "*** Sub Menu ***";
            this.menuOptions.Add("1", "Feed Money");
            this.menuOptions.Add("2", "Select Product");
            this.menuOptions.Add("3", "Finish Transaction");

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
            Console.WriteLine();
            Console.WriteLine("Current Money Provided: " + "$" + vend1.currentMoneyProvided.ToString(), "C2");
            switch (choice)

            {
                case "1":
                    Console.Clear();
                    Console.WriteLine($"Current Money Provided: ${vend1.currentMoneyProvided}");
                    Console.WriteLine("Please enter the amount your would like to add in whole dollars only.");
                    string addedMoney = Console.ReadLine();

                    if (decimal.Parse(addedMoney) % 1 != 0 || decimal.Parse(addedMoney) < 1)
                    {
                        Console.WriteLine("Please enter a valid whole dollar amount.");
                        addedMoney = "";
                        Console.ReadLine();
                    }
                    else
                    {
                        int addedMoneyInt = int.Parse(addedMoney);
                        vend1.FeedMoney(addedMoneyInt);
                    }
                    
                   // Pause("Press any key");
                    return true;

                case "2":
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
                        Console.WriteLine($"{entry.Key,-5} {entry.Value.Item.Name,-20} {currentCount,-10} ${entry.Value.Item.Price}", -10);
                    }


                    Console.WriteLine();
                    Console.WriteLine($"Current Money Provided: ${vend1.currentMoneyProvided}");
                    Console.WriteLine("Please enter the Slot for the item you would like to purchase.");
                    string itemRequested = Console.ReadLine();

                    vend1.Dispense(itemRequested);

                    //Pause("Press any key");
                    return true;
                case "3":

                    Console.Clear();
          
                    vend1.MakeChange(vend1.currentMoneyProvided);
                    Console.ReadLine();

                    //Pause("Press any key");

                    vend1.currentMoneyProvided = 0;
                    MainMenu menu = new MainMenu(vend1);
                    menu.Run();

                    return false;
            }
            return false;
        }
    }
}

