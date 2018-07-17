using System;
using System.Collections.Generic;




namespace ClassLibrary1.Models
{
    //[Serializable()]
    public class User2 : IUser
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string LastOrder { get; set; }
        public string DefaultStore { get; set; }

        // Contructor
        // 

        public User2(string na, string ln, string pn)
        {
            Name = na;
            LastName = ln;
            PhoneNumber = pn;
        }

        /*
        public User(string na, string ln, string pn, string lo, string ds)
        {
            Name = na;
            LastName = ln;
            PhoneNumber = pn;
            LastOrder = lo;
            DefaultStore = ds;

        }
        */
        // 

        // get a suggested order for a user based on his order history
        public string SuggestedOrder()
        {


            return "hola";
        }
        // search users by name





    }
}
