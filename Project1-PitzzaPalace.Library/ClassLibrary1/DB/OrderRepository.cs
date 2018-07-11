using ClassLibrary1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.DB
{
    public class OrderRepository
    {
        private readonly PizzaPalacedbContext _db;

        public OrderRepository(PizzaPalacedbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }
        
        public void SubmitOrder(string name, string lastname, string phoneNumber, int? location)
        {
            // LINQ: First fails by throwing exception,
            // FirstOrDefault fails to just null
            var useradd = new Users
            {
                Names = name,
                LastName = lastname,
                PhoneNumber = phoneNumber,
                LocationId = location
            };
            _db.Add(useradd);




        }

        //public void CustumizeInventory(List<Pizza2> PizzaObject)
        //{

        //    var useradd = new Users
        //    {
        //        Names = name,
        //        LastName = lastname,
        //        PhoneNumber = phoneNumber,
        //        LocationId = location
        //    };
        //    _db.Add(useradd);
        //}




        public void Addpizza(List<Pizza2> PizzaObject)
        {

            PizzaObject.ForEach(item => Console.WriteLine(" Name: " + item.Pizza1 + "\nPrice" + item.PizzaPrice + "\n" +
               " Size:" + item.Size));
            Console.ReadLine();

        }


    }
}
