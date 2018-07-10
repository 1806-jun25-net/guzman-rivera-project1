using ClassLibrary1;
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

        // Main interface
        public void WellcomeMenu()
        {
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
            user.Add(new User2(name, lastname, phonenumber));
            Setnames.nAME = name;



            //var repo = new UserRepository(new PizzaPalacedbContext());
            var repo = new UserRepository(new PizzaPalacedbContext());
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("     Searching for user please wait...");
            var Location = repo.GetDefaultLocation(name, phonenumber);

            switch (Location)
            {
                case 0:
                    WelcomeNewUser();
                    LocationMenu();
                    break;
                case 1:
                    Found();
                    P1.PizzaPalace();
                    break;
                case 2:
                    Found();
                    P1.Angelitospizza();
                    break;
                case 3:
                    Found();
                    P1.Belitopizza();
                    break;
                default:
                    Console.WriteLine("No Default Location in ConsoleMenu()");
                    Console.WriteLine("Redirecting to locationMenu");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    LocationMenu();
                    break;
            }
        }

        public void Found()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine(" Welcome Back " + name + "!");
            Console.WriteLine("Redirecting to your favorite Pizza Paradise");
            Console.WriteLine("");
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();

        }

        public void WelcomeNewUser()
        {
            Console.WriteLine("");
            Console.WriteLine(" ============= Welcome " + name + "================");
            Console.WriteLine("");
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();

        }

        public void LocationMenu()
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
            Selection = Console.ReadLine();

            /////////////// VALIDATION OF SELECTION ///////////////////
            switch (Selection)
                {
                    case "1":
                        P1.PizzaPalace();
                        break;
                    case "2":

                        P1.Angelitospizza();
                        break;
                    case "3":

                        P1.Belitopizza();
                        break;
                    default:
                        Console.WriteLine("");
                        Console.WriteLine("Choose from 1 to 3!");
                        Console.WriteLine("");
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                        LocationMenu();
                        break;
                }
        }
    }
}
