using RestaurantReservationSystem.Entities;
using RestaurantReservationSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using RestaurantReservationSystem;

namespace RestaurantReservationSystem
{
    public class ItemReadListAddSaveInvoice
    {
        ItemsRepository itemsRepository = new ItemsRepository();
        CustomerRepository customerRepository = new CustomerRepository();
        RandomNumberGenerator randomNumberGenerator = new RandomNumberGenerator();
        ItemsOnInvoiceRepository itemsOnInvoiceRepository = new ItemsOnInvoiceRepository();
        CustomerFileRead customerFileRead = new CustomerFileRead();
        CustomerFileReadValidation customerFileReadValidation = new CustomerFileReadValidation();
        public void ItemReadListAddSaveInvoice2()
        {
            int numb;
            numb = randomNumberGenerator.NumberGenerator();
            string orderPrefix = "Kl";
            var incoming = new List<Customer>();
            var incoming2 = new List<Item>();
            var incoming22 = new List<Item>();
            DateTime date1 = DateTime.Now;
            Console.WriteLine("Generated Order ID" + $" {numb}");
            string version = orderPrefix + " " + numb;
            Console.WriteLine($"Generated Order Number {version}");
            date1 = DateTime.Now;
            Console.WriteLine($"Generated order date {date1}");
            Console.WriteLine("Choose table from the list");
            customerFileRead.CustumerFileReader();
            int yes = customerFileReadValidation.CustomerFileReadValidationing();
            List<ListOfItem> Itemss = new List<ListOfItem>();
            using (StreamReader r = new StreamReader(@"C:\Users\aisti\OneDrive\Desktop\C# Advanced\reservationtable\Saskaitos generavimas\food.json"))
            using (StreamReader r2 = new StreamReader(@"C:\Users\aisti\OneDrive\Desktop\C# Advanced\reservationtable\Saskaitos generavimas\drinks.json"))
            {
                string json = r.ReadToEnd();
                string json2 = r2.ReadToEnd();
                incoming2 = JsonSerializer.Deserialize<List<Item>>(json);
                incoming22 = JsonSerializer.Deserialize<List<Item>>(json2);
            }
            if (incoming2 != null && incoming2.Count > 0 && incoming22 != null && incoming22.Count > 0)
            {
                bool isFinishedPurchase = false;
                while (!isFinishedPurchase)
                {
                    Console.WriteLine("Add Item [1]\nSave Table Order[2]\n");
                    foreach (var items in incoming2)
                    {
                        Console.WriteLine($"{items.Description}, ${items.Price}, Item Id {items.Id}");
                    }
                    foreach (var items in incoming22)
                    {
                        Console.WriteLine($"{items.Description}, ${items.Price}, Item Id {items.Id}");
                    }
                    int action3 = int.Parse(Console.ReadLine());
                    if (action3 == 1)
                    {
                        int itemId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"Choosen Item {itemId}");
                        Console.WriteLine($"Enter pcs: ");
                        int qty = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"Purchase qty {qty}");
                        Itemss.Add(new ListOfItem()
                        {
                            Description = itemsRepository.Load(itemId),
                            Quantyti = qty,
                            Price = itemsRepository.Load2(itemId),
                            RowTotal = Math.Round(qty * itemsRepository.Load2(itemId), 2),
                        });
                    }
                    if (action3 == 2)
                    {
                        isFinishedPurchase = true;
                    }
                }
            }
            double invoiceTotal = Math.Round(Itemss.Sum(x => x.RowTotal), 2);
            int qtyTotal = Itemss.Sum(x => x.Quantyti);
            if (qtyTotal == 0)
                Console.WriteLine("Order can't be empty");
            else
            itemsOnInvoiceRepository.Save(new ItemOnInvoice(yes, version, date1.ToString("G"), customerRepository.Load5(yes),yes.ToString(), Itemss, invoiceTotal, qtyTotal));
            customerRepository.WriteToFile(customerRepository.ChangeTableStatus(customerRepository.ReadFromFileCustomers(), yes));
        }
    }
}
