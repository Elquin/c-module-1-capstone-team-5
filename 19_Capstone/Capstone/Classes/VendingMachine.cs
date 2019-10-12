using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Capstone.Views;


namespace Capstone.Classes
{
    public class VendingMachine
    {
        public Dictionary<string, Slot> inventory = new Dictionary<string, Slot>();

        public string Loader()
        {
            string input = "";
            string inputPath = @"..\..\..\..\vendingmachine.csv";

            using (StreamReader str = new StreamReader(inputPath))
            {
                while (!str.EndOfStream)
                {
                    input = str.ReadLine();
                    string[] properties = input.Split("|");

                    VendingItem vi = null;

                    if (properties[3] == "Chip")
                    {
                        vi = new Chip(properties[1], properties[2], properties[3]);
                    }
                    else if (properties[3] == "Gum")
                    {
                        vi = new Gum(properties[1], properties[2], properties[3]);
                    }
                    else if (properties[3] == "Drink")
                    {
                        vi = new Drink(properties[1], properties[2], properties[3]);
                    }
                    else if (properties[3] == "Candy")
                    {
                        vi = new Candy(properties[1], properties[2], properties[3]);
                    }
                    Slot newSlot = new Slot(5, vi);
                    inventory.Add(properties[0], newSlot);
                }
            }
            return input;
        }



        public double currentMoneyProvided = 0;
        public void FeedMoney(double addedMoneyDouble)
        {
            currentMoneyProvided += addedMoneyDouble;

            using (StreamWriter sw = new StreamWriter(@"..\..\..\..\Log.txt", true))
            {
                sw.WriteLine(DateTime.Now + "\t" + ("FEED MONEY".PadRight(30)) + (addedMoneyDouble.ToString("C2").PadRight(10)) + currentMoneyProvided.ToString("C2"));

            }
        }

        public int quarterCount = 0;
        public int dimeCount = 0;
        public int nickelCount = 0;
        public double MakeChange(double currentMoney)
        {
            Console.WriteLine($"Here is your change: ${currentMoney}");
            using (StreamWriter sw = new StreamWriter(@"..\..\..\..\Log.txt", true))
            {
                sw.WriteLine(DateTime.Now + "\t" + ("GIVE CHANGE".PadRight(30)) + (currentMoney.ToString("C2").PadRight(10)) + "$0.00");

            }

            while (currentMoney >= .25)
            {
                currentMoney -= .25;
                quarterCount++;
            }
            while (currentMoney >= .10)
            {
                currentMoney -= .10;
                dimeCount++;
            }
            while (currentMoney >= .05)
            {
                currentMoney -= .05;
                nickelCount++;
            }
            Console.WriteLine($"Your change is {quarterCount} quarters, {dimeCount} dimes, and {nickelCount} nickels.");
            currentMoney = 0;
            return currentMoney;
        }

        public double totalSales = 0;
        public void Dispense(string itemRequested)
        {

            if (!inventory.ContainsKey(itemRequested))
            {
                Console.WriteLine("Please enter a valid Slot");

            }
            else if (inventory[itemRequested].Count == 0)
            {
                Console.WriteLine("SOLD OUT");
            }
            else if (inventory[itemRequested].Count != 0)
            {
                double priceOfItemDoub = double.Parse(inventory[itemRequested].Item.Price);
                if (currentMoneyProvided >= priceOfItemDoub)
                {
                    inventory[itemRequested].Count--;
                    currentMoneyProvided -= priceOfItemDoub;
                    Console.Clear();
                    Console.WriteLine($"Thank you for purchasing {inventory[itemRequested].Item.Name} for ${inventory[itemRequested].Item.Price}!");
                    Console.WriteLine($"Your Money Remaining: ${currentMoneyProvided}");
                    Console.WriteLine($"{inventory[itemRequested].Item.Consume()}");

                    totalSales += priceOfItemDoub;

                    using (StreamWriter sw = new StreamWriter(@"..\..\..\..\Log.txt", true))
                    {
                        sw.WriteLine(DateTime.Now + "\t" + (inventory[itemRequested].Item.Name.PadRight(27)) + (itemRequested.PadRight(3)) + "$" + (inventory[itemRequested].Item.Price.PadRight(9)) + currentMoneyProvided.ToString("C2"));

                    }
                }
                else
                {
                    Console.WriteLine("You do not have enough money. Please feed more money into the machine.");
                }
            }
            else
            {
                Console.WriteLine("Please make a valid selection.");
            }
            Console.ReadLine();
        }
    }
}

