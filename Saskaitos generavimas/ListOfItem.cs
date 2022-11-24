using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservationSystem
{
    public class ListOfItem
    {
        public string Description { get; set; }
        public int Quantyti { get; set; }
        public double Price { get; set; }
        public double RowTotal { get; set; }


        public ListOfItem(string description, int quantyti, double price, double rowTotal)
        {
            Description = description;
            Quantyti = quantyti;
            Price = price;
            RowTotal = rowTotal;
        }

        public ListOfItem()
        {
        }
    }
}
