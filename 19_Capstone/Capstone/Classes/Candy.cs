using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Candy : VendingItem
    {
        public Candy(string name, string price, string type) : base(name, price, type)
        { }

        public override string Consume()
        {
            return "Munch Munch, Yum!";
        }
    }
}
