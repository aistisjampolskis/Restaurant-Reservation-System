using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace RestaurantReservationSystem
{
    public class InvoicingRaportation
    {
        public void InvoiceRaport()
        {
            using (StreamReader r = new StreamReader(@"C:\Users\aisti\OneDrive\Desktop\C# Advanced\reservationtable\Saskaitos generavimas\Invoice.json"))
            {
                string json = r.ReadToEnd();
                var incoming33 = JsonSerializer.Deserialize<List<ItemOnInvoice>>(json);
                foreach (var items in incoming33)
                {
                    Console.WriteLine($"Table number {items.Client}, Order Number {items.OrderNumber}, Date {items.DateTime}, Table Size {items.PaymentOption} Seats, Invoice Total {items.InvoiceTotal} Euro");
                }
            }
        }
    }
}
