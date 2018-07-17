using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaPalace.Data
{
    public class PizzaOrders
    {
        public IEnumerable<Orders> OT { get; set; }
        public IEnumerable<Pizza> PT { get; set; }
        public IEnumerable<Users> UT { get; set; }
    }
}
