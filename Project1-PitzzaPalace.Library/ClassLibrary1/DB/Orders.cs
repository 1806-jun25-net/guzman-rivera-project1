using System;
using System.Collections.Generic;

namespace ClassLibrary1
{
    public partial class Orders
    {
        public double? Cost { get; set; }
        public string Size { get; set; }
        public int Transactions { get; set; }
        public int? OrderId { get; set; }
        public int? PizzaId { get; set; }
        public int? Locations { get; set; }

        public Locations LocationsNavigation { get; set; }
        public Pizza Pizza { get; set; }
    }
}
