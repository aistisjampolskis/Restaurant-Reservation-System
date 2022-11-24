using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservationSystem.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; } 
        public string Description { get; set; }
        public double Price { get; set; }
        public int FileStatus { get; set; }

        public Item(int id, int invoiceId, string description, double price, int producer)
        {
            Id = id;
            InvoiceId = invoiceId;
            Description = description;
            Price = price;
            FileStatus = producer;
        }

        public Item()
        {
        }


    }
}
