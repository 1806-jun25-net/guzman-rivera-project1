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


        public void Submit(List<User2> user3, int thelocation, string size)
        {
            Order2 NewOrder = new Order2();
            NewOrder.SubmitOrder(pizza + " Pizza", price, toppins, user3, thelocation, size);
        }


        public void Cheesepizza(string S, List<User2> user3, int thelocation)
        {
            if (S == "Small")
            {
                toppins.Clear();
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
            else if (S == "Medium")
            {
                toppins.Clear();
                pizza = "Cheese";
                toppins.Clear();
                toppins.Add(2);
                toppins.Add(2);
                toppins.Add(0);
                toppins.Add(0);
                toppins.Add(0);
                toppins.Add(0);
                toppins.Add(0);
                toppins.Add(2);
                toppins.Add(0);
                Price(S, user3, thelocation);
            }
            else if (S == "Large")
            {
                toppins.Clear();
                pizza = "Cheese";
                toppins.Clear();
                toppins.Add(3);
                toppins.Add(3);
                toppins.Add(0);
                toppins.Add(0);
                toppins.Add(0);
                toppins.Add(0);
                toppins.Add(0);
                toppins.Add(3);
                toppins.Add(0);
                Price(S, user3, thelocation);
            }


        }

        public void Pepperoni(string S, List<User2> user3, int thelocation)
        {
            if (S == "Small")
            {
                toppins.Clear();
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
            else if (S == "Medium")
            {
                toppins.Clear();
                pizza = "Pepperoni";
                toppins.Clear();
                toppins.Add(2);
                toppins.Add(2);
                toppins.Add(2);
                toppins.Add(0);
                toppins.Add(0);
                toppins.Add(0);
                toppins.Add(0);
                toppins.Add(2);
                toppins.Add(0);
                Price(S, user3, thelocation);
            }
            else if (S == "Large")
            {
                toppins.Clear();
                pizza = "Pepperoni";
                toppins.Clear();
                toppins.Add(3);
                toppins.Add(3);
                toppins.Add(3);
                toppins.Add(0);
                toppins.Add(0);
                toppins.Add(0);
                toppins.Add(0);
                toppins.Add(3);
                toppins.Add(0);
                Price(S, user3, thelocation);
            }


        }

        public void AllMeat(string S, List<User2> user3, int thelocation)
        {
            if (S == "Small")
            {
                toppins.Clear();
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
            else if (S == "Medium")
            {
                toppins.Clear();
                pizza = "AllMeat";
                toppins.Clear();
                toppins.Add(2);
                toppins.Add(2);
                toppins.Add(0);
                toppins.Add(2);
                toppins.Add(2);
                toppins.Add(0);
                toppins.Add(2);
                toppins.Add(2);
                toppins.Add(2);
                Price(S, user3, thelocation);

            }
            else if (S == "Large")
            {
                toppins.Clear();
                pizza = "AllMeat";
                toppins.Clear();
                toppins.Add(2);
                toppins.Add(2);
                toppins.Add(0);
                toppins.Add(2);
                toppins.Add(2);
                toppins.Add(0);
                toppins.Add(2);
                toppins.Add(2);
                toppins.Add(2);
                Price(S, user3, thelocation);

            }
        }

        public void Chorizo(string S, List<User2> user3, int thelocation)
        {
            if (S == "Small")
            {
                toppins.Clear();
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
            else if (S == "Medium")
            {
                toppins.Clear();
                pizza = "Chorizo";
                toppins.Clear();
                toppins.Add(2);
                toppins.Add(2);
                toppins.Add(0);
                toppins.Add(0);
                toppins.Add(0);
                toppins.Add(0);
                toppins.Add(0);
                toppins.Add(2);
                toppins.Add(2);
                Price(S, user3, thelocation);

            }
            else if (S == "Large")
            {
                toppins.Clear();
                pizza = "Chorizo";
                toppins.Clear();
                toppins.Add(3);
                toppins.Add(3);
                toppins.Add(0);
                toppins.Add(0);
                toppins.Add(0);
                toppins.Add(0);
                toppins.Add(0);
                toppins.Add(3);
                toppins.Add(3);
                Price(S, user3, thelocation);

            }
        }

        public void Bacon(string S, List<User2> user3, int thelocation)
        {
            if (S == "Small")
            {
                toppins.Clear();
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
            else if (S == "Medium")
            {
                toppins.Clear();
                pizza = "Bacon";
                toppins.Clear();
                toppins.Add(2);
                toppins.Add(2);
                toppins.Add(0);
                toppins.Add(0);
                toppins.Add(2);
                toppins.Add(0);
                toppins.Add(0);
                toppins.Add(2);
                toppins.Add(0);
                Price(S, user3, thelocation);

            }
            else if (S == "Large")
            {
                toppins.Clear();
                pizza = "Bacon";
                toppins.Clear();
                toppins.Add(3);
                toppins.Add(3);
                toppins.Add(0);
                toppins.Add(0);
                toppins.Add(3);
                toppins.Add(0);
                toppins.Add(0);
                toppins.Add(3);
                toppins.Add(0);
                Price(S, user3, thelocation);

            }

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


        public void CustomMenu(string s, List<User2> user3, int thelocation)
        {
            string Sause = ("");
            string pepone = ("");
            string bacon = ("");
            string onion = ("");
            string chiken = ("");
            string chorixo = ("");

            if (s == "Small")
            {

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

            }
            else if (s == "Medium")
            {

                toppins.Clear();
                toppins.Add(2); // doug = 0
                toppins.Add(2); // cheese
                toppins.Add(0); // peppe
                toppins.Add(0); // Sas = 3
                toppins.Add(0); // Bac
                toppins.Add(0); //onio = 6
                toppins.Add(0); // chi
                toppins.Add(2); // sauce 
                toppins.Add(0); // chori = 8

            }
            else if (s == "Large")
            {

                toppins.Clear();
                toppins.Add(3); // doug = 0
                toppins.Add(3); // cheese
                toppins.Add(0); // peppe
                toppins.Add(0); // Sas = 3
                toppins.Add(0); // Bac
                toppins.Add(0); //onio = 6
                toppins.Add(0); // chi
                toppins.Add(3); // sauce 
                toppins.Add(0); // chori = 8

            }

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
                        if (s == "Small")
                        {
                            toppins[2] = 1; // peperoni
                            pepone = ("✓");
                        }
                        else if (s == "Medium")
                        {
                            toppins[2] = 2; // peperoni
                            pepone = ("✓");
                        }
                        else if (s == "Large")
                        {
                            toppins[2] = 3; // peperoni
                            pepone = ("✓");
                        }
                        break;
                    case "2":
                        if (s == "Small")
                        {
                            toppins[3] = 1; // peperoni
                            Sause = ("✓");
                        }
                        else if (s == "Medium")
                        {
                            toppins[3] = 2; // peperoni
                            Sause = ("✓");
                        }
                        else if (s == "Large")
                        {
                            toppins[3] = 3; // peperoni
                            Sause = ("✓");
                        }

                        break;
                    case "3":
                        if (s == "Small")
                        {
                            toppins[4] = 1; // peperoni
                            bacon = ("✓");
                        }
                        else if (s == "Medium")
                        {
                            toppins[4] = 2; // peperoni
                            bacon = ("✓");
                        }
                        else if (s == "Large")
                        {
                            toppins[4] = 3; // peperoni
                            bacon = ("✓");
                        }

                        break;
                    case "4":
                        if (s == "Small")
                        {
                            toppins[5] = 1; // peperoni
                            onion = ("✓");
                        }
                        else if (s == "Medium")
                        {
                            toppins[5] = 2; // peperoni
                            onion = ("✓");
                        }
                        else if (s == "Large")
                        {
                            toppins[5] = 3; // peperoni
                            onion = ("✓");
                        }
                        break;
                    case "5":
                        if (s == "Small")
                        {
                            toppins[6] = 1; // peperoni
                            chiken = ("✓");
                        }
                        else if (s == "Medium")
                        {
                            toppins[6] = 2; // peperoni
                            chiken = ("✓");
                        }
                        else if (s == "Large")
                        {
                            toppins[6] = 3; // peperoni
                            chiken = ("✓");
                        }

                        break;
                    case "6":
                        if (s == "Small")
                        {
                            toppins[8] = 1; // peperoni
                            chorixo = ("✓");
                        }
                        else if (s == "Medium")
                        {
                            toppins[8] = 2; // peperoni
                            chorixo = ("✓");
                        }
                        else if (s == "Large")
                        {
                            toppins[8] = 3; // peperoni
                            chorixo = ("✓");
                        }

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

