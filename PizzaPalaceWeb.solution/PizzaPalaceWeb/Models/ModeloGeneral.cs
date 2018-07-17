using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPalaceWeb.Models
{
    public class ModeloGeneral
    {
       
            public IEnumerable<UsersModel> User { get; set; }
            public IEnumerable<OrderM> Orders { get; set; }
            public IEnumerable<PizzaM> Pizza { get; set; }

            public int Counter { get; set; } = 1;
            public SelectListItem SelectTopping { get; set; }
            public SelectListItem SelectSize { get; set; }
        
    }
}
