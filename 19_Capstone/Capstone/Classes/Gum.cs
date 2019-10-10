using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Gum : VendingItem
    {
        public Gum(string name, string price, string type) : base(name, price, type)
        { }

        public override string Consume()
        {
            return "Chew Chew, Yum!";
        }
    }
}
