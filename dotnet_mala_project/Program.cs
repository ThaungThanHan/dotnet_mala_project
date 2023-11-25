using System;
using ConsoleTables;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MenuDrivenCLI
{
    class Program
    {

        // Main
        static void Main(string[] args)
        {
            MenuTopBar();
            Console.WriteLine("Welcome to the DotNet-MaLa Menu CLI!");
            Console.WriteLine("Choose an option:");

            ConsoleKeyInfo Readkey;
            int option = 1;
            bool isSelected = false;
            (int left, int top) = Console.GetCursorPosition();
            Console.CursorVisible = false;
            string color = "\u001b[33;1m";
            while (!isSelected)
            {
                Console.SetCursorPosition(left, top);
                Console.WriteLine($"\n\t{(option == 1 ? color + "[]" : "  ")}Dine IN\u001b[0m");
                Console.WriteLine($"\t{(option == 2 ? color + "[]" : "  ")}Take Away\u001b[0m");
            
            Readkey = Console.ReadKey(true);

            switch(Readkey.Key){
                case ConsoleKey.DownArrow:
                 option = (option == 2? 1: 2); 
                 break;
                case ConsoleKey.UpArrow:
                    option = (option == 1 ? 2 : 1);
                    break;
                case ConsoleKey.Enter:
                  isSelected = true;
                  break;
            }
            }
            int seletedOption = option;
            switch (seletedOption){
                case 1:
                    DineIn();
                    break;
                case 2:
                   TakeAway();
                   break;


            }

        }

        static void MenuTopBar()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\n\tDotNet-MaLa Menu CLI!\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        // dine in
        static void DineIn()
        {
            MenuTopBar();
            Console.WriteLine("DineIN");
            // DisplayMenu();
        }

        // take away
        static void TakeAway()
        {
            MenuTopBar();
            Console.WriteLine("TakeAway");
            // DisplayMenu();
        }

        // menu
        static void DisplayMenu()
        {
            MenuTopBar();
            bool exitRequested = false;

        }

        // single 
        static void SingleMeuTable()
        {
            MenuTopBar();
            //
        }

        // couple
        static void DisplayMenuTable()
        {
            //
        }

        // custom
        static void DisplayCustomMenuTable()
        {
            //
        }

        // custom menu opetion
        static void DisplayCustomMenuOpetion()
        {
            //
        }

        // spicy level
        static void DisplaySpicyLivelTable()
        {
            //
        }

        // dry or soup
        static void DispleyDryOrSoupTable()
        {
            //
        }

        // drink
        static void DisplayDrinkTable()
        {
            //
        }

        // card ( edit & details )
        static void DisplayCard_Edit_Details()
        {
            //
        }

        // coupon
        static void DisplayCouponTable()
        {
            //
        }

        // purchace
        static void Purchace()
        {
            //
        }

        // yes
        static void Yes()
        {
            //
        }

        // no
        static void No()
        {
            //
        }

        // invoice 
        static void DisplayInvoice()
        {
            // var table = new ConsoleTable("Option", "Description");
            // table.AddRow(1, "Option 1");
            // table.AddRow(2, "Option 2");
            // table.AddRow(3, "Option 3");
            // table.AddRow(4, "Exit");

            // table.Write();
        }

    }
}
