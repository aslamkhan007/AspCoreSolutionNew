using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreSolution.Models
{
  public  interface IRentOutBoat
    {
        IEnumerable<RentOutBoat> GetAllRentOutBoats();
        int AddRentOutBoats(RentOutBoat rentOutBoat);
    }
}
