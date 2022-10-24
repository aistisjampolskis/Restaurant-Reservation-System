using Saskaitos_generavimas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text;
using System.Text.Json;

namespace Saskaitos_generavimas
{
    public class CustomerFileReadValidation
    {
        public int CustomerFileReadValidationing()
        {
            int customerId = Convert.ToInt32(Console.ReadLine());
            using (StreamReader r = new StreamReader(@"C:\Users\aisti\OneDrive\Desktop\C#\Strukturos 2022-09-26\Saskaitos generavimas\Saskaitos generavimas\Saskaitos generavimas\Customers.json"))
            {
                string json = r.ReadToEnd();
                var incoming0 = JsonSerializer.Deserialize<List<Customer>>(json);
                if (incoming0 != null && incoming0.Count > 0)
                {
                    bool exist = true;
                    int yes = 0;
                    string customerName = "";
                    while (exist)
                    {
                        foreach (var customer in incoming0)
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
               
            }
            return customerId;
        }
    }
}
