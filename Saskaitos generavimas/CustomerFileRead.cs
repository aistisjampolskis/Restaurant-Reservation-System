using Newtonsoft.Json;
using RestaurantReservationSystem.Entities;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace RestaurantReservationSystem
{
    public class CustomerFileRead
    {
        public void CustumerFileReader()
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.All),
                WriteIndented = true
            };
            string path = @"C:\Users\aisti\OneDrive\Desktop\C# Advanced\reservationtable\Saskaitos generavimas\Customers.json";
            var jsonString = File.ReadAllText(path);
            var list = JsonConvert.DeserializeObject<List<Customer>>(jsonString);
            foreach (var item in list)
            {
                if (item.TableStatus < 1)
                    Console.WriteLine($"Table Number {item.Client}, Table ID {item.Id}");
            }
        }
    }
}
