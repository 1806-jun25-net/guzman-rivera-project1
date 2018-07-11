using System;
using System.Collections.Generic;


namespace ClassLibrary1.Models
{
    public class Pizza2
    {
        //

        string pizza;
        int price;
        string size, select;
        public int PizzaId { get; set; }
        public string Pizza1 { get; set; }
        public string Size { get; set; }
        public int? Doug { get; set; }
        public int? Cheese { get; set; }
        public int? pepperoni { get; set; }
        public int? Sausage { get; set; }
        public int? bacon { get; set; }
        public int? Onion { get; set; }
        public int? Chiken { get; set; }
        public int? Sauce { get; set; }
        public int? chorizo { get; set; }
        public int? PizzaPrice { get; set; }

        List<int> toppins = new List<int>(); /////////////////////////////////////////////////// areglar
  

        public void Cheesepizza(string S, List<User2> user3, int thelocation)
        {
            pizza = "Cheese";
            toppins.Clear();
            toppins.Add(1);
            toppins.Add(1);
            toppins.Add(0);
            toppins.Add(0);
            toppins.Add(0);
            toppins.Add(0);
            toppins.Add(0);
            toppins.Add(1);
            toppins.Add(0);
            Price(S, user3, thelocation);

        }

        public void Pepperoni(string S, List<User2> user3 , int thelocation)
        {
            pizza = "Pepperoni";
            toppins.Clear();
            toppins.Add(1);
            toppins.Add(1);
            toppins.Add(1);
            toppins.Add(0);
            toppins.Add(0);
            toppins.Add(0);
            toppins.Add(0);
            toppins.Add(1);
            toppins.Add(0);
            Price(S, user3, thelocation);

        }

        public void AllMeat(string S, List<User2> user3, int thelocation)
        {
            pizza = "AllMeat";
            toppins.Clear();
            toppins.Add(1);
            toppins.Add(1);
            toppins.Add(0);
            toppins.Add(1);
            toppins.Add(1);
            toppins.Add(0);
            toppins.Add(1);
            toppins.Add(1);
            toppins.Add(1);
            Price(S, user3, thelocation);

        }

        public void Chorizo(string S, List<User2> user3, int thelocation)
        {
            pizza = "Chorizo";
            toppins.Clear();
            toppins.Add(1);
            toppins.Add(1);
            toppins.Add(0);
            toppins.Add(0);
            toppins.Add(0);
            toppins.Add(0);
            toppins.Add(0);
            toppins.Add(1);
            toppins.Add(1);
            Price(S, user3, thelocation);
        }

        public void Bacon(string S, List<User2> user3, int thelocation)
        {
            pizza = "Bacon";
            toppins.Clear();
            toppins.Add(1);
            toppins.Add(1);
            toppins.Add(0);
            toppins.Add(0);
            toppins.Add(1);
            toppins.Add(0);
            toppins.Add(0);
            toppins.Add(1);
            toppins.Add(0);
            Price(S, user3, thelocation);
        }

        public void Price(string S, List<User2> user3, int thelocation)
        {
            if (S == "1")
            {
                size = "Small";
                price = 6;
            }
            else if (S == "2")
            {
                size = "Medium";
                price = 12;
            }
            else if (S == "3")
            {
                size = "Large";
                price = 17;
            }
            Submit(user3, thelocation, size);
        }

        public void Submit(List<User2> user3, int thelocation,  string size)
        {
            Order2 NewOrder = new Order2();
            NewOrder.SubmitOrder(pizza + " Pizza", price,toppins, user3, thelocation, size);
        }

        public void CustomMenu(string s, List<User2> user3, int thelocation)
        {
            string Sause = ("");
            string pepone = ("");
            string bacon = ("");
            string onion = ("");
            string chiken = ("");
            string chorixo = ("");

            toppins.Clear();
            toppins.Add(1); // doug = 0
            toppins.Add(1); // cheese
            toppins.Add(0); // peppe
            toppins.Add(0); // Sas = 3
            toppins.Add(0); // Bac
            toppins.Add(0); //onio = 6
            toppins.Add(0); // chi
            toppins.Add(1); // sauce 
            toppins.Add(0); // chori = 8

        bool des = true;

            while (des)
            {

                Console.Clear();
                Console.WriteLine("========== Custom Pizza Menu ===============");
                Console.WriteLine("");
                Console.WriteLine("========= Select your toppins! =============");
                Console.WriteLine("============= one by one ===================");
                Console.WriteLine("");
                Console.WriteLine("1) " + pepone + " Pepperoni");
                Console.WriteLine("");
                Console.WriteLine("2) " + Sause + " Sausage");
                Console.WriteLine("");
                Console.WriteLine("3) " + bacon + " Bacon");
                Console.WriteLine("");
                Console.WriteLine("4) " + onion + " Onion");
                Console.WriteLine("");
                Console.WriteLine("5) " + chiken + " Chicken");
                Console.WriteLine("");
                Console.WriteLine("6) " + chorixo + " Chorizo");
                Console.WriteLine("");
                Console.WriteLine("7) Finish");
                select = Console.ReadLine();
                string size = s;

                switch (select)
                {
                    case "1":
                        toppins[2] = 1; // peperoni
                        pepone = ("✓");
                        break;
                    case "2":
                        toppins[3] = 1; // Sausage
                        Sause = ("✓");
                        break;
                    case "3":
                        toppins[4] = 1; // Baacon
                        bacon = ("✓");
                        break;
                    case "4":
                        toppins[5] = 1; // onion
                        onion = ("✓");
                        break;
                    case "5":
                        toppins[6] = 1; // chicken
                        chiken = ("✓");
                        break;
                    case "6":
                        toppins[8] = 1; // chorizo
                        chorixo = ("✓");
                        break;
                    case "7": // finish
                        pizza = "Custom";
                        Price(s, user3, thelocation);
                        break;
                    default:
                        Console.WriteLine("Choose toppings from 1 to 6!");
                        break;
                }
            }
        }

    }

}

