using System;
using ConsoleTables;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Numerics;

namespace MenuDrivenCLI
{
    class Program
    {
        // menu cli
        public static int menu_option = 0;
        public static List<int> couponCode = new List<int>() { 998834, 969340, 010221, 020325, 992400, 183654, 490827 };


        public static int menu_spicyLevel = 0;

        // menu marlar
        public static int menu_totalAmount = 0;

        public static List<int> menu_itemQuantity = new List<int>();
        public static List<int> menu_itemInStock = new List<int>();
        public static List<int> menu_itemPrice = new List<int>() { 5, 5, 10, 5, 5, 10, 10, 7, 5, 5 };
        public static List<string> menu_items = new List<string>() { "crab stick", "sausage", "noodle", "fish tofu", "chicken",
                                                    "mushroom", "enoki(1g)", "broccoli", "potato", "quail egg" };

        // drink
        public static int drink_totalAmount = 0;

        public static List<int> drink_itemQuantity = new List<int>();
        public static List<int> drink_itemInStock = new List<int>();
        public static List<int> drink_itemPrice = new List<int>() { 10, 15, 15, 15, 15, 10 };
        public static List<string> drink_items = new List<string>() { "Water bottle", "Coca-cola", "Sprite", "Melon Milk", "Sunkist", "Iced Tea" };

        static void Main(string[] args)
        {
            RunMain();
        }
        // Main
        static void RunMain()
        {
            Console.Clear();
            MenuTopBar();
            Console.WriteLine("Welcome to the DotNet-MaLa Menu CLI!");
            Console.WriteLine("Choose an option:");

            menu_totalAmount = 0;
            drink_totalAmount = 0;
            menu_spicyLevel = 0;
            menu_option = 0;
            menu_itemInStock = new List<int>() { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 };
            drink_itemInStock = new List<int>() { 9, 9, 9, 9, 9, 9 };
            menu_itemQuantity = new List<int>(new int[10]);
            drink_itemQuantity = new List<int>(new int[6]);

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
            int seletedOption = option;
            switch (seletedOption)
            {
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
            Console.WriteLine(@"     
##   ##    ##     ####       ##     
 ## ##      ##     ##         ##    
# ### #   ## ##    ##       ## ##   
## # ##   ##  ##   ##       ##  ##  
##   ##   ## ###   ##       ## ###  
##   ##   ##  ##   ##  ##   ##  ##  
##   ##  ###  ##  ### ###  ###  ##  
 
        ");
            Console.WriteLine("\n\t\t.NetMaLa Menu CLI!\n");
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
            menu_option = menuoption; ;
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
            const int singleMenuPrice = 99;
            menu_totalAmount = singleMenuPrice;
            Console.WriteLine("Single set has been added to your cart.");
            Console.WriteLine("Total amount : {0} Baht", singleMenuPrice);
            DispleyDryOrSoupTable();
        }

        // couple
        static void CoupleMenuTable()
        {
            MenuTopBar();
            const int coupleMenuPrice = 150;
            menu_totalAmount = coupleMenuPrice;

            Console.WriteLine("Couple set has been added to your cart.");
            Console.WriteLine("Total amount : {0} Baht", coupleMenuPrice);
            DispleyDryOrSoupTable();

        }

        // custom
        static void DisplayCustomMenuTable()
        {
            //
            Console.Clear();
            MenuTopBar();
            DisplayCustomMenuOptions();
        }

        // custom menu opetion
        static void DisplayCustomMenuOptions()
        {
            //


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
                for (int i = 0; i < menu_items.Count(); i++)
                {
                    Console.WriteLine($"\n\t{(menuoption == i + 1 ? color + "[]" : "  ")}{(menu_items[i])}\u001b[0m" +
                        $"\t\t   {(menu_itemQuantity[i])}" + $"\t\t    {menu_itemInStock[i]}" + $"\t\t    {menu_itemPrice[i]}");
                }
                Console.WriteLine("\n\tTotal amount: " + menu_totalAmount);
                Readkey = Console.ReadKey(true);
                switch (Readkey.Key)
                {
                    case ConsoleKey.DownArrow:
                        menuoption = (menuoption == menu_items.Count() ? 1 : menuoption + 1);
                        break;
                    case ConsoleKey.UpArrow:
                        menuoption = (menuoption == 1 ? menu_items.Count() : menuoption - 1);
                        break;
                    case ConsoleKey.RightArrow:
                        if (menu_itemInStock[menuoption - 1] > 0)
                        {
                            menu_itemQuantity[menuoption - 1] += 1;
                            menu_itemInStock[menuoption - 1] -= 1;
                            menu_totalAmount += menu_itemPrice[menuoption - 1];
                            ClearLine();
                        };
                        break;
                    case ConsoleKey.LeftArrow:
                        if (menu_itemQuantity[menuoption - 1] > 0)
                        {
                            menu_itemQuantity[menuoption - 1] -= 1;
                            menu_itemInStock[menuoption - 1] += 1;
                            menu_totalAmount -= menu_itemPrice[menuoption - 1];
                            ClearLine();
                        }
                        break;
                    case ConsoleKey.Enter:
                        isSelected = true;
                        DispleyDryOrSoupTable();
                        break;
                }

            }
            Console.WriteLine(menu_totalAmount);
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
            Console.Clear();
            MenuTopBar();
            Console.WriteLine("\tSelect your spicy level");
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
                        menu_spicyLevel = option;
                        DisplayDrinkTable();
                        break;
                }

            }
        }

        // dry or soup
        static void DispleyDryOrSoupTable()
        {
            Console.Clear();
            MenuTopBar();
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
                        DisplaySpicyLevelTable();
                        break;
                }

            }
        }
        // drink
        static void DisplayDrinkTable()
        {
            Console.Clear();
            MenuTopBar();

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
                for (int i = 0; i < drink_items.Count(); i++)
                {
                    Console.WriteLine($"\n\t{(menuoption == i + 1 ? color + "[]" : "  ")}{(drink_items[i])}\u001b[0m" +
                        $"\t\t   {(drink_itemQuantity[i])}" + $"\t\t    {drink_itemInStock[i]}" + $"\t\t    {drink_itemPrice[i]}");
                }
                Console.WriteLine("\n\tTotal amount: " + drink_totalAmount);
                Readkey = Console.ReadKey(true);
                switch (Readkey.Key)
                {
                    case ConsoleKey.DownArrow:
                        menuoption = (menuoption == drink_items.Count() ? 1 : menuoption + 1);
                        break;
                    case ConsoleKey.UpArrow:
                        menuoption = (menuoption == 1 ? drink_items.Count() : menuoption - 1);
                        break;
                    case ConsoleKey.RightArrow:
                        if (drink_itemInStock[menuoption - 1] > 0)
                        {
                            drink_itemQuantity[menuoption - 1] += 1;
                            drink_itemInStock[menuoption - 1] -= 1;
                            drink_totalAmount += drink_itemPrice[menuoption - 1];
                            ClearLine();
                        };
                        break;
                    case ConsoleKey.LeftArrow:
                        if (drink_itemQuantity[menuoption - 1] > 0)
                        {
                            drink_itemQuantity[menuoption - 1] -= 1;
                            drink_itemInStock[menuoption - 1] += 1;
                            drink_totalAmount -= drink_itemPrice[menuoption - 1];
                            ClearLine();
                        }
                        break;
                    case ConsoleKey.Enter:
                        isSelected = true;

                        break;
                }
            }
            Console.WriteLine(drink_totalAmount);
            DisplayCard_Edit_Details();

        }

        // card ( edit & details )
        static void DisplayCard_Edit_Details()
        {
            Console.Clear();
            MenuTopBar();
            Console.WriteLine("\tPlease Check Before Order");

            var table = new ConsoleTable("Items", "Quantity", "Price");
            if (menu_option == 3)
            {
                table.AddRow("CUSTOM SET",
                                   "",
                                    "");
                for (int i = 0; i < menu_items.Count; i++)
                {
                    if (menu_itemQuantity[i] != 0)
                    {
                        // Set red color for menu items
                        table.AddRow(menu_items[i],
                 menu_itemQuantity[i],
                 menu_itemPrice[i]);
                    }
                }
            }else{
                table.AddRow("MALA",
                                    "",
                                     menu_totalAmount);
            }


            // table.AddRow("DRINK",
            //                         "",
            //                          "");

            for (int i = 0; i < drink_items.Count; i++)
            {
                if (drink_itemQuantity[i] != 0)
                {
                    // Set blue color for drink items
                    table.AddRow(drink_items[i],
                                     drink_itemQuantity[i],
                                     drink_itemPrice[i]);
                }
            }
            table.AddRow("",
                                    "",
                                     "");

            // table.AddRow("Spicy",
            //                         "",
            //                          "");

            int total = drink_totalAmount + menu_totalAmount;
            // Console.WriteLine("\n\tTotal amount: " + total);
            table.AddRow("",
                                   "Total",
                                    total);
            table.Write();

            string menuOptionText;
            string colorCode = "";

            switch (menu_option)
            {
                case 1:
                    menuOptionText = "Single Menu";
                    colorCode = "\x1b[33m"; // Yellow color
                    break;
                case 2:
                    menuOptionText = "Couple Menu";
                    colorCode = "\x1b[35m"; // Purple color
                    break;
                case 3:
                    menuOptionText = "Custom Menu";
                    colorCode = "\x1b[36m"; // Cyan color
                    break;
                default:
                    menuOptionText = "----";
                    break;
            }

            Console.WriteLine($"\n\tMenu Option: {colorCode}{menuOptionText}\x1b[0m"); string spicyLevelText;
            string colorCode12 = "";

            switch (menu_spicyLevel)
            {
                case 1:
                    spicyLevelText = "Mild";
                    colorCode12 = "\x1b[33m"; // Yellow color
                    break;
                case 2:
                    spicyLevelText = "Medium";
                    colorCode12 = "\x1b[31m"; // Red color
                    break;
                case 3:
                    spicyLevelText = "Hot";
                    colorCode12 = "\x1b[91m"; // Light Red color
                    break;
                case 4:
                    spicyLevelText = "Extra Hot";
                    colorCode12 = "\x1b[35m"; // Purple color
                    break;
                default:
                    spicyLevelText = "----";
                    break;
            }
            Console.WriteLine($"\n\tSpicy Level: {colorCode12}{spicyLevelText}\x1b[0m");

            if (menu_option == 3)
            {

                ConsoleKeyInfo Readkey;
                int option = 1;
                bool isSelected = false;
                (int left, int top) = Console.GetCursorPosition();
                Console.CursorVisible = false;
                string color = "\u001b[33;1m";
                while (!isSelected)
                {
                    Console.SetCursorPosition(left, top);
                    Console.WriteLine($"\n\t{(option == 1 ? color + "[]" : "  ")}Edit\u001b[0m");
                    Console.WriteLine($"\t{(option == 2 ? color + "[]" : "  ")}Continue\u001b[0m");



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
                            if (option == 1)
                            {
                                DisplayCustomMenuTable();
                                break;
                            }
                            else
                            {
                                // DisplayCouponTable();
                                DisplayInvoice();
                                break;
                            }

                    }

                }
            }else{

                ConsoleKeyInfo Readkey;
                int option = 1;
                bool isSelected = false;
                (int left, int top) = Console.GetCursorPosition();
                Console.CursorVisible = false;
                string color = "\u001b[33;1m";
                while (!isSelected)
                {
                    Console.SetCursorPosition(left, top);
                    // Console.WriteLine($"\n\t{(option == 1 ? color + "[]" : "  ")}Edit\u001b[0m");
                    Console.WriteLine($"\t{(option == 2 ? color + "[]" : "  ")}Continue\u001b[0m");



                    Readkey = Console.ReadKey(true);

                    switch (Readkey.Key)
                    {
                        // case ConsoleKey.DownArrow:
                        //     option = (option == 2 ? 1 : 2);
                        //     break;
                        // case ConsoleKey.UpArrow:
                        //     option = (option == 1 ? 2 : 1);
                        //     break;
                        case ConsoleKey.Enter:
                            isSelected = true;
                            DisplayInvoice();
                            break;

                    }

                }

            }
        }

        // coupon
        static void DisplayCouponTable()
        {

            Console.Clear();
            MenuTopBar();
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
                        discount = menu_totalAmount * 0.05;
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
            Console.Clear();
            MenuTopBar();
            var table = new ConsoleTable("Item", "Price");
            if (menu_option == 3) table.AddRow("Mala", menu_totalAmount);
            if (menu_option == 3) table.AddRow("Drink", drink_totalAmount);
           
            string menuType = "";

            switch (menu_option)
            {
                case 1:
                    menuType = "\x1b[31mSingle Menu\x1b[0m"; // Red color for Single Menu
                    break;
                case 2:
                    menuType = "\x1b[34mCouple Menu\x1b[0m"; // Blue color for Couple Menu
                    break;
                case 3:
                    menuType = "\x1b[33mCustom Menu\x1b[0m"; // Yellow color for Custom Menu
                    break;
                default:
                    menuType = "\x1b[35mUnknown\x1b[0m"; // Magenta color for Unknown
                    break;
            }
            table.AddRow("Type", menuType);
            int total = menu_totalAmount+ drink_totalAmount;
            table.AddRow("Total Price", total);

            table.Write();


            Console.WriteLine("Re new your order");

            ConsoleKeyInfo Readkey;
            int option = 1;
            bool isSelected = false;
            (int left, int top) = Console.GetCursorPosition();
            Console.CursorVisible = false;
            string color = "\u001b[33;1m";
            while (!isSelected)
            {
                Console.SetCursorPosition(left, top);
                Console.WriteLine($"\n\t{(option == 1 ? color + "[]" : "  ")}Yes\u001b[0m");
                Console.WriteLine($"\t{(option == 2 ? color + "[]" : "  ")}No\u001b[0m");



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
                        if (option == 1)
                        {
                            RunMain();
                            break;
                        }
                        else
                        {

                            break;
                        }

                }

            }
        }

    }
}
