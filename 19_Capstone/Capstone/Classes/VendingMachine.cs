using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace Capstone.Classes
{
    class VendingMachine
    {
        public List<string> inventory = new List<string>();
        string input = "";
        public string Loader()
        {

            string inputPath = @"..\..\..\..\vendingmachine.csv";
            
            using (StreamReader str = new StreamReader(inputPath))
            {
                while (!str.EndOfStream)
                {
                    input = str.ReadLine();
                    inventory.Add(input);
                    Console.WriteLine(input);
                }
                Console.ReadLine();
            }
            return input;
        }
    }
}
