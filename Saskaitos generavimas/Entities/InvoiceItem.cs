using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saskaitos_generavimas.Entities
{
    public class InvoiceItem
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime DateTime { get; set; }
        public string CustomerId { get; set; }
        public string Client { get; set; }
        public int PaymentOption { get; set; }
        public string Description { get; set; }
        public int Quantyti { get; set; }
        public double Price { get; set; }
        public double TotalAmmountPrice { get; set; }
        public int QuantytiTotal { get; set; }

        public InvoiceItem(int id, string orderNumber, DateTime dateTime, string customerId, string client, int paymentOption, string description, int quantyti, double price, double totalAmmountPrice, int quantytiTotal)
        {
            Id = id;
            OrderNumber = orderNumber;
            DateTime = dateTime;
            CustomerId = customerId;
            Client = client;
            PaymentOption = paymentOption;
            Description = description;
            Quantyti = quantyti;
            Price = price;
            TotalAmmountPrice = totalAmmountPrice;
            QuantytiTotal = quantytiTotal;
        }

        public InvoiceItem()
        {
        }
    }
}
