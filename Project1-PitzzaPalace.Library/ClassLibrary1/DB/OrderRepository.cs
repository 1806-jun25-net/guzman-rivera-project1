using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.DB
{
    class OrderRepository
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
    }
}
