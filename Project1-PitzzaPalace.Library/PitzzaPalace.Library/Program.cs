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
            var repo = new OrderRepository(new PizzaPalacedbContext());

            /////////////////////////////////////////////////////////
            //var repo = new OrderRepository(new PizzaPalacedbContext());
            bool a = true;
            while (a)
            {
                ///////////////// call first menu [ WELCOME ] //////////////////////


                //Console.WriteLine("Enter Name: ");
                //string user = Console.ReadLine();
                //Console.WriteLine("Enter LastName: ");
                //string last = Console.ReadLine();
                //repo.GetUserOrder(user, last);

                //menus.WellcomeMenu();
                //repo.GetUserOrder("Kevin", "Ramos");

                //int location_id = 1;
                //var locations = repo.GetLocationOrders(location_id);
                //foreach (var item in locations)
                //{
                //    Console.WriteLine("Location: 1 " + " Order No. " + item.OrderId + " \n Order Date & time: " + item.DateTimeOrder);
                //}
                //Console.ReadLine();

                repo.SugestedOrder("Angel", "Guzman");

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
