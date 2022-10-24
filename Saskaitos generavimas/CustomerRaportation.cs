using Saskaitos_generavimas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Saskaitos_generavimas
{
    public class CustomerRaportation
    {
        public void CustomerRaport()
        {
            List<Customer> Invoices = new List<Customer>();
            using (StreamReader r = new StreamReader(@"C:\Users\aisti\OneDrive\Desktop\C#\Strukturos 2022-09-26\Saskaitos generavimas\Saskaitos generavimas\Saskaitos generavimas\Customers.json"))
            {
                string json = r.ReadToEnd();
                var incoming6 = JsonSerializer.Deserialize<List<Customer>>(json);
                foreach (var items in incoming6)
                {
                    Console.WriteLine($"{items.Id}, Customer {items.Client}, Address {items.Address}, Payment Terms {items.PaymentTerms}, Customer created {items.DateTime}");
                }
            }
        }
    }
}
