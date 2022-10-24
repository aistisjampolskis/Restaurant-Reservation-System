using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saskaitos_generavimas.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string DateTime { get; set; }
        public int PaymentTerms { get; set; }
        public string Client { get; set; }

        public Customer  (int id, string address, string dateTime, int paymentTerms, string client)
        {
            Id = id;
            Address = address;
            this.DateTime = dateTime;
            PaymentTerms = paymentTerms;
            Client = client;
        }
    }
}
