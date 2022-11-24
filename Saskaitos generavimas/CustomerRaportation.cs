using RestaurantReservationSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace RestaurantReservationSystem
{
    public class CustomerRaportation
    {
        public void CustomerRaport()
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.All),
                WriteIndented = true
            };
            string path = @"C:\Users\aisti\OneDrive\Desktop\C# Advanced\reservationtable\Saskaitos generavimas\Customers.json";
            var jsonString = File.ReadAllText(path);
            var list = JsonConvert.DeserializeObject<List<Customer>>(jsonString);
            foreach (var items in list)
            {
                Console.WriteLine($" ID number {items.Id}, Table Number {items.Client}, Table size {items.TableSeats}, Table reserved {items.DateTime}, 0=free; 1=booked Table status = {items.TableStatus}");
            }
            
        }
   
    }
}
