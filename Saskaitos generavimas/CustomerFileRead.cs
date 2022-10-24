using Saskaitos_generavimas.Entities;
using System.Text;
using System.Text.Json;

namespace Saskaitos_generavimas
{
    public class CustomerFileRead
    {
        public void CustomerFileReader()
        {
            var incoming = new List<Customer>();
            using (StreamReader r = new StreamReader(@"C:\Users\aisti\OneDrive\Desktop\C#\Strukturos 2022-09-26\Saskaitos generavimas\Saskaitos generavimas\Saskaitos generavimas\Customers.json"))
            {
                string json = r.ReadToEnd();
                incoming = JsonSerializer.Deserialize<List<Customer>>(json);
            }
            if (incoming != null && incoming.Count > 0)
            {
                foreach (var customer in incoming)
                {
                    Console.WriteLine($"{customer.Client}, #{customer.Id}");
                }
            }
        }
    }
}
