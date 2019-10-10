using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Chip : VendingItem
    {
        public Chip(string name, string price, string type) : base(name, price, type)
        { }

        public override string Consume()
        {
            return "Crunch Crunch, Yum!";
        }
    }
}
