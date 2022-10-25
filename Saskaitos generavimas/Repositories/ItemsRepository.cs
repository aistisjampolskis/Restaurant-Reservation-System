using Newtonsoft.Json;
using Saskaitos_generavimas.Entities;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;



namespace Saskaitos_generavimas.Repositories
{
    public class ItemsRepository
    {
        private List<Item> Items { get; set; } = new List<Item>();

        public ItemsRepository()
        {
           /* Items.Add(new Item(1, 1, "Pienas", 2.20, "Žemaitijos pienas"));
            Items.Add(new Item(2, 1,"Duona", 1.38, "Kėdainių duona"));
            Items.Add(new Item(3, 1, "Batonas", 0.38, "Krekenavos Batonas"));
            Items.Add(new Item(4, 1, "Sūris", 3.38, "Rokiškio sūris"));
            Items.Add(new Item(5, 1, "Dešra", 2.38, "Biovela"));
            Items.Add(new Item(6, 1, "Kefyras", 2.99, "Vylkiškiai"));
            Items.Add(new Item(11, 1, "Snickers", 2.99, "Nike"));*/
        }

       
       
        public Item RetrievebyDescription(string description)
        {
            return Items.SingleOrDefault(x => x.Description == description);
        }
        public void Save(Item item)
        {
           var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.All),
                WriteIndented = true
            };
            string path = @"C:\Users\aisti\OneDrive\Desktop\C#\Strukturos 2022-09-26\Saskaitos generavimas\Saskaitos generavimas\Saskaitos generavimas\Items.json";
            var jsonString = File.ReadAllText(path);
            var list = JsonConvert.DeserializeObject<List<Item>>(jsonString);
            list.Add(item);
            var convertedJson = JsonConvert.SerializeObject(list, Formatting.Indented);
            File.WriteAllText(path, convertedJson);
        }

     
       public string Load(int itemId)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.All),
                WriteIndented = true
            };
            string path = @"C:\Users\aisti\OneDrive\Desktop\C#\Strukturos 2022-09-26\Saskaitos generavimas\Saskaitos generavimas\Saskaitos generavimas\Items.json";
            var jsonString = File.ReadAllText(path);
            var list = JsonConvert.DeserializeObject<List<Item>>(jsonString);
            var item= list.FirstOrDefault(x => x.Id == itemId);
            var itemDescription = item.Description;

            return itemDescription;
            
        }
        public double Load2(int itemId)
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
            var itemPrice = item.Price;

            return itemPrice;

        }
        public Item RetrieveById(int id)
        {
            return Items.SingleOrDefault(x => x.Id == id);
        }

    }
}

