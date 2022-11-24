using RestaurantReservationSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservationSystem.Repositories
{
    public class InvoiceRepository
    {
        private List<InvoiceItem> Invoice { get; set; } = new List<InvoiceItem>();
        public InvoiceRepository()
        {
        }
    }
}
