using ClassLibrary1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class UserRepository
    {

        private readonly PizzaPalacedbContext _db;

        public UserRepository(PizzaPalacedbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public void GetUser(string UserToGet)
        {
            var user = _db.Users.FirstOrDefault(g => g.Names == UserToGet);
            if (user == null)
            {
                 Console.WriteLine("No User found");
            }
            else
            {
                Console.WriteLine("" + user.Names + "" + user.LastName);
                Console.ReadLine();
                
                
            }
        }

        public bool GetManager(string UserToGet, string phoneNumber)
        {
            var Manager = _db.Users.FirstOrDefault(g => g.Names == UserToGet && g.LastName == phoneNumber);
            if (Manager == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public int? GetDefaultLocation(string UserToGet, string phoneNumber, List<User2> user3)
        {
            var user = _db.Users.FirstOrDefault(g => g.Names == UserToGet && g.PhoneNumber == phoneNumber);
            if (user == null)
            {
                return 0;
            }
            else
            {
                return user.LocationId;
            }

        }

        public void AddUser(string name, string lastname, string phoneNumber, int? location, List<User2> user3)
        {

            var useradd = new Users
            {
                Names = name,
                LastName = lastname,
                PhoneNumber = phoneNumber,
                LocationId = location
            };
            _db.Add(useradd);
            _db.SaveChanges();
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

        //public void InsertLoc(string loc, int? doug, int? cheese, int? pepperoni, int? sausage, int? bacon, int? onion, int? chiken, int? sauce, int? chorizo)
        //{
        //    // LINQ: First fails by throwing exception,
        //    // FirstOrDefault fails to just null
        //    var useradd = new Locations
        //    {
        //        Location = loc,
        //        doug = lastname,
        //        PhoneNumber = phoneNumber,
        //        LocationId = location
        //    };
        //    _db.Add(useradd);
        //}

        public bool CheckForInventory()
        {/*
            var location1 = _db.Locations.FirstOrDefault(g => g.LocationsId == UserToGet && g.PhoneNumber == phoneNumber);
            if (user == null)
            {
                return 0;
            }
            else
            {
                return user.LocationId;
            }*/
            return false; // borrar
        } ////////////


    }
}
