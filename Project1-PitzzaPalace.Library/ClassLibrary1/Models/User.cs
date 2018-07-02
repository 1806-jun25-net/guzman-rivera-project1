using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Models
{
    public class User : IUser
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string LastOrder { get; set; }

        public string DefaultStore { get; set; }
    }
}
