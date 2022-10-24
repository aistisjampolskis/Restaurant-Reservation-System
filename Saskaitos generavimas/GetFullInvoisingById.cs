using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Saskaitos_generavimas
{
    public class GetFullInvoisingById
    {
        public void GetFullINvoiceById()
        {
            Console.WriteLine("Enter invoice Id");
            int invoiceId = Convert.ToInt32(Console.ReadLine());
            using (StreamReader r = new StreamReader(@"C:\Users\aisti\OneDrive\Desktop\C#\Strukturos 2022-09-26\Saskaitos generavimas\Saskaitos generavimas\Saskaitos generavimas\Invoice.json"))
            {
                string json = r.ReadToEnd();
                var incoming33 = JsonSerializer.Deserialize<List<ItemOnInvoice>>(json);
                foreach (var items in incoming33)
                {
                    if (items.Id == invoiceId)
                    {
                        Console.WriteLine($"Customer {items.Client}, Order number {items.OrderNumber}, Date {items.DateTime}, Payment terms {items.PaymentOption}, Invoice total {items.InvoiceTotal}");
                        foreach (var itemms in items.Itemss)
                        {
                            var rowTotalr = (float)Math.Round(itemms.RowTotal * 100f) / 100f;

                            Console.WriteLine($"Item {itemms.Description}, Quatyti {itemms.Quantyti}, Price {itemms.Price} Total row {rowTotalr}");
                        }
                        var InvoiceTotalr = (float)Math.Round(items.InvoiceTotal * 100f) / 100f;
                        Console.WriteLine($"Invoice total {InvoiceTotalr}");
                        Console.WriteLine($"Item qty {items.QtyTotal}");
                    }
                }
            }
        }
    }
}
