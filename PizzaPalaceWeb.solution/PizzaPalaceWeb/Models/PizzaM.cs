using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPalaceWeb.Models
{
    public class PizzaM
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

        [Required]
        public SelectListItem SS { get; set; }
        [Required]
        public SelectListItem SP { get; set; }
    }
}
