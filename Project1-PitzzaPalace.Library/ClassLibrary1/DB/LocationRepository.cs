using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class LocationRepository
    {

        private readonly PizzaPalacedbContext _db;

        public LocationRepository(PizzaPalacedbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public void InsertLoc(string loc, int doug, int cheese, int pepperoni, int sausage, int bacon, int onion, int chiken, int sauce, int chorizo)
        {
            // LINQ: First fails by throwing exception,
            // FirstOrDefault fails to just null
            var locat = new Locations
            {
                Locations1 = loc,
                Doug = doug,
                Cheese = cheese,
                Pepperoni = pepperoni,
                Sausage = sausage,
                Bacon = bacon,
                Onion = onion,
                Chiken = chiken,
                Sauce = sauce,
                Chorizo = chorizo
            };
            _db.Add(locat);
        }
    }
}
