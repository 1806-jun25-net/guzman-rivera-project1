using ClassLibrary1.Models;
using System;
using System.Collections.Generic;

namespace pizzaPlace
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var user = new List<User>();
                // Main interface
                Console.WriteLine("        Welcome to Pizza Paradise!");
                Console.WriteLine("");
                Console.WriteLine("You'r name please: ");
                string name = Console.ReadLine();
                Console.WriteLine("Last Name: ");
                string lastname = Console.ReadLine();
                Console.WriteLine("Phone number: ");
                string phonenumber = Console.ReadLine();

                /*

                Search user by Name AND Phone for account

                */

                //////////////////////////// Location //////////////////////////
                Console.Clear();
                Console.WriteLine(" Type the number of the nearest or favorite Pizza Place(Paradise) /n");
                Console.WriteLine("1.GenericName Pizza.");
                Console.WriteLine("2.Angelitos Pizza.");
                Console.WriteLine("3.Belito Pizza.");

                ////////////////////////////////////////////////////////////////////

                /*

                    Search user by Name AND Phone for account

                */


                // var user = new List<User>();
                // user.Add(new User(name, lastname, phonenumber));

                /*
                switch (Console.ReadLine())
                {
                    case "s":
                         var user = new List<User>();
                        user.Add(new User(n = Console.ReadLine(), 1, true));
                        user.Add(new User("Casquehead lizard", 0, false));
                        user.Add(new User("Green iguana", 4, true));
                        user.Add(new User("Blotched blue-tongue lizard", 0, false));
                        user.Add(new User("Gila monster", 1, false));
                        
                        try
                        {
                            using (Stream stream = File.Open("data.bin", FileMode.Create))
                            {
                                BinaryFormatter bin = new BinaryFormatter();
                                bin.Serialize(stream, user);
                            }
                        }
                        catch (IOException)
                        {
                        }
                        break;

                    case "r":
                        try
                        {
                            using (Stream stream = File.Open("data.bin", FileMode.Open))
                            {
                                BinaryFormatter bin = new BinaryFormatter();

                                var lizards2 = (List<User>)bin.Deserialize(stream);
                                foreach (User lizard in lizards2)
                                {
                                    //Console.WriteLine("{0}, {1}, {2}",
                                       // lizard.Type,
                                       // lizard.Number,
                                       // lizard.Healthy);
                                }
                            }
                        }
                        catch (IOException)
                        {
                        }
                        break;
                }*/
            }

        }
    }
}
