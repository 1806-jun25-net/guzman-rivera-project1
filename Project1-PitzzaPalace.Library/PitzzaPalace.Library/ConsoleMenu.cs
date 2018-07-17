using ClassLibrary1;
using ClassLibrary1.DB;
using ClassLibrary1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaPalace
{
    public class ConsoleMenu
    {
        Location2 P1 = new Location2();
        string Selection, name, lastname, phonenumber;
        Order2 Setnames = new Order2();
        public int value;
        int count = 0;
        // Main interface
        public void WellcomeMenu()
        {
            var repo = new UserRepository(new PizzaPalacedbContext());
            var user = new List<User2>();
            Console.Clear();
            Console.WriteLine("========== Welcome to Pizza Paradise!==========");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine(" Your name please: ");
            name = Console.ReadLine();
            Console.WriteLine(" Last Name: ");
            lastname = Console.ReadLine();
            Console.WriteLine(" Phone number (just numbers): ");
            phonenumber = Console.ReadLine();

            /////// ADDING USER 
            user.Add(new User2(name, lastname, phonenumber));
            repo.AddUser(name, lastname, phonenumber, 1, user); //////UPDATE LOC

            ///////////////////////////////////////////////////////////
            string manager = "Manager";
            ///////////////////////////////////////////////////////////
            //var repo = new UserRepository(new PizzaPalacedbContext());


            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("     Searching for user please wait...");
            repo.GetManager(name, lastname);

            while (repo.GetManager(manager, phonenumber))
            {
                Manager();
            }
            var Location = repo.GetDefaultLocation(name, phonenumber, user);
            //var Location = 1;
            bool done = true;
            Console.WriteLine("\n\n      How many Pizza will you buy?: ");
            string pizunt = Console.ReadLine();


            while (done)
            {
                if (int.TryParse(pizunt, out value))
                {
                    value = Int32.Parse(pizunt);
                    if (value < 13)
                    {
                        done = false;
                    }
                    else
                    {
                        Console.WriteLine("One can only order 12 pizzas or less. ");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a number.. ");
                }
            }


            switch (Location)
            {
                case 0:
                    WelcomeNewUser(user);
                    do
                    {

                        P1.PizzaPalace(user, Location);
                        count++;
                    } while (count <= value);
                    LocationMenu(user);
                    break;
                case 1:
                    Found(user);

                    do
                    {

                        P1.PizzaPalace(user, Location);
                        count++;
                    } while (count <= value);
                    P1.PizzaPalace(user, Location);
                    break;
                case 2:
                    Found(user);

                    do
                    {

                        P1.Angelitospizza(user, 2);
                        count++;
                    } while (count <= value);
                    P1.Angelitospizza(user, 2);
                    break;
                case 3:
                    Found(user);

                    do
                    {

                        P1.Belitopizza(user, 3);
                        count++;
                    } while (count <= value);
                    P1.Belitopizza(user, 3);
                    break;
                default:
                    Console.WriteLine("No Default Location in ConsoleMenu()");
                    Console.WriteLine("Redirecting to locationMenu");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    LocationMenu(user);
                    break;
            }
        }

        public void Manager()
        {
            var repoO = new OrderRepository(new PizzaPalacedbContext());
            var repo = new UserRepository(new PizzaPalacedbContext());
            Console.Clear();
            Console.WriteLine("---- Manager Window ----");
            Console.WriteLine("1 Search Users by name");
            Console.WriteLine("2 all from user");
            Console.WriteLine("3 Close application ");
            string select = Console.ReadLine();


            switch (select)
            {
                case "1":
                    Console.WriteLine("\n");
                    Console.WriteLine("Enter Name to search: ");
                    repo.GetUser(Console.ReadLine());
                    break;
                case "2":
                    Console.WriteLine("Write Name: ");
                    string user = Console.ReadLine();
                    repoO.GetUserOrder("Kevin", "Ramos");
                    break;

                case "3":
                    Environment.Exit(0);
                    break;

                case "4":

                    break;

                case "5":

                    break;

                case "6":

                    break;

                case "7":

                    break;
                default:
                    Console.WriteLine("Sorry, invalid selection");
                    Console.ReadLine();
                    Manager();
                    break;
            }
        }

        public void Found(List<User2> user3)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine(" ~~~~~~~~~~~~~~~~~~ Welcome Back " + name + "! ~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("");
            Console.WriteLine("        Redirecting to your favorite Pizza Paradise!");
            Console.WriteLine("");
            Console.WriteLine("                Press enter to continue...");
            Console.ReadLine();

        }

        public void WelcomeNewUser(List<User2> user3)
        {
            Console.WriteLine("");
            Console.WriteLine(" ============= No User found ================");
            Console.WriteLine("");
            Console.WriteLine("         Press enter to continue...");
            Console.ReadLine();

        }

        public void LocationMenu(List<User2> user3)
        {
            var repo = new UserRepository(new PizzaPalacedbContext());

            Console.Clear();
            Console.WriteLine("========Type the number of the nearest or favorite Pizza Place ========");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("1) for Pizza Palace.");
            Console.WriteLine("");
            Console.WriteLine("2) for Angelitos Pizzeria.");
            Console.WriteLine("");
            Console.WriteLine("3) for Belito's Pizza.");
            Console.WriteLine("");
            Console.WriteLine("4) Close application");
            Selection = Console.ReadLine();

            /////////////// VALIDATION OF SELECTION ///////////////////
            switch (Selection)
            {
                case "1":
                    P1.PizzaPalace(user3, 1);
                    break;
                case "2":

                    P1.Angelitospizza(user3, 2);
                    break;
                case "3":

                    P1.Belitopizza(user3, 3);
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("");
                    Console.WriteLine("Choose from 1 to 3!");
                    Console.WriteLine("");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    LocationMenu(user3);
                    break;
            }
        }
    }
}
