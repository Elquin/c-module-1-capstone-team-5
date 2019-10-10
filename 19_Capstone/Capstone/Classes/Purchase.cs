using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    class Purchase
    {
        public double currentMoney = 0;
        public double FeedMoney(double addedMoney)
        {
            currentMoney += addedMoney;
            return currentMoney;
        }

        public void PurchaseItem(string location)
        {
           // Slot.Count--;
        }

        public void DispenseItem()
        {

        }

        public int quarterCount = 0;
        public int dimeCount = 0;
        public int nickelCount = 0;
        public double MakeChange()
        {
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
            return 0.00;

        }

        
    }
}
