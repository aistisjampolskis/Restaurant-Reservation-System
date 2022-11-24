using RestaurantReservationSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace RestaurantReservationSystem
{
    public class CustomerFileReadValidation
    {
        public int CustomerFileReadValidationing()
        {
            int customerId = Convert.ToInt32(Console.ReadLine());

            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.All),
                WriteIndented = true
            };
            string path = @"C:\Users\aisti\OneDrive\Desktop\C# Advanced\reservationtable\Saskaitos generavimas\Customers.json";
            var jsonString = File.ReadAllText(path);
            var list = JsonConvert.DeserializeObject<List<Customer>>(jsonString);

            if (list != null && list.Count > 0)
            {
                bool exist = true;
                int yes = 0;
                string customerName = "";
                while (exist)
                {
                    foreach (var customer in list)
                    {
                        if (customer.Id == customerId)
                        {
                            yes = customer.Id;
                            customerName = customer.Client;
                            break;
                        }
                        {
                            yes = 0;
                        }
                    }
                    if (yes == customerId)
                    {
                        Console.WriteLine($"Choosen Customer {customerName}");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Try again");
                        customerId = Convert.ToInt32(Console.ReadLine());
                    }
                }
            }
            return customerId;
        }
        public int TableStatus()
        {
            int customerId = Convert.ToInt32(Console.ReadLine());
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.All),
                WriteIndented = true
            };
            string path = @"C:\Users\aisti\OneDrive\Desktop\C# Advanced\reservationtable\Saskaitos generavimas\Customers.json";
            var jsonString = File.ReadAllText(path);
            var list = JsonConvert.DeserializeObject<List<Customer>>(jsonString);
            {
                    bool exist = true;
                    int yes = 0;
                    string customerName = "";
                    while (exist)
                    {
                        foreach (var customer in list)
                        {
                            if (customer.Id == customerId)
                            {
                                yes = customer.Id;
                                customerName = customer.Client;
                                yes = customer.TableStatus + 1;
                                customerId = yes;
                                break;
                            }
                            {
                                yes = 0;
                            }
                        }
                        if (yes == customerId)
                        {
                            Console.WriteLine($"Choosen Customer {customerName}");


                            break;
                        }
                        else
                        {
                            Console.WriteLine("Try again");
                            customerId = Convert.ToInt32(Console.ReadLine());
                        }
                    }
            }
            return customerId;
        }
    }
}

    


