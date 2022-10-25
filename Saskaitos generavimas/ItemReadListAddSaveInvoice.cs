using Saskaitos_generavimas.Entities;
using Saskaitos_generavimas.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using Saskaitos_generavimas;

namespace Saskaitos_generavimas
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
            int advance = 0;
            var incoming = new List<Customer>();
            var incoming2 = new List<Item>();
            DateTime date1 = DateTime.Now;
            Console.WriteLine("Generated Invoice ID" + $" {numb}");
            string version = orderPrefix + " " + numb;
            Console.WriteLine($"Generated Order NUmber {version}");
            date1 = DateTime.Now;
            Console.WriteLine($"Generated Invoice date {date1}");
            Console.WriteLine("Choose: \n [1] Payment in advance\n [2] Cash Payment\n [3] 30 days after the invoice.\n [4] 45 days after the invoice \n [5] I will input custom delay: ");
            int action2 = int.Parse(Console.ReadLine());
            switch (action2)
            {
                case 1:
                    advance = 0;
                    break;
                case 2:
                    advance = 0;
                    break;
                case 3:
                    advance = 30;
                    break;
                case 4:
                    advance = 45;
                    break;
                case 5:
                    advance = Convert.ToInt32(Console.ReadLine());
                    break;
                default:
                    Console.WriteLine("Such option does not exist");
                    break;
            }
            Console.WriteLine("Choose customer from the list");
            customerFileRead.CustomerFileReader();
            int yes = customerFileReadValidation.CustomerFileReadValidationing();
            List<ListOfItem> Itemss = new List<ListOfItem>();
            using (StreamReader r = new StreamReader(@"C:\Users\aisti\OneDrive\Desktop\C#\Strukturos 2022-09-26\Saskaitos generavimas\Saskaitos generavimas\Saskaitos generavimas\Items.json"))
            {
                string json = r.ReadToEnd();
                incoming2 = JsonSerializer.Deserialize<List<Item>>(json);
            }
            if (incoming2 != null && incoming2.Count > 0)
            {
                bool isFinishedPurchase = false;
                while (!isFinishedPurchase)
                {
                    Console.WriteLine("Add Item [1]\nSave Invoice[2]\n");
                    foreach (var items in incoming2)
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
                           RowTotal = qty * itemsRepository.Load2(itemId),
                        });
                    }
                    if (action3 == 2)
                    {
                        isFinishedPurchase = true;
                    }
                }
            }
            double invoiceTotal = Itemss.Sum(x => x.RowTotal);
            int qtyTotal = Itemss.Sum(x => x.Quantyti);
            itemsOnInvoiceRepository.Save(new ItemOnInvoice(numb, version, date1.ToString("G"), advance,customerRepository.RetrieveById(yes).Client, Itemss, invoiceTotal, qtyTotal));
           
        }
    }
}
