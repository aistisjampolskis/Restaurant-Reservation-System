using RestaurantReservationSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace RestaurantReservationSystem
{
    public class ItemRaportation
    {
        public void ItemRaport()
        {
            List<Item> Items = new List<Item>();
            using (StreamReader r = new StreamReader(@"C:\Users\aisti\OneDrive\Desktop\C# Advanced\reservationtable\Saskaitos generavimas\food.json"))
            using (StreamReader r2 = new StreamReader(@"C:\Users\aisti\OneDrive\Desktop\C# Advanced\reservationtable\Saskaitos generavimas\drinks.json"))
            {
                string json = r.ReadToEnd();
                var incoming5 = JsonSerializer.Deserialize<List<Item>>(json);
                foreach (var items in incoming5)
                {
                    Console.WriteLine($"{items.Description}, ${items.Price}, Item Id {items.Id}");
                }
                string json2 = r2.ReadToEnd();
                var incoming55 = JsonSerializer.Deserialize<List<Item>>(json2);
                foreach (var items in incoming55)
                {
                    Console.WriteLine($"{items.Description}, ${items.Price}, Item Id {items.Id}");
                }
            }
        }
    }
}
