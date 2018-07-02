using ClassLibrary1.Models;
using System;

namespace PitzzaPalace.Library
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            User user1 = new User
            {
                Name = Console.ReadLine(),
                LastName = Console.ReadLine(),
                PhoneNumber = Console.ReadLine(),
                LastOrder = "Today",
                DefaultStore = "Bayamon"
            };

            Console.WriteLine($"Showing movie {user1}!");
            Console.ReadLine();

        }
    }
}
