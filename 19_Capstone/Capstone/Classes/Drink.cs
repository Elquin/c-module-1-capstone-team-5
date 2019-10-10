using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Drink : VendingItem
    {
        public Drink(string name, string price, string type) : base(name, price, type)
        { }

        public override string Consume()
        {
            return "Glug Glug, Yum!";
        }
    }
}
