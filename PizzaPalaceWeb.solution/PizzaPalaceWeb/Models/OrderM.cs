using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPalaceWeb.Models
{
    public class OrderM
    {
        public int OrderId { get; set; }
        public int? UserIdfk { get; set; }
        public int? LocationsIdfk { get; set; }
        public DateTime? DateTimeOrder { get; set; }
    }
}
