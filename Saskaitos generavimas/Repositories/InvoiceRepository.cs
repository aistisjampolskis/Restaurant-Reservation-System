using Saskaitos_generavimas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saskaitos_generavimas.Repositories
{
    public class InvoiceRepository
    {
        private List<InvoiceItem> Invoice { get; set; } = new List<InvoiceItem>();
        public InvoiceRepository()
        {
         //   Invoice.Add(new InvoiceItem(1, "1", "2022-10-22", 2, "Maxima", 45, ))
        }
    }
}
