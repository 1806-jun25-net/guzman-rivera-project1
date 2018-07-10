using System;
using System.Collections.Generic;


namespace ClassLibrary1.Models
{
    class Pizza2
    {
        Order2 NewOrder = new Order2();
        string pizza;
        int price;
        string size, select;

        List<int> toppins = new List<int>();
        

        public void Cheesepizza(string S)
        {
            pizza = "Cheese";
            toppins.Add(1);
            toppins.Add(1);
            toppins.Add(0);
            toppins.Add(0);
            toppins.Add(0);
            toppins.Add(0);
            toppins.Add(0);
            toppins.Add(1);
            toppins.Add(0);
            Price(S);

        }

        public void Pepperoni(string S)
        {
            pizza = "Pepperoni";
            toppins.Add(1);
            toppins.Add(1);
            toppins.Add(1);
            toppins.Add(0);
            toppins.Add(0);
            toppins.Add(0);
            toppins.Add(0);
            toppins.Add(1);
            toppins.Add(0);
            Price(S);

        }

        public void AllMeat(string S)
        {
            pizza = "AllMeat";
            toppins.Add(1);
            toppins.Add(1);
            toppins.Add(0);
            toppins.Add(1);
            toppins.Add(1);
            toppins.Add(0);
            toppins.Add(1);
            toppins.Add(1);
            toppins.Add(1);
            Price(S);

        }

        public void Chorizo(string S)
        {
            pizza = "Chorizo";
            toppins.Add(1);
            toppins.Add(1);
            toppins.Add(0);
            toppins.Add(0);
            toppins.Add(0);
            toppins.Add(0);
            toppins.Add(0);
            toppins.Add(1);
            toppins.Add(1);
            Price(S);
        }

        public void Bacon(string S)
        {
            pizza = "Bacon";
            toppins.Add(1);
            toppins.Add(1);
            toppins.Add(0);
            toppins.Add(0);
            toppins.Add(1);
            toppins.Add(0);
            toppins.Add(0);
            toppins.Add(1);
            toppins.Add(0);
            Price(S);
        }

        public void Price(string S)
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
            Submit();
        }

        public void Submit()
        {
            NewOrder.SubmitOrder(size + " " + pizza + " Pizza", price,toppins);
        }

        public void CustomMenu(string s)
        {
            string Sause = ("");
            string pepone = ("");
            string bacon = ("");
            string onion = ("");
            string chiken = ("");
            string chorixo = ("");

            toppins.Add(1); // doug
            toppins.Add(1); // cheese
            toppins.Add(0); // peppe
            toppins.Add(0); // Sas
            toppins.Add(0); // Bac
            toppins.Add(0); //onio 6
            toppins.Add(0); // chi
            toppins.Add(1); // sauce 8
            toppins.Add(0); // chori

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
                        toppins[3] = 1; // peperoni
                        pepone = ("✓");
                        break;
                    case "2":
                        toppins[4] = 1; // Sausage
                        Sause = ("✓");
                        break;
                    case "3":
                        toppins[5] = 1; // Baacon
                        bacon = ("✓");
                        break;
                    case "4":
                        toppins[6] = 1; // onion
                        onion = ("✓");
                        break;
                    case "5":
                        toppins[7] = 1; // chicken
                        chiken = ("✓");
                        break;
                    case "6":
                        toppins[9] = 1; // chorizo
                        chorixo = ("✓");
                        break;
                    case "7": // finish
                        pizza = "Custom";
                        Price(s);
                        break;
                    default:
                        Console.WriteLine("Choose toppings from 1 to 6!");
                        break;
                }
            }
        }

    }

}

