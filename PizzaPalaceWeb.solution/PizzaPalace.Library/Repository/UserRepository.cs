using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PizzaPalace.Data;
using PizzaPalace.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
//using PizzaPalace.Library.Models;

namespace PizzaPalace.Library
{
    public class UserRepository
    {
        private readonly PizzaPalacedbContext _db;

        public UserRepository(PizzaPalacedbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        //public void GetUser(string UserToGet)
        //{
        //    var user = _db.Users.FirstOrDefault(g => g.FirstName == UserToGet);
        //    if (user == null)
        //    {
        //        Console.WriteLine("No User found");
        //    }
        //    else
        //    {
        //        Console.WriteLine("" + user.FirstName + "" + user.LastName);
        //        Console.ReadLine();


        //    }

        //}

       /* public int? GetDefaultLocation(string UserToGet, string phoneNumber, List<User2> user3)
        {
            var user = _db.Users.FirstOrDefault(g => g.FirstName == UserToGet && g.PhoneNumber == phoneNumber);
            if (user == null)
            {
                return 0;
            }
            else
            {
                return user.DefaultLocationFk;
            }
            return 2;
        }*/

       /* public void AddUser(string name, string lastname, string phoneNumber, int? location, List<User2> user3)
        {

            var useradd = new Users
            {
                FirstName = name,
                LastName = lastname,
                PhoneNumber = phoneNumber,
                DefaultLocationFk = location
            };
            _db.Add(useradd);
            _db.SaveChanges();
        }*/

        public void InsertLoc(string loc, int doug, int cheese, int pepperoni, int sausage, int bacon, int onion, int chiken, int sauce, int chorizo)
        {

            var locat = new Locations
            {
                Locations1 = loc,
                Doug = doug,
                Cheese = cheese,
                Pepperoni = pepperoni,
                Sausage = sausage,
                Bacon = bacon,
                Onion = onion,
                Chiken = chiken,
                Sauce = sauce,
                Chorizo = chorizo
            };
            _db.Add(locat);
            _db.SaveChanges();
        }

        public void SubmitOrder(string name, string lastname, string phoneNumber, int? location)
        {
            // LINQ: First fails by throwing exception,
            // FirstOrDefault fails to just null
            var useradd = new Users
            {
                FirstName = name,
                LastName = lastname,
                PhoneNumber = phoneNumber,
                DefaultLocationFk = location
            };
            _db.Add(useradd);
            _db.SaveChanges();
        }

        public bool InventorySubStract(int location, List<int> toppins)
        {

            var LocInventory = _db.Locations.FirstOrDefault(g => g.LocationsId == location);
            if (LocInventory == null)
            {
                return false;
                // Console.WriteLine("Problem substracting from inventory on: " + LocInventory);
            }
            else if (LocInventory.Doug < 3)
            {
                // Console.WriteLine("No enough material for pizza " + LocInventory.Locations1);
                //Console.ReadLine();
                //  Environment.Exit(0);
                return false;
            }
            else
            {
                LocInventory.Doug = LocInventory.Doug - toppins[0];
                LocInventory.Cheese = LocInventory.Cheese - toppins[1];
                LocInventory.Pepperoni = LocInventory.Pepperoni - toppins[2];
                LocInventory.Sausage = LocInventory.Sausage - toppins[3];
                LocInventory.Bacon = LocInventory.Bacon - toppins[4];
                LocInventory.Onion = LocInventory.Onion - toppins[5];
                LocInventory.Chiken = LocInventory.Chiken - toppins[6];
                LocInventory.Sauce = LocInventory.Sauce - toppins[7];
                LocInventory.Chorizo = LocInventory.Chorizo - toppins[8];

                _db.Entry(_db.Locations.FirstOrDefault(g => g.LocationsId == location)).CurrentValues.SetValues(LocInventory);
                _db.SaveChanges();
                return true;
                //Console.WriteLine("Store Inventory  DB change");
            }
        }

        public void Addpizza(string pizza, string size, List<int> toppins)
        {

            var Pizzaadd = new Pizza
            {
                Pizza1 = pizza,
                Size = size,
                Doug = toppins[0],
                Cheese = toppins[1],
                Pepperoni = toppins[2],
                Sausage = toppins[3],
                Bacon = toppins[4],
                Onion = toppins[5],
                Chiken = toppins[6],
                Sauce = toppins[7],
                Chorizo = toppins[8]
            };
            _db.Add(Pizzaadd);
            _db.SaveChanges();
            Console.WriteLine("Pizza added to DB");
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

        public void AddUser(string name, string Last, string phone, int locaions)
        {

            var LocID = _db.Locations.LastOrDefault(g => g.LocationsId > 0);
            var TransID = _db.Orders.LastOrDefault(g => g.OrderId > 0);
            var user = new Users
            {
                PhoneNumber = phone,
                FirstName = name,
                LastName = Last,
                DefaultLocationFk = locaions,
            };
            _db.Add(user);
            _db.SaveChanges();
        }

        public void GetUserOrder (string UserToGet, string lastname)
        {
            var user = _db.Users.FirstOrDefault(g => g.FirstName == UserToGet && g.LastName == lastname);
            var userID = user.Id;
            var won = GetOrdersTable();
            var order = won.Where(q => q.UserIdfk == userID);
            var pizzas = GetPizza();

            foreach (var item in order)
            {
                Console.WriteLine("\n      Order Number: " + item.OrderId + "  Date: " + item.DateTimeOrder);

                foreach (var item2 in pizzas)
                {
                    Console.WriteLine("\n Pizza: " + item2.Pizza1 + "\n Size: " + item2.Size + "\n Cost: " + item2.Cost + "\n\n");

                }
            }
        }

        public IEnumerable<Orders> GetLocationOrders(int location_id)
        {

            var OrderLocations = _db.Orders.Where(g => g.LocationsIdfk == location_id).OrderBy(w => w.DateTimeOrder);
            return OrderLocations;
        }

        public string SugestedOrder(string UserToGet, string lastnamer)
        {
            var user = _db.Users.FirstOrDefault(g => g.FirstName == UserToGet && g.LastName == lastnamer);
            var userID = user.Id;
            var won = GetOrdersTable();
            var order = won.LastOrDefault(q => q.UserIdfk == userID); //
            var Allpizzas = GetPizza();
            var pizzas = _db.Pizza.LastOrDefault(q => q.OrdersIdfk == order.OrderId);
            Console.WriteLine(order.OrderId);
            Console.WriteLine("\nLast Pizza: " + pizzas.Pizza1 + " Size: " + pizzas.Size + " Cost: $" + pizzas.Cost);
            return "\nLast Pizza: " + pizzas.Pizza1 + " Size: " + pizzas.Size + " Cost: $" + pizzas.Cost;

        }

        public IEnumerable<Orders> GetOrdersTable()
        {
            List<Orders> order = _db.Orders.ToList();
            return order;
        }

        public IEnumerable<Users> GetUsertable()
        {
            List<Users> user = _db.Users.ToList();
            return user;
        }

        public IEnumerable<Pizza> GetPizza()
        {
            List<Pizza> pizza = _db.Pizza.ToList();
            return pizza;
        }

        public IEnumerable<Locations> GetLocation()
        {
            List<Locations> loc = _db.Locations.ToList();
            return loc;
        }

        //public IEnumerable<UserModel> GetUser(string UserToGet = null)
        //{
            
        //    if (UserToGet == null)
        //    {
                
        //        //return Mapper.Map(_db.Users.FirstOrDefault(g => g.FirstName == UserToGet));

        //    }
        //    else
        //    {

        //      //  return Mapper.Map(_db.Users.FirstOrDefault(g => g.FirstName == UserToGet));
        //    }
        //}

        // cheaper 
        public IEnumerable<Pizza> GetLocationOrdersByCheapest(int location_id)
        {

            var OrderLocations = _db.Pizza.Where(g => g.OrdersIdfk == location_id).OrderBy(g => g.Cost);
            return OrderLocations;
        }
        //most expensive
        public IEnumerable<Pizza> GetLocationOrdersMostExpensive(int location_id)
        {

            var OrderLocations = _db.Pizza.Where(g => g.OrdersIdfk == location_id).OrderByDescending(g => g.Cost);
            return OrderLocations;
        }
        //latest order in location
        public IEnumerable<Orders> GetLocationOrderLatest(int location_id)
        {

            var OrderLocations = _db.Orders.Where(g => g.LocationsIdfk == location_id).OrderByDescending(g => g.DateTimeOrder);
            return OrderLocations;
        }
        //earliest order in location
        public IEnumerable<Orders> GetLocationOrderEarliest(int location_id)
        {

            var OrderLocations = _db.Orders.Where(g => g.LocationsIdfk == location_id).OrderBy(g => g.DateTimeOrder);
            return OrderLocations;
        }
    }
}