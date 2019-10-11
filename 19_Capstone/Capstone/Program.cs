using Capstone.Views;
using System;
using System.IO;
using Capstone.Classes;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            VendingMachine vender = new VendingMachine();
            vender.Loader();

            Purchase purchase = new Purchase();

            MainMenu mainMenu = new MainMenu(vender, purchase);
            mainMenu.Run();

   
        }

    }
}
