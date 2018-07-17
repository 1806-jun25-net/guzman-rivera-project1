using System;
using System.Collections.Generic;

namespace PizzaPalace.Data
{
    public partial class Users
    {
        public Users()
        {
            Orders = new HashSet<Orders>();
        }


        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int? DefaultLocationFk { get; set; }

        public Locations DefaultLocationFkNavigation { get; set; }
        public IEnumerable<Orders> Orders { get; set; }
    }
}
