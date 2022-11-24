using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestaurantReservationSystem.Entities;


namespace RestaurantReservationSystem.Repositories
{
    public class CustomerRepository
    {

        private List<Customer> Invoices { get; set; } = new List<Customer>();
        public CustomerRepository()
        {
            
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

            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.All),
                WriteIndented = true
            };
            string path = @"C:\Users\aisti\OneDrive\Desktop\C# Advanced\reservationtable\Saskaitos generavimas\Customers.json";
            var jsonString = File.ReadAllText(path);
            var list = JsonConvert.DeserializeObject<List<Customer>>(jsonString);
            string client = customer.Client;
            var cheking = list.Where(x => x.Client == customer.Client);
            
            if (cheking.Any())
                    Console.WriteLine("Table already exist");
               else
                    list.Add(customer);
                    var convertedJson = JsonConvert.SerializeObject(list, Formatting.Indented);
                    File.WriteAllText(path, convertedJson);
        }
        public string ReadFromFileCustomers()
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.All),
                WriteIndented = true
            };
            string path = @"C:\Users\aisti\OneDrive\Desktop\C# Advanced\reservationtable\Saskaitos generavimas\Customers.json";
            var jsonString = File.ReadAllText(path);
            return jsonString;

        }
        public List<Customer> ChangeTableStatus(string jsonString, int yes)
        {
            var list = JsonConvert.DeserializeObject<List<Customer>>(jsonString);
            list.Where(x => x.Id == yes).ToList().ForEach(x => x.TableStatus = 1);

            return list;
        }

        public void WriteToFile(List<Customer> list)
        {
            string path = @"C:\Users\aisti\OneDrive\Desktop\C# Advanced\reservationtable\Saskaitos generavimas\Customers.json";

            var convertedJson = JsonConvert.SerializeObject(list, Formatting.Indented);
            File.WriteAllText(path, convertedJson);
        }
        public void WriteToFileTestEmptyFile(Customer customer)
        {
            string path = @"C:\Users\aisti\OneDrive\Desktop\C# Advanced\reservationtable\Saskaitos generavimas\CustomersTest.json";

            var convertedJson = JsonConvert.SerializeObject(customer, Formatting.Indented);
            File.WriteAllText(path, convertedJson);
        }

        public string ReadFromFileCustomersTesting()
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.All),
                WriteIndented = true
            };
            string path = @"C:\Users\aisti\OneDrive\Desktop\C# Advanced\reservationtable\Saskaitos generavimas\CustomersTest.json";
            var jsonString = File.ReadAllText(path);
            return jsonString;

        }
        public List<Customer >UpdateTableStatus (string jsonString, int yes)
        {
        
            var list = JsonConvert.DeserializeObject<List<Customer>>(jsonString);
            list.Where(x => x.Id == yes).ToList().ForEach(x => x.TableStatus = 1);
            return list;
        }

        public List<Customer> UpdateTableStatusAfterPayment(string jsonString, int passing)
        {
           var list = JsonConvert.DeserializeObject<List<Customer>>(jsonString);
            list.Where(x => x.Id == passing).ToList().ForEach(x => x.TableStatus = 0);
            return list;
           
        }
        public int Load5(int Id)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.All),
                WriteIndented = true
            };
            string path = @"C:\Users\aisti\OneDrive\Desktop\C# Advanced\reservationtable\Saskaitos generavimas\Customers.json";
            var jsonString = File.ReadAllText(path);
            var list = JsonConvert.DeserializeObject<List<Customer>>(jsonString);
            var item = list.FirstOrDefault(x => x.Id == Id);
            var itemSeatingNumber = item.TableSeats;
            return itemSeatingNumber;
        }
        public int Load6()
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.All),
                WriteIndented = true
            };
            string path = @"C:\Users\aisti\OneDrive\Desktop\C# Advanced\reservationtable\Saskaitos generavimas\Customers.json";
            var jsonString = File.ReadAllText(path);
            var list = JsonConvert.DeserializeObject<List<Customer>>(jsonString);
            var item = list.Last().Id;
            var idNumber = item + 1;

            return idNumber;

        }
    }
}
