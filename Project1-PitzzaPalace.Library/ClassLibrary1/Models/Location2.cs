using System;
using System.Collections.Generic;


namespace ClassLibrary1.Models
{
    public class Location2
    {
        ////////////////////////// Objects /////////////////////////////
        Pizza2 theone = new Pizza2();

        //////////////////// Pizza/Size variable ///////////////////////
        string PizzaSelected, SizeOfPizza, sel;

        ///////////////////////////////////////////////////////////////

        public void PizzaPalace()
        {
            Console.Clear();
            Console.WriteLine("========== Welcome to Pizza Palace! ==========");
            Console.WriteLine("");
            Console.WriteLine("==============Select your pizza!!=============");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("1) Cheese Pizza");
            Console.WriteLine("");
            Console.WriteLine("2) Pepperoni Pizza");
            Console.WriteLine("");
            Console.WriteLine("3) All Meat Pizza");
            Console.WriteLine("");
            Console.WriteLine("4) Chorizo Pizza");
            Console.WriteLine("");
            Console.WriteLine("5) Bacon Pizza");
            Console.WriteLine("");
            Console.WriteLine("6) Make your own!");
            Console.WriteLine("");
            Console.WriteLine("7) Change Location");                               //////// Call function if selected 6////////
            PizzaSelected = Console.ReadLine(); // Stored pizza

            switch (PizzaSelected)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                    PizzaSize();
                    break;
                case "7":
                    ChangeLocation();
                    break;
                default:
                    Console.WriteLine("");
                    Console.WriteLine("Choose size from 1 to 7!");
                    Console.WriteLine("");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    PizzaPalace();
                    break;
            }
        }

        public void Belitopizza()
        {
            Console.Clear();
            Console.WriteLine("====*===== Welcome to Belito's Pizza! ====*=====");
            Console.WriteLine("");
            Console.WriteLine("==============Select your pizza!!=============");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("1) Cheese Pizza");
            Console.WriteLine("");
            Console.WriteLine("2) Pepperoni Pizza");
            Console.WriteLine("");
            Console.WriteLine("3) All Meat Pizza");
            Console.WriteLine("");
            Console.WriteLine("4) Chorizo Pizza");
            Console.WriteLine("");
            Console.WriteLine("5) Make your own!");
            Console.WriteLine("");
            Console.WriteLine("6) Change Location");                               //////// Call function if selected 6////////
            PizzaSelected = Console.ReadLine(); // Stored pizza

            switch (PizzaSelected)
            {
                case "1":
                case "2":
                case "3":
                    PizzaSize();
                    break;
                default:
                    Console.WriteLine("");
                    Console.WriteLine("Choose size from 1 to 3!");
                    Console.WriteLine("");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    Belitopizza();
                    break;
            }
        }

        public void Angelitospizza()
        {
            Console.Clear();
            Console.WriteLine("=====#==== Welcome to Angelitos Pizza! =====#====");
            Console.WriteLine("");
            Console.WriteLine("==============Select your pizza!!=============");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("1) Cheese Pizza");
            Console.WriteLine("");
            Console.WriteLine("2) Pepperoni Pizza");
            Console.WriteLine("");
            Console.WriteLine("3) All Meat Pizza");
            Console.WriteLine("");
            Console.WriteLine("4) Chorizo Pizza");
            Console.WriteLine("");
            Console.WriteLine("5) Make your own!");
            Console.WriteLine("");
            Console.WriteLine("6) Change Location");                               //////// Call function if selected 6////////
            PizzaSelected = Console.ReadLine(); // Stored pizza

            switch (PizzaSelected)
            {
                case "1":
                case "2":
                case "3":
                    PizzaSize();
                    break;
                default:
                    Console.WriteLine("");
                    Console.WriteLine("Choose size from 1 to 3!");
                    Console.WriteLine("");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    Angelitospizza();
                    break;
            }

        }

        public void PizzaSize()
        {
            Console.Clear();
            Console.WriteLine("=========== Choose the size of the pizza ===========");
            Console.WriteLine("");
            Console.WriteLine("____________________________________________________");
            Console.WriteLine("|       1       |         2       |        3       |");
            Console.WriteLine("| Small: $ 6.00 | Medium: $ 12.00 | Large: $ 17.00 |");
            Console.WriteLine("| 4 Pizza slice |  8 Pizza slice  | 12 Pizza Slice |");
            Console.WriteLine("");
            SizeOfPizza = Console.ReadLine();

            /////////////// VALIDATION OF SELECTION ///////////////////
            
            switch (SizeOfPizza)
            {
                case "1":
                    Selection(PizzaSelected, SizeOfPizza);
                    break;
                case "2":
                    Selection(PizzaSelected, SizeOfPizza);
                    break;
                case "3":
                    Selection(PizzaSelected, SizeOfPizza);
                    break;
                default:
                    Console.WriteLine("");
                    Console.WriteLine("Choose size from 1 to 3!");
                    Console.WriteLine("");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    PizzaSize();
                    break;
            }
        }

        public void Selection(string p, string s)
        {
            switch (p)
            {
                case "1":
                    theone.Cheesepizza(s);
                    break;
                case "2":
                    theone.Pepperoni(s);
                    break;
                case "3":
                    theone.AllMeat(s);
                    break;
                case "4":
                    theone.Chorizo(s);
                    break;
                case "5":
                    theone.Bacon(s);
                    break;
                case "6":
                    theone.CustomMenu(s);
                    break;
                case "7":
                    ChangeLocation();
                    break;
                default:
                    Console.WriteLine("Default case of Selection");
                    break;
            }
        }

        public void ChangeLocation()
        {
            Console.Clear();
            Console.WriteLine("======== Choose location ========");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("1) for Pizza Palace.");
            Console.WriteLine("");
            Console.WriteLine("2) for Angelitos Pizzeria.");
            Console.WriteLine("");
            Console.WriteLine("3) for Belito's Pizza.");
            sel = Console.ReadLine();
            /////////////// VALIDATION OF SELECTION ///////////////////
                switch (sel)
                {
                    case "1":
                        PizzaPalace();
                        break;
                    case "2":
                        Angelitospizza();
                        break;
                    case "3":
                        Belitopizza();
                        break;
                    default:
                        Console.WriteLine("");
                        Console.WriteLine("Choose from 1 to 3!");
                        Console.WriteLine("");
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                        ChangeLocation();
                        break;
                }
            
        }
    }
}
