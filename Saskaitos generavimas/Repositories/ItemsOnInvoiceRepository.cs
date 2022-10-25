using Newtonsoft.Json;
using Saskaitos_generavimas.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
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
            // Item.Add(Item2);
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.All),
                WriteIndented = true
            };
            string path = @"C:\Users\aisti\OneDrive\Desktop\C#\Strukturos 2022-09-26\Saskaitos generavimas\Saskaitos generavimas\Saskaitos generavimas\Invoice.json";
            var jsonString = File.ReadAllText(path);
            var list = JsonConvert.DeserializeObject<List<ItemOnInvoice>>(jsonString);
            list.Add(Item2);
            var convertedJson = JsonConvert.SerializeObject(list, Formatting.Indented);
            File.WriteAllText(path, convertedJson);
        }
        /* public string Load3(int itemId)
         {
             var options = new JsonSerializerOptions
             {
                 Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.All),
                 WriteIndented = true
             };
             string path = @"C:\Users\aisti\OneDrive\Desktop\C#\Strukturos 2022-09-26\Saskaitos generavimas\Saskaitos generavimas\Saskaitos generavimas\Items.json";
             var jsonString = File.ReadAllText(path);
             var list = JsonConvert.DeserializeObject<List<Item>>(jsonString);
             var item = list.FirstOrDefault(x => x.Id == itemId);
             var itemDescription = item.Description;

             return itemDescription;
         }*/

        /* internal Stream RetrieveList(InvoiceItem invoiceItem)
         {
             throw new NotImplementedException();
         }*/
    }
}

