using Newtonsoft.Json;
using RestaurantReservationSystem.Entities;
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

namespace RestaurantReservationSystem.Repositories
{
    public class ItemsOnInvoiceRepository
    {
        private List<ItemOnInvoice> Item { get; set; } = new List<ItemOnInvoice>();

        public ItemsOnInvoiceRepository()
        {
        }

        public List<ItemOnInvoice> RetrieveList()
        {
            return Item;
        }
        public ItemOnInvoice RetrieveById(int id)
        {
            return Item.SingleOrDefault(x => x.Id == id);
        }
        public void Save(ItemOnInvoice Item2)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.All),
                WriteIndented = true
            };
            string path = @"C:\Users\aisti\OneDrive\Desktop\C# Advanced\reservationtable\Saskaitos generavimas\Invoice.json";
            var jsonString = File.ReadAllText(path);
            var list = JsonConvert.DeserializeObject<List<ItemOnInvoice>>(jsonString);
            list.Add(Item2);
            var convertedJson = JsonConvert.SerializeObject(list, Formatting.Indented);
            File.WriteAllText(path, convertedJson);
        }
    }
}

