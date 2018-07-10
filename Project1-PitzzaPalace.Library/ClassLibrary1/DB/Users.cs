using System;
using System.Collections.Generic;

namespace ClassLibrary1
{
    public partial class Users
    {
        public int UsersId { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Names { get; set; }
        public int? LocationId { get; set; }
        public int? Transactions { get; set; }

        public Locations Location { get; set; }
        public Locations TransactionsNavigation { get; set; }
    }
}
