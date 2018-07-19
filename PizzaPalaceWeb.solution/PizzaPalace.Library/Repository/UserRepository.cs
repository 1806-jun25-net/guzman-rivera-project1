using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PizzaPalace.Data;
using PizzaPalace.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaPalace.Library
{
    public class UserRepository
    {
        private readonly PizzaPalacedbContext _db;

        public UserRepository(PizzaPalacedbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public List<int> toppins = new List<int>();

        public int GetUserIDByPhone(string findUser, string phone)
        {

            var user = _db.Users.FirstOrDefault(g => g.FirstName == findUser && g.PhoneNumber == phone);
            if (user == null)
            {
                return 1;
            }
            else
            {
                return user.Id;
            }


        }

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

        public void SubmitOrder(int UserIDfk, int  LocationFK)
        {
            // LINQ: First fails by throwing exception,
            // FirstOrDefault fails to just null
            DateTime date = new DateTime();
            var useradd = new Orders
            {
                UserIdfk = UserIDfk,
                LocationsIdfk = LocationFK,
                DateTimeOrder = DateTime.Now
            };
            _db.Add(useradd);
            _db.SaveChanges();
        }

        public int? GetOrderByUserId(int? findUserId)
        {
            var Ordertab = GetOrdersTable();
            var order = Ordertab.FirstOrDefault(i => i.UserIdfk == findUserId);
            if (order == null)
            {
                return 0;
            }

            else
            {
                return order.OrderId;
            }


        }

        public void Cheesepizza(int S, int thelocation, double cost, string Pizza, int OrderID)
        {
            if (S == 1)
            {
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
                InventorySubStract(S, thelocation, toppins,  cost, Pizza, OrderID);
            }
            else if (S == 2)
            {
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
                InventorySubStract(S,thelocation, toppins, cost, Pizza, OrderID);
            }
            else if (S == 3)
            {
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
                InventorySubStract(S,thelocation, toppins, cost, Pizza, OrderID);
            }


        }

        public void Pepperoni(int S, int thelocation, double cost, string Pizza, int OrderID)
        {
            if (S == 1)
            {
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
                InventorySubStract(S,thelocation, toppins, cost, Pizza, OrderID);
            }
            else if (S == 2)
            {
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
                InventorySubStract(S, thelocation, toppins, cost, Pizza, OrderID);
            }
            else if (S == 3)
            {
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
                InventorySubStract(S, thelocation, toppins, cost, Pizza, OrderID);
            }


        }

        public void AllMeat(int S,  int thelocation, double cost, string Pizza, int OrderID)
        {
            if (S == 1)
            {
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
                InventorySubStract(S,thelocation, toppins, cost, Pizza, OrderID);
            }
            else if (S == 2)
            {
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
                InventorySubStract(S,thelocation, toppins, cost, Pizza, OrderID);
            }
            else if (S == 3)
            {
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
                InventorySubStract(S,thelocation, toppins, cost, Pizza, OrderID);
            }
        }

        public void Chorizo(int S, int thelocation, double cost, string Pizza, int OrderID)
        {
            if (S == 1)
            {
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
                InventorySubStract(S,thelocation, toppins, cost, Pizza, OrderID);
            }
            else if (S == 2)
            {
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
                InventorySubStract(S,thelocation, toppins, cost, Pizza, OrderID);
            }
            else if (S == 3)
            {
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
                InventorySubStract(S,thelocation, toppins, cost, Pizza, OrderID);
            }
        }

        public void Bacon(int S,  int thelocation, double cost, string Pizza, int OrderID)
        {
            if (S == 1)
            {
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
                InventorySubStract(S,thelocation, toppins, cost, Pizza, OrderID);
            }
            else if (S == 2)
            {
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
                InventorySubStract(S,thelocation, toppins, cost, Pizza, OrderID);
            }
            else if (S == 3)
            {
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
                InventorySubStract(S,thelocation, toppins, cost, Pizza, OrderID);

            }

        }

        public bool checkInv(int location)
        {
            var LocInventory = _db.Locations.FirstOrDefault(g => g.LocationsId == location);
            if (LocInventory == null)
            {
                return false;
            }
            else if (LocInventory.Doug < 3)
            {
                return false;
            }
            return true;
        }

        public bool InventorySubStract(int S,int location, List<int> toppins, double cost, string Pizza, int OrderID)
        {
            string sis;
            if(S == 1)
            {
                sis = "Small";
            }
            else if(S ==2)
            {
                sis = "Medium";
            }
            else
            {
                sis = "Large";
            }
            var LocInventory = _db.Locations.FirstOrDefault(g => g.LocationsId == location);

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
                 Addpizza(Pizza, sis, cost, toppins, OrderID);
                _db.SaveChanges();
                return true;
            
        }

        public void Addpizza(string pizza, string size,double Cost, List<int> toppins, int OrderID)
        {

            var Pizzaadd = new Pizza
            {
                Pizza1 = pizza,
                Size = size,
                Cost = Cost,
                OrdersIdfk = OrderID,
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