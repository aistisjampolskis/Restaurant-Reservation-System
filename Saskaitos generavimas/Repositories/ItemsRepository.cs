using Newtonsoft.Json;
using RestaurantReservationSystem.Entities;
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



namespace RestaurantReservationSystem.Repositories
{
    public class ItemsRepository
    {
        private List<Item> Items { get; set; } = new List<Item>();
       
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
            string path = @"C:\Users\aisti\OneDrive\Desktop\C# Advanced\reservationtable\Saskaitos generavimas\food.json";
            var jsonString = File.ReadAllText(path);
            var list = JsonConvert.DeserializeObject<List<Item>>(jsonString);
            list.Add(item);
            var convertedJson = JsonConvert.SerializeObject(list, Formatting.Indented);
            File.WriteAllText(path, convertedJson);
        }

        public void Save2(Item item)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.All),
                WriteIndented = true
            };
            string path = @"C:\Users\aisti\OneDrive\Desktop\C# Advanced\reservationtable\Saskaitos generavimas\drinks.json";
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
            string path = @"C:\Users\aisti\OneDrive\Desktop\C# Advanced\reservationtable\Saskaitos generavimas\food.json";
            string path2 = @"C:\Users\aisti\OneDrive\Desktop\C# Advanced\reservationtable\Saskaitos generavimas\drinks.json";
            var jsonString = File.ReadAllText(path);
            var jsonString2 = File.ReadAllText(path2);
            var list = JsonConvert.DeserializeObject<List<Item>>(jsonString);
            var list2 = JsonConvert.DeserializeObject<List<Item>>(jsonString2);
            var item= list.FirstOrDefault(x => x.Id == itemId);
            var item2 = list2.FirstOrDefault(x => x.Id == itemId);

            if (item != null)
            {
                var itemDescription = item.Description;
                return itemDescription;
            }
            else if (item2 != null)
            {
                var itemDescription = item2.Description;
                return itemDescription;
            }

            return null;
            
        }
        public double Load2(int itemId)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.All),
                WriteIndented = true
            };
            string path = @"C:\Users\aisti\OneDrive\Desktop\C# Advanced\reservationtable\Saskaitos generavimas\drinks.json";
            string path2 = @"C:\Users\aisti\OneDrive\Desktop\C# Advanced\reservationtable\Saskaitos generavimas\food.json";
            var jsonString = File.ReadAllText(path);
            var jsonString2 = File.ReadAllText(path2);
            var list = JsonConvert.DeserializeObject<List<Item>>(jsonString);
            var list2 = JsonConvert.DeserializeObject<List<Item>>(jsonString2);
            list.AddRange(list2);
            var item = list.FirstOrDefault(x => x.Id == itemId);
            var itemPrice = item.Price;

            return itemPrice;

        }

        public int LoadIdGeneratorChekerDrinks()
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.All),
                WriteIndented = true
            };
            string path = @"C:\Users\aisti\OneDrive\Desktop\C# Advanced\reservationtable\Saskaitos generavimas\drinks.json";
            var jsonString = File.ReadAllText(path);
            var list = JsonConvert.DeserializeObject<List<Customer>>(jsonString);
            var item = list.Last().Id;
            var idNumber = item + 1;

            return idNumber;

        }

        public int LoadIdGeneratorChekerFood()
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.All),
                WriteIndented = true
            };
            string path = @"C:\Users\aisti\OneDrive\Desktop\C# Advanced\reservationtable\Saskaitos generavimas\food.json";
            var jsonString = File.ReadAllText(path);
            var list = JsonConvert.DeserializeObject<List<Customer>>(jsonString);
            var item = list.Last().Id;
            var idNumber = item + 1;

            return idNumber;

        }
        public Item RetrieveById(int id)
        {
            return Items.SingleOrDefault(x => x.Id == id);
        }

    }
}

