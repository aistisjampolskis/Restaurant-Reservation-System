using Saskaitos_generavimas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Saskaitos_generavimas
{
    public class ItemRaportation
    {
        public void ItemRaport()
        {
            List<Item> Items = new List<Item>();
            using (StreamReader r = new StreamReader(@"C:\Users\aisti\OneDrive\Desktop\C#\Strukturos 2022-09-26\Saskaitos generavimas\Saskaitos generavimas\Saskaitos generavimas\Items.json"))
            {
                string json = r.ReadToEnd();
                var incoming5 = JsonSerializer.Deserialize<List<Item>>(json);
                foreach (var items in incoming5)
                {
                    Console.WriteLine($"{items.Description}, ${items.Price}, Item Id {items.Id}");
                }
            }
        }
    }
}
