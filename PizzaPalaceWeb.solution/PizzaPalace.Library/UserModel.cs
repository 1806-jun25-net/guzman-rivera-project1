using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaPalace.Library
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int? DefaultLocationFk { get; set; }
    }
}
