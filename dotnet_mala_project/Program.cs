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
            Console.Clear();
            DisplayMenu();

        }

        // take away
        static void TakeAway()
        {
            MenuTopBar();
            Console.WriteLine("TakeAway");
            Console.Clear();
            DisplayMenu();
        }

        // menu
        static void DisplayMenu()
        {
            MenuTopBar();
            ConsoleKeyInfo Readkey;
            int menuoption = 1;
            bool isSelected = false;
            (int left, int top) = Console.GetCursorPosition();
            Console.CursorVisible = false;
            string color = "\u001b[33;1m";
            while (!isSelected)
            {
                Console.SetCursorPosition(left, top);
                Console.WriteLine($"\n\t{(menuoption == 1 ? color + "[]" : "  ")}Single set\u001b[0m");
                Console.WriteLine($"\t{(menuoption == 2 ? color + "[]" : "  ")}Couple Set\u001b[0m");
                Console.WriteLine($"\t{(menuoption == 3 ? color + "[]" : "  ")}Custom Set\u001b[0m");

                Readkey = Console.ReadKey(true);

                switch (Readkey.Key)
                {
                    case ConsoleKey.DownArrow:
                        menuoption = (menuoption == 3 ? 1 : menuoption + 1);
                        break;
                    case ConsoleKey.UpArrow:
                        menuoption = (menuoption == 1 ? 3 : menuoption - 1);
                        break;
                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }
            }
            int seletedOption = menuoption;
            switch (seletedOption)
            {
                case 1:
                    SingleMeuTable();
                    break;
                case 2:
                    CoupleMenuTable();
                    break;
                case 3:
                    DisplayCustomMenuTable();
                    break;
            }
        }

        // single 
        static void SingleMeuTable()
        {
            MenuTopBar();
            //
        }

        // couple
        static void CoupleMenuTable()
        {
            //
            MenuTopBar();
        }

        // custom
        static void DisplayCustomMenuTable()
        {
            //
            MenuTopBar();
            Console.Clear();
            DisplayCustomMenuOptions();
        }

        // custom menu opetion
        static void DisplayCustomMenuOptions()
        {
            //
            int totalAmount = 0;
            List<int> itemQuantity = new List<int>(new int[10]);
            List<int> itemInStock = new List<int>() { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 };
            List<int> itemPrice = new List<int>() { 5, 5, 10, 5, 5, 10, 10, 7, 5, 5 };
            List<string> items = new List<string>() { "crab stick", "sausage", "noodle", "fish tofu", "chicken",
                                                    "mushroom", "enoki(1g)", "broccoli", "potato", "quail egg" };

            ConsoleKeyInfo Readkey;
            int menuoption = 1;
            bool isSelected = false;
            (int left, int top) = Console.GetCursorPosition();
            Console.CursorVisible = false;
            string color = "\u001b[33;1m";

            Console.WriteLine("\t   Items\t\tQuantity\t Instock\t  Price\n");
            while (!isSelected)
            {
                Console.SetCursorPosition(left, top);
                for (int i = 0; i < items.Count(); i++)
                {
                    Console.WriteLine($"\n\t{(menuoption == i + 1 ? color + "[]" : "  ")}{(items[i])}\u001b[0m" +
                        $"\t\t   {(itemQuantity[i])}" + $"\t\t    {itemInStock[i]}" + $"\t\t    {itemPrice[i]}");
            }
                Console.WriteLine("\n\tTotal amount: " + totalAmount);
                Readkey = Console.ReadKey(true);
                switch (Readkey.Key)
                {
                    case ConsoleKey.DownArrow:
                        menuoption = (menuoption == items.Count() ? 1 : menuoption + 1);
                        break;
                    case ConsoleKey.UpArrow:
                        menuoption = (menuoption == 1 ? items.Count() : menuoption - 1);
                        break;
                    case ConsoleKey.RightArrow:
                        if (itemInStock[menuoption - 1] > 0) { 
                            itemQuantity[menuoption - 1] += 1;
                            itemInStock[menuoption - 1] -= 1;
                            totalAmount += itemPrice[menuoption - 1];
                            ClearLine();
                        };
                        break;
                    case ConsoleKey.LeftArrow:
                        if (itemQuantity[menuoption - 1] > 0) { 
                            itemQuantity[menuoption - 1] -= 1;
                            itemInStock[menuoption - 1] += 1;
                            totalAmount -= itemPrice[menuoption - 1];
                            ClearLine();
                        }
                        break;
                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }

            }
            Console.WriteLine(totalAmount);
        }
        public static void ClearLine()
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
        }

        // spicy level
        static void DisplaySpicyLevelTable()
        {
            Console.WriteLine("Select your spicy level");
            ConsoleKeyInfo Readkey;
            int option = 1;
            bool isSelected = false;
            (int left, int top) = Console.GetCursorPosition();
            Console.CursorVisible = false;
            string color = "\u001b[33;1m";
            while (!isSelected)
            {
                Console.SetCursorPosition(left, top);
                Console.WriteLine($"\n\t{(option == 1 ? color + "[]" : "  ")}Mild\u001b[0m");
                Console.WriteLine($"\t{(option == 2 ? color + "[]" : "  ")}Medium\u001b[0m");
                Console.WriteLine($"\t{(option == 3 ? color + "[]" : "  ")}Hot\u001b[0m");
                Console.WriteLine($"\t{(option == 4 ? color + "[]" : "  ")}Extra Hot\u001b[0m");


                Readkey = Console.ReadKey(true);

                switch (Readkey.Key)
                {
                    case ConsoleKey.DownArrow:
                        option = (option == 4 ? 1 : option + 1);
                        break;
                    case ConsoleKey.UpArrow:
                        option = (option == 1 ? 4 : option - 1);
                        break;
                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }

            }
        }

        // dry or soup
        static void DispleyDryOrSoupTable()
        {
            Console.WriteLine("Dry or Soup");
            ConsoleKeyInfo Readkey;
            int option = 1;
            bool isSelected = false;
            (int left, int top) = Console.GetCursorPosition();
            Console.CursorVisible = false;
            string color = "\u001b[33;1m";
            while (!isSelected)
            {
                Console.SetCursorPosition(left, top);
                Console.WriteLine($"\n\t{(option == 1 ? color + "[]" : "  ")}Dry\u001b[0m");
                Console.WriteLine($"\t{(option == 2 ? color + "[]" : "  ")}Soup\u001b[0m");



                Readkey = Console.ReadKey(true);

                switch (Readkey.Key)
                {
                    case ConsoleKey.DownArrow:
                        option = (option == 2 ? 1 : 2);
                        break;
                    case ConsoleKey.UpArrow:
                        option = (option == 1 ? 2 : 1);
                        break;
                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }

            }
        }
        // drink
        static void DisplayDrinkTable()
        {
            //
            int totalAmount = 0;
            List<int> itemQuantity = new List<int>(new int[6]);
            List<int> itemInStock = new List<int>() { 9, 9, 9, 9, 9, 9};
            List<int> itemPrice = new List<int>() { 10, 15, 15, 15, 15, 10};
            List<string> items = new List<string>() { "Water bottle", "Coca-cola", "Sprite", "Melon Milk", "Sunkist",
                                                    "Iced Tea"};

            ConsoleKeyInfo Readkey;
            int menuoption = 1;
            bool isSelected = false;
            (int left, int top) = Console.GetCursorPosition();
            Console.CursorVisible = false;
            string color = "\u001b[33;1m";

            Console.WriteLine("\t   Items\t\tQuantity\t Instock\t  Price\n");
            while (!isSelected)
            {
                Console.SetCursorPosition(left, top);
                for (int i = 0; i < items.Count(); i++)
                {
                    Console.WriteLine($"\n\t{(menuoption == i + 1 ? color + "[]" : "  ")}{(items[i])}\u001b[0m" +
                        $"\t\t   {(itemQuantity[i])}" + $"\t\t    {itemInStock[i]}" + $"\t\t    {itemPrice[i]}");
                }
                Console.WriteLine("\n\tTotal amount: " + totalAmount);
                Readkey = Console.ReadKey(true);
                switch (Readkey.Key)
                {
                    case ConsoleKey.DownArrow:
                        menuoption = (menuoption == items.Count() ? 1 : menuoption + 1);
                        break;
                    case ConsoleKey.UpArrow:
                        menuoption = (menuoption == 1 ? items.Count() : menuoption - 1);
                        break;
                    case ConsoleKey.RightArrow:
                        if (itemInStock[menuoption - 1] > 0)
                        {
                            itemQuantity[menuoption - 1] += 1;
                            itemInStock[menuoption - 1] -= 1;
                            totalAmount += itemPrice[menuoption - 1];
                            ClearLine();
                        };
                        break;
                    case ConsoleKey.LeftArrow:
                        if (itemQuantity[menuoption - 1] > 0)
                        {
                            itemQuantity[menuoption - 1] -= 1;
                            itemInStock[menuoption - 1] += 1;
                            totalAmount -= itemPrice[menuoption - 1];
                            ClearLine();
                        }
                        break;
                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }

            }
            Console.WriteLine(totalAmount);

        }

        // card ( edit & details )
        static void DisplayCard_Edit_Details()
        {
            //
        }

        // coupon
        static void DisplayCouponTable(int totalAmount)
        {
            List<int> couponCode = new List<int>() { 998834, 969340, 010221, 020325, 992400, 183654, 490827 };
            Console.WriteLine("Do you have any coupon code?");
            double discount = 0.0;
            ConsoleKeyInfo Readkey;
            int option = 1;
            bool isSelected = false;
            (int left, int top) = Console.GetCursorPosition();
            Console.CursorVisible = false;
            string color = "\u001b[33;1m";

            while (!isSelected)
            {
                Console.WriteLine($"\n\t{(option == 1 ? color + ">" : " ")}Yes\u001b[0m");
                Console.WriteLine($"\t{(option == 2 ? color + ">" : " ")}No\u001b[0m");
            }

            Readkey = Console.ReadKey(true);

            switch (Readkey.Key)
            {
                case ConsoleKey.DownArrow:
                    option = (option == 2 ? 1 : 2);
                    break;
                case ConsoleKey.UpArrow:
                    option = (option == 1 ? 2 : 1);
                    break;
                case ConsoleKey.Enter:
                    isSelected = true;
                    break;

            }


            if (isSelected && option == 1)
            {
                Console.WriteLine("Enter your coupon code: ");
                int enteredCode;
                if (int.TryParse(Console.ReadLine(), out enteredCode))
                {
                    if (couponCode.Contains(enteredCode))
                    {
                        discount = totalAmount * 0.05;
                        Console.WriteLine($"Discount of {discount} Baht applied");
                    }
                    else
                    {
                        Console.WriteLine("Invalid coupon code. No discount applied");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coupon code. No discount applied");
                }
            }

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
