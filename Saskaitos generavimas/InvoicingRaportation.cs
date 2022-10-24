using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Saskaitos_generavimas
{
    public class InvoicingRaportation
    {
        public void InvoiceRaport()
        {
            using (StreamReader r = new StreamReader(@"C:\Users\aisti\OneDrive\Desktop\C#\Strukturos 2022-09-26\Saskaitos generavimas\Saskaitos generavimas\Saskaitos generavimas\Invoice.json"))
            {
                string json = r.ReadToEnd();
                var incoming33 = JsonSerializer.Deserialize<List<ItemOnInvoice>>(json);
                foreach (var items in incoming33)
                {
                    Console.WriteLine($"Customer {items.Client}, Order Number {items.OrderNumber}, Date {items.DateTime}, Payment Terms {items.PaymentOption}, Invoice Total {items.InvoiceTotal}");
                }
            }
        }
    }
}
