using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Slot
    {
        //TODO Talk to Craig about this bit.
        public Slot(int count, VendingItem item)
        {
            Count = count;
            Item = item;
        }

        public int Count { get; set; }
        public VendingItem Item { get; private set;}
    }
}
