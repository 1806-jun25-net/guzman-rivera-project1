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
        int TheLocation;

        ///////////////////////////////////////////////////////////////

        public void PizzaPalace(List<User2> user3, int? thelocation)
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
            Console.WriteLine("7) Change Location");
            Console.WriteLine("");
            Console.WriteLine("8) Close aplication");  //////// Call function if selected 6////////
            PizzaSelected = Console.ReadLine(); // Stored pizza

            switch (PizzaSelected)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                    PizzaSize(user3, 1);
                    break;
                case "7":
                    ChangeLocation(user3, 1);
                    break;
                case "8":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("");
                    Console.WriteLine("Choose size from 1 to 7!");
                    Console.WriteLine("");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    PizzaPalace(user3, 1);
                    break;
            }
        }

        public void Belitopizza(List<User2> user3, int? thelocation)
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
            Console.WriteLine("6) Change Location");
            Console.WriteLine("");
            Console.WriteLine("7) Close aplication"); //////// Call function if selected 6////////
            PizzaSelected = Console.ReadLine(); // Stored pizza

            switch (PizzaSelected)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                    PizzaSize(user3, 3);
                    break;
                case "6":
                    ChangeLocation(user3, 1);
                    break;
                case "7":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("");
                    Console.WriteLine("Choose size from 1 to 3!");
                    Console.WriteLine("");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    Belitopizza(user3, 3);
                    break;
            }
        }

        public void Angelitospizza(List<User2> user3, int thelocation)
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
            Console.WriteLine("6) Change Location");
            Console.WriteLine("");
            Console.WriteLine("7) Close aplication");//////// Call function if selected 6////////
            PizzaSelected = Console.ReadLine(); // Stored pizza

            switch (PizzaSelected)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                    PizzaSize(user3, 2);
                    break;
                case "6":
                    ChangeLocation(user3, 1);
                    break;
                case "7":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("");
                    Console.WriteLine("Choose size from 1 to 3!");
                    Console.WriteLine("");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    Angelitospizza(user3, 2);
                    break;
            }

        }

        public void PizzaSize(List<User2> user3, int thelocation)
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
                    Selection(PizzaSelected, SizeOfPizza, user3, thelocation);
                    break;
                case "2":
                    Selection(PizzaSelected, SizeOfPizza, user3, thelocation);
                    break;
                case "3":
                    Selection(PizzaSelected, SizeOfPizza, user3, thelocation);
                    break;
                default:
                    Console.WriteLine("");
                    Console.WriteLine("Choose size from 1 to 3!");
                    Console.WriteLine("");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    PizzaSize(user3, thelocation);
                    break;
            }
        }

        public void Selection(string p, string s, List<User2> user3, int thelocation)
        {
            switch (p)
            {
                case "1":
                    theone.Cheesepizza(s, user3, thelocation);
                    break;
                case "2":
                    theone.Pepperoni(s, user3, thelocation);
                    break;
                case "3":
                    theone.AllMeat(s, user3, thelocation);
                    break;
                case "4":
                    theone.Chorizo(s, user3, thelocation);
                    break;
                case "5":
                    theone.Bacon(s, user3, thelocation);
                    break;
                case "6":
                    theone.CustomMenu(s, user3, thelocation);
                    break;
                case "7":
                    ChangeLocation(user3, thelocation);
                    break;
                default:
                    Console.WriteLine("Default case of Selection");
                    break;
            }
        }

        public void ChangeLocation(List<User2> user3, int thelocation)
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
                    TheLocation = Int32.Parse(sel);
                    PizzaPalace(user3, TheLocation);
                    break;
                case "2":
                    TheLocation = Int32.Parse(sel);
                    Angelitospizza(user3, TheLocation);
                    break;
                case "3":
                    TheLocation = Int32.Parse(sel);
                    Belitopizza(user3, TheLocation);
                    break;
                default:
                    Console.WriteLine("");
                    Console.WriteLine("Choose from 1 to 3!");
                    Console.WriteLine("");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    ChangeLocation(user3, thelocation);
                    break;
            }

        }
    }
}
