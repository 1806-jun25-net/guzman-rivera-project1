﻿using System;
using System.Collections.Generic;

namespace ClassLibrary1
{
    public partial class Pizza
    {
        public int PizzaId { get; set; }
        public string Pizza1 { get; set; }
        public string Size { get; set; }
        public double? Cost { get; set; }
        public int? OrdersIdfk { get; set; }
        public int? Doug { get; set; }
        public int? Cheese { get; set; }
        public int? Pepperoni { get; set; }
        public int? Sausage { get; set; }
        public int? Bacon { get; set; }
        public int? Onion { get; set; }
        public int? Chiken { get; set; }
        public int? Sauce { get; set; }
        public int? Chorizo { get; set; }

        public Orders OrdersIdfkNavigation { get; set; }
    }
}
