using Capstone.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Views
{
    public class SubMenu : CLIMenu
    {
        double currentMoneyProvided = 0;
        private VendingMachine vend1;
        private Purchase purchase1;


        /// <summary>
        /// Constructor adds items to the top-level menu
        /// </summary>
        public SubMenu(VendingMachine vend1, Purchase purchase1) : base()
        {
            this.Title = "*** Sub Menu ***";
            this.menuOptions.Add("1", "Feed Money");
            this.menuOptions.Add("2", "Select Product");
            this.menuOptions.Add("3", "Finish Transaction");

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
            Console.WriteLine($"Current Money Provided: ${currentMoneyProvided}");
            switch (choice)

            {
                case "1":

                    Console.WriteLine("Please enter the amount your would like to add in whole dollars only.");
                    string addedMoney = Console.ReadLine();
                    int addedMoneyInt = int.Parse(addedMoney);
                    currentMoneyProvided += addedMoneyInt;

                    //                    public double currentMoney = 0;
                    //public double FeedMoney(double addedMoney)
                    //{
                    //    currentMoney += addedMoney;
                    //    return currentMoney;
                    //}

                    Pause("Press any key");
                    return true;
                case "2":
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
                    Console.WriteLine("Please enter the Slot for the item you would like to purchase.");
                    string itemRequested = Console.ReadLine();

                    if (!vend1.inventory.ContainsKey(itemRequested))
                    {
                        Console.WriteLine("Please enter a valid Slot");
                    }
                    else if (vend1.inventory[itemRequested].Count == 0)
                    {
                        Console.WriteLine("SOLD OUT");
                    }
                    else if (vend1.inventory[itemRequested].Count != 0)
                    {
                        double priceOfItemDoub = double.Parse(vend1.inventory[itemRequested].Item.Price);
                        if (currentMoneyProvided >= priceOfItemDoub)
                        {
                            vend1.inventory[itemRequested].Count--;
                            currentMoneyProvided = currentMoneyProvided - priceOfItemDoub;
                            Console.WriteLine($"Thank you for purchasing {vend1.inventory[itemRequested].Item.Name} for ${vend1.inventory[itemRequested].Item.Price}!");
                            Console.WriteLine($"Your Money Remaining: ${currentMoneyProvided}");
                            Console.WriteLine($"{vend1.inventory[itemRequested].Item.Consume()}");
                        }
                        else
                        {
                            Console.WriteLine("You do not have enough money. Please feed more money into the machine.");
                        }


                        //goto SubMenu;
                    }
                    else
                    {
                        Console.WriteLine("Please make a valid selection.");
                    }
                    Console.ReadLine();
                    Pause("Press any key");
                    return true;
                case "3":
                    purchase1.MakeChange(currentMoneyProvided);

                    return false;
                    // if (itemRequested does not match a key)
                    // Console.WriteLine("Please enter a valid Slot.");
                    // if (count of item requested equals 0)
                    // Console.WriteLine("SOLD OUT");
                    // if (itemRequested does match a key)
                    // Dispense Method!
                    //   count of item --
                    //   current money - price of item
                    //   cw Name, Cost, Money Remaining (new current money)
                    //   print Yum Yum message based on type (if statement)
            }
            return false;
        }
    }
}

