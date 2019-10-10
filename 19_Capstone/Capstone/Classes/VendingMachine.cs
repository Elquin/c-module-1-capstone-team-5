using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


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
    }
}
