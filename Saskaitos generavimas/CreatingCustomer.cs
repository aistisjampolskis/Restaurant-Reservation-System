using Saskaitos_generavimas.Entities;
using Saskaitos_generavimas.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace Saskaitos_generavimas
{
    public class CreatingCustomer
    {
        CustomerRepository customerRepository = new CustomerRepository();
        public void CreateCustomer2()
        {
            List<Customer> Invoices = new List<Customer>();
            DateTime date1 = DateTime.Now;
            Console.Clear();
            Console.WriteLine("Enter customer Id");
            int id = Convert.ToInt32(Console.ReadLine());
            while (true)
            {
                if (id < 0)
                {
                    Console.WriteLine("Enter right Customer Id");
                    id = Convert.ToInt32(Console.ReadLine());
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine("Enter address");
            string address = Console.ReadLine();

            Console.WriteLine("Enter Payment terms");
            int paymentTerms = Convert.ToInt32(Console.ReadLine());
            while (true)
            {
                if (paymentTerms < 0)
                {
                    Console.WriteLine("Enter right payment term");
                    paymentTerms = Convert.ToInt32(Console.ReadLine());
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine("Enter customer name");
            string client = Console.ReadLine();
            Console.WriteLine("Enter creation date");
            string dateTime = Console.ReadLine();

            customerRepository.Save(new Customer(id, address, dateTime, paymentTerms, client));
            /* var options = new JsonSerializerOptions
             {
                 Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.All),
                 WriteIndented = true
             };
             var jsonString = JsonSerializer.Serialize(customerRepository.RetrieveList(), options);
             File.WriteAllText(@"C:\Users\aisti\OneDrive\Desktop\C#\Strukturos 2022-09-26\Saskaitos generavimas\Saskaitos generavimas\Saskaitos generavimas\Customers.json", jsonString);
             Console.WriteLine("Customer.json file created");
         }*/
        }
    }
}
