using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservationSystem.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string DateTime { get; set; }
        public int TableSeats { get; set; }
        public string Client { get; set; }
        public int TableStatus { get; set; }

        public Customer(int id, string dateTime, int paymentTerms, string client, int tableStatus)
        {
            Id = id;
            this.DateTime = dateTime;
            TableSeats = paymentTerms;
            Client = client;
            TableStatus = tableStatus;
        }
    }
}
