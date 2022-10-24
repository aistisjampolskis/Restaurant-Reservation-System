using Saskaitos_generavimas.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saskaitos_generavimas.Repositories
{
    public class ItemsOnInvoiceRepository
    {
        private List<ItemOnInvoice> Item { get; set; } = new List<ItemOnInvoice>();

       public ItemsOnInvoiceRepository()
        { 
         //   Item.AddRange(new ItemOnInvoice(1, "KL1", "2022-10-20 14:43:27", 20, "Maxima", "baton","sudon","alala","Pienas", 82, 10, 820, 20, 45));

        }

        public List<ItemOnInvoice> RetrieveList()
        {
            return Item;
        }

        public ItemOnInvoice RetrieveById(int id)
        {
            return Item.SingleOrDefault(x => x.Id == id);
        }

       /* public ItemOnInvoice RetrievebyDescription(string description)
        {
            return Item.SingleOrDefault(x => x.Description == description);
        }*/

        public void Save(ItemOnInvoice Item2)
        {
            Item.Add(Item2);
        }

        internal Stream RetrieveList(InvoiceItem invoiceItem)
        {
            throw new NotImplementedException();
        }
    }
}
