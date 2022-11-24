using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservationSystem.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime DateTime { get; set; }
        public int PaymentOption { get; set; }
        public string Client { get; set; }
        public int Quantyti { get; set; }

        public Order(int id, string orderNumber, DateTime dateTime, int paymentOption, string client, int quantyti)
        {
            Id = id;
            OrderNumber = orderNumber;
            this.DateTime = dateTime;
            PaymentOption = paymentOption;
            Client = client;
            Quantyti = quantyti;
        }
    }
}
