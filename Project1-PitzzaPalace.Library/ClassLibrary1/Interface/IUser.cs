using System;
using System.Collections.Generic;


namespace ClassLibrary1
{
    public interface IUser
    {
        string Name { get; set; }
        string LastName { get; set; }
        string PhoneNumber { get; set; }
        string LastOrder { get; set; }
        string DefaultStore { get; set; }
        
    }


}
