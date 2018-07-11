using ClassLibrary1;
using ClassLibrary1.DB;
using ClassLibrary1.Models;
using Microsoft.Extensions.Options;
using PizzaPalace;
using System;
using System.Collections.Generic;

namespace PitzzaPalace.Library
{
    class Program
    {
        static void Main(string[] args)
        {
            ////////////////////////// Objects //////////////////////
            Location2 P1 = new Location2();
            ConsoleMenu menus = new ConsoleMenu();
            Order2 orderRepository = new Order2();
            /////////////////////////////////////////////////////////
            bool a = true;
            while (a)
            {
                ///////////////// call first menu [ WELCOME ] //////////////////////


                

                menus.WellcomeMenu();

                /////////////////////////////////////////////////////////////////

                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("DONE!!");
                Console.WriteLine("");
                Console.WriteLine();
                Console.ReadLine();
                a = false;
                ////////////////////////////////////////////////////////////////////

            }

        }
    }
}
