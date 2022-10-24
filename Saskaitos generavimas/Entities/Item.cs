using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saskaitos_generavimas.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; } 
        public string Description { get; set; }
        public double Price { get; set; }
        public string Producer { get; set; }

        public Item(int id, int invoiceId, string description, double price, string producer)
        {
            Id = id;
            InvoiceId = invoiceId;
            Description = description;
            Price = price;
            Producer = producer;
        }

       
    }
}
