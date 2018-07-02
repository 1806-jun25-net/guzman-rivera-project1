using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public interface IUser
    {
        string Name { get;}
        string LastName { get;}
        string PhoneNumber { get;}
        string LastOrder { get;}
        string DefaultStore { get;}
        
    }


}
