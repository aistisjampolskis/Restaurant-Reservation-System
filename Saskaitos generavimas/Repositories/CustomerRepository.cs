using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Saskaitos_generavimas.Entities;


namespace Saskaitos_generavimas.Repositories
{
    public class CustomerRepository
    {
        
        private List<Customer> Invoices { get; set; } = new List<Customer>();
        public CustomerRepository()
        {
            Invoices.Add(new Customer(1, "Balbieriškis", "2022-01-19", 30, "Šilas"));
            Invoices.Add(new Customer(2, "Kaunas", "2021-10-19", 45, "Maxima"));
            Invoices.Add(new Customer(3, "Jonava", "2022-12-19", 60, "Iki"));
            Invoices.Add(new Customer(4, "Klaipeda", "2021-09-19", 90, "Depo"));
            Invoices.Add(new Customer(5, "Panevezys", "2019-10-19", 30, "Senukai"));
            Invoices.Add(new Customer(6, "Zatyšiai", "2001-10-19", 30, "Rimi"));
            Invoices.Add(new Customer(7, "Alytus", "2002-10-19", 120, "Kesko"));
            Invoices.Add(new Customer(8, "Vilnius", "2008-10-19", 90, "Sanitex"));
            Invoices.Add(new Customer(13, "Vilnius", "2008-10-19", 90, "Procter"));

            


        }
        public List<Customer> RetrieveList()
        {
            return Invoices;
        }

        public Customer RetrieveById(int id)
        {
            return Invoices.SingleOrDefault(x => x.Id == id);
        }

        public void Save(Customer customer)
        {
           // Invoices.Add(customer);
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.All),
                WriteIndented = true
            };
            string path = @"C:\Users\aisti\OneDrive\Desktop\C#\Strukturos 2022-09-26\Saskaitos generavimas\Saskaitos generavimas\Saskaitos generavimas\Customers.json";
            var jsonString = File.ReadAllText(path);
            var list = JsonConvert.DeserializeObject<List<Customer>>(jsonString);
            list.Add(customer);
            var convertedJson = JsonConvert.SerializeObject(list, Formatting.Indented);
            File.WriteAllText(path, convertedJson);
        }

       
    }
}
