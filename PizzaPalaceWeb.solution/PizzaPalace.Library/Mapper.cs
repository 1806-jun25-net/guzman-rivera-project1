using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaPalace.Library.Models
{
    static class Mapper
    {
        public static UserModel Map(Data.Users usuario) => new UserModel
        {
            Id = usuario.Id,
            FirstName = usuario.FirstName,
            LastName = usuario.LastName,
            DefaultLocationFk = usuario.DefaultLocationFk,
            PhoneNumber = usuario.PhoneNumber
        };

        public static Data.Users Map(UserModel usuario) => new Data.Users
        {
            Id = usuario.Id,
            FirstName = usuario.FirstName,
            LastName = usuario.LastName,
            DefaultLocationFk = usuario.DefaultLocationFk,
            PhoneNumber = usuario.PhoneNumber
        };

        public static IEnumerable<UserModel> Map(IEnumerable<Data.Users> restaurants) => restaurants.Select(Map);
        public static IEnumerable<Data.Users> Map(IEnumerable<UserModel> restaurants) => restaurants.Select(Map);
    }
}
