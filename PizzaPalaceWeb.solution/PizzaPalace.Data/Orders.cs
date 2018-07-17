
using System;
using System.Collections.Generic;

namespace PizzaPalace.Data
{
    public partial class Orders
    {
        public Orders()
        {
            Pizza = new HashSet<Pizza>();
        }

        public int OrderId { get; set; }
        public int? UserIdfk { get; set; }
        public int? LocationsIdfk { get; set; }
        public DateTime? DateTimeOrder { get; set; }

        public Locations LocationsIdfkNavigation { get; set; }
        public Users UserIdfkNavigation { get; set; }
        public ICollection<Pizza> Pizza { get; set; }
        //public SelectListItem SelectedSize { get; set; }

    }
}
