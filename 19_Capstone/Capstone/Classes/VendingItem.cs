using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Classes;

namespace Capstone.Classes
{
    public abstract class VendingItem
    {    
        public VendingItem(string name, string price, string type)
        {
            Type = type;
            Price = price;
            Name = name;
        }

        public string Name { get; private set; }
        public string Price { get; private set; }
        public string Type { get; private set; }

        public abstract string Consume();
    }
}


