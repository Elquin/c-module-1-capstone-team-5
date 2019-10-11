using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Purchase
    {
        public double currentMoney = 0;
        public double FeedMoney(int addedMoney)
        {
            currentMoney += addedMoney;
            return currentMoney;
        }

        public void DispenseItem()
        {

        }

        public int quarterCount = 0;
        public int dimeCount = 0;
        public int nickelCount = 0;
        public double MakeChange(double currentMoney)
        {
            Console.WriteLine($"Here is your change: ${currentMoney}");

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

        
    }
}
