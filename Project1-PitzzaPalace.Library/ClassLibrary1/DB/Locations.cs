using System;
using System.Collections.Generic;

namespace ClassLibrary1
{
    public partial class Locations
    {
        public Locations()
        {
            Orders = new HashSet<Orders>();
            UsersLocation = new HashSet<Users>();
            UsersTransactionsNavigation = new HashSet<Users>();
        }

        public int LocationsId { get; set; }
        public string Locations1 { get; set; }
        public int? Doug { get; set; }
        public int? Cheese { get; set; }
        public int? Pepperoni { get; set; }
        public int? Sausage { get; set; }
        public int? Bacon { get; set; }
        public int? Onion { get; set; }
        public int? Chiken { get; set; }
        public int? Sauce { get; set; }
        public int? Chorizo { get; set; }

        public ICollection<Orders> Orders { get; set; }
        public ICollection<Users> UsersLocation { get; set; }
        public ICollection<Users> UsersTransactionsNavigation { get; set; }
    }
}
