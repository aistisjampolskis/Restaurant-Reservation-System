using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using RestaurantReservationSystem.Repositories;

namespace RestaurantReservationSystem
{
    public class GetFullInvoisingById
    {
        public int GetFullINvoiceById()
        {
            Console.WriteLine("Enter table ID");
            int invoiceId = Convert.ToInt32(Console.ReadLine());
            using (StreamReader r = new StreamReader(@"C:\Users\aisti\OneDrive\Desktop\C# Advanced\reservationtable\Saskaitos generavimas\Invoice.json"))
            {
                string json = r.ReadToEnd();
                var incoming33 = JsonSerializer.Deserialize<List<ItemOnInvoice>>(json);
                foreach (var items in incoming33)
                {
                    if (items.Id == invoiceId)
                    {
                        Console.WriteLine($"Table {items.Client}, Order number {items.OrderNumber}, Date {items.DateTime}, Table Size {items.PaymentOption}, Invoice total {items.InvoiceTotal} Euro ");
                        foreach (var itemms in items.Itemss)
                        {
                            var rowTotalr = (float)Math.Round(itemms.RowTotal * 100f) / 100f;

                            Console.WriteLine($"Item {itemms.Description}, Quatyti {itemms.Quantyti}, Price {itemms.Price} Euro Total row {rowTotalr} Euro");
                        }
                        var InvoiceTotalr = (float)Math.Round(items.InvoiceTotal * 100f) / 100f;
                        Console.WriteLine($"Invoice total {InvoiceTotalr} Euro");
                        Console.WriteLine($"Item qty {items.QtyTotal} pcs");
                       
                    }
                }
                
                return invoiceId;
            }
        }
    }
}
