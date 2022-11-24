using RestaurantReservationSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Aspose.Cells;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using RestaurantReservationSystem.Entities;

namespace RestaurantReservationSystem
{
    public class InvoiceWithoutItems
    {
       CustomerRepository customerRepository = new CustomerRepository();
        public string GetReceipt(int invoiceId)
        {
            using (StreamReader r = new StreamReader(@"C:\Users\aisti\OneDrive\Desktop\C# Advanced\reservationtable\Saskaitos generavimas\Invoice.json"))
            {
                string json = r.ReadToEnd();
                var incoming33 = JsonSerializer.Deserialize<List<ItemOnInvoice>>(json);
                foreach (var items in incoming33)
                {
                    if (items.Id == invoiceId)
                    {
                        Console.WriteLine("RECEIPT FOR RESTAURANT");
                        Console.WriteLine($"Table {items.Client}, Order number {items.OrderNumber}, Date {items.DateTime} ");
                        var InvoiceTotalr = (float)Math.Round(items.InvoiceTotal * 100f) / 100f;
                        Console.WriteLine($"Invoice total {InvoiceTotalr} Euro");
                    }
                }
                var again = incoming33.Where(x => x.Id == invoiceId).ToList();
                if (again.Count != 0)
                {
                    customerRepository.WriteToFile(customerRepository.UpdateTableStatusAfterPayment(customerRepository.ReadFromFileCustomers(),invoiceId));
                    string fileName = (@"C:\\Users\\aisti\\OneDrive\\Desktop\\C# Advanced\\reservationtable\\Saskaitos generavimas\\Receipt.json");
                    string jsonString = JsonSerializer.Serialize(again);
                    File.WriteAllText(fileName, jsonString);
                    Console.WriteLine(File.ReadAllText(fileName));
                    return fileName;
                }
                else
                {
                    Console.WriteLine("Table ordered nothing");
                    return null;
                }
            }
        }
        public string GetHtmlRestaurant(string fileName)
        {
            var jsonString = File.ReadAllText(fileName);
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.All),
                WriteIndented = true
            };
            var list = JsonSerializer.Deserialize<List <ItemOnInvoice>>(jsonString);
            foreach (var items in list)
            {   
                Console.WriteLine($" ID number {items.Id}, Table Number {items.Client}, Table size {items.PaymentOption}, Table reserved {items.DateTime}, 0=free; 1=booked Table status = {items.PaymentOption}, Total Receipt {items.InvoiceTotal} Euro");
                    foreach (var itemms in items.Itemss) 
                     {
                    Console.WriteLine($" Item {itemms.Description}, QTY {itemms.Quantyti}, Price {itemms.Price}, Total row {itemms.RowTotal} Euro ");

                     }
            }
            
            string html = "<table cellpadding='5' cellspacing='0' style='border: 1px solid #ccc; font-size: 9pt;font-family' >";
            html += "<center>";
            html += "<h3>Receipt for Restaurant</h3>";
            html += "</center>";
            html += "<tr>";
            html += "<th style='background-color: #FF6933;border: 1px solid #ccc'>Id </th>";
            html += "<th style='background-color: #FF6933;border: 1px solid #ccc'>Date</th>";
            html += "<th style='background-color: #FF6933;border: 1px solid #ccc'>Table Number</th>";
            html += "<th style='background-color: #FF6933;border: 1px solid #ccc'>Table Size</th>";
            html += "<th style='background-color: #FF6933;border: 1px solid #ccc'>Order Number</th>";
            html += "<th style='background-color: #FF6933;border: 1px solid #ccc'>Payment for receipt in Euro</th>";
            html += "</tr>";
            foreach (var item in list)
            {
                html += "<tr>";
                html += "<td style='width:120px;border: 1px solid #ccc'>" + item.Id  + "</td>";
                html += "<td style='width:120px;border: 1px solid #ccc'>" + item.DateTime + "</td>";
                html += "<td style='width:120px;border: 1px solid #ccc'>" + item.Client + "</td>";
                html += "<td style='width:120px;border: 1px solid #ccc'>" + item.PaymentOption + "</td>";
                html += "<td style='width:120px;border: 1px solid #ccc'>" + item.OrderNumber + "</td>";
                html += "<td style='width:120px;border: 1px solid #ccc'>" + item.InvoiceTotal + "</td>";
                html += "</tr>";
            }
            html += "</table>";

            File.WriteAllText(@"C:\Users\aisti\OneDrive\Desktop\C# Advanced\reservationtable\Saskaitos generavimas\RestaurantReceipt.html", html);
            Console.WriteLine("Html file created.");
            var path = (@"C:\Users\aisti\OneDrive\Desktop\C# Advanced\reservationtable\Saskaitos generavimas\RestaurantReceipt.html");
            return path;
        }
        public string GetHtmlCutomer(string fileName)
        {
            var jsonString = File.ReadAllText(fileName);
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.All),
                WriteIndented = true
            };
            var list = JsonSerializer.Deserialize<List<ItemOnInvoice>>(jsonString);
            foreach (var items in list)
            {
                Console.WriteLine($" ID number {items.Id}, Table Number {items.Client}, Table size {items.PaymentOption}, Table reserved {items.DateTime}, 0=free; 1=booked Table status = {items.PaymentOption}, Total Receipt {items.InvoiceTotal} Euro");
                foreach (var itemms in items.Itemss)
                {
                    Console.WriteLine($" Item {itemms.Description}, QTY {itemms.Quantyti}, Price {itemms.Price}, Total row {itemms.RowTotal} Euro ");
                }
            }
            string html = "<table cellpadding='5' cellspacing='0' style='border: 1px solid #ccc; font-size: 9pt;font-family' >";
            html += "<h3>Receipt for customer</h3>";
            html += "</center>";
            html += "<table cellpadding='5' cellspacing='0' style='border: 1px solid #ccc; font-size: 9pt;font-family' >";
            html += "<tr>";
            html += "<th style='background-color: #FF6933;border: 1px solid #ccc'>Id </th>";
            html += "<th style='background-color: #FF6933;border: 1px solid #ccc'>Date</th>";
            html += "<th style='background-color: #FF6933;border: 1px solid #ccc'>Table Number</th>";
            html += "<th style='background-color: #FF6933;border: 1px solid #ccc'>Table Size</th>";
            html += "<th style='background-color: #FF6933;border: 1px solid #ccc'>Receipt Total Euro</th>";
            html += "</tr>";
            foreach (var item in list)
            {
                html += "<tr>";
                html += "<td style='width:120px;border: 1px solid #ccc'>" + item.Id + "</td>";
                html += "<td style='width:120px;border: 1px solid #ccc'>" + item.DateTime + "</td>";
                html += "<td style='width:120px;border: 1px solid #ccc'>" + item.Client + "</td>";
                html += "<td style='width:120px;border: 1px solid #ccc'>" + item.PaymentOption + "</td>";
                html += "<td style='width:120px;border: 1px solid #ccc'>" + item.InvoiceTotal + "</td>";
                html += "</tr>";
                html += "<th style='background-color: #FF6933;border: 1px solid #ccc'>Item Description</th>";
                html += "<th style='background-color: #FF6933;border: 1px solid #ccc'>Price</th>";
                html += "<th style='background-color: #FF6933;border: 1px solid #ccc'>Qty</th>";
                html += "<th style='background-color: #FF6933;border: 1px solid #ccc'>Row total Euro</th>";
                html += "<tr>";
                foreach (var items in item.Itemss)
                {
                    html += "<tr>";
                    html += "<td style='width:120px;border: 1px solid #ccc'>" + items.Description + "</td>";
                    html += "<td style='width:120px;border: 1px solid #ccc'>" + items.Price + "</td>";
                    html += "<td style='width:120px;border: 1px solid #ccc'>" + items.Quantyti + "</td>";
                    html += "<td style='width:120px;border: 1px solid #ccc'>" + items.RowTotal + "</td>";
                    html += "</tr>";
                }
                html += "</tr>";
            }
            html += "</table>";
            File.WriteAllText(@"C:\Users\aisti\OneDrive\Desktop\C# Advanced\reservationtable\Saskaitos generavimas\ReceiptCustomer.html", html);
            Console.WriteLine("Html file created.");
            var path = (@"C:\Users\aisti\OneDrive\Desktop\C# Advanced\reservationtable\Saskaitos generavimas\ReceiptCustomer.html");
            return path;
        }
    }
}
