using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservationSystem
{
    public class RandomNumberGenerator
    {
            public int NumberGenerator()
            {
                Random rnd = new Random();
                for (int j = 0; j < 1; j++)
                {
                }
            return rnd.Next(10000);
            }
        
    }
}
