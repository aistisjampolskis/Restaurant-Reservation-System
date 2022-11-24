using RestaurantReservationSystem.Entities;
using RestaurantReservationSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace RestaurantReservationSystem
{
    public class CreatingCustomer
    {
        CustomerRepository customerRepository = new CustomerRepository();

        public void CreateCustomer2()
        {
            List<Customer> Invoices = new List<Customer>();
            DateTime date1 = DateTime.Now;
            Console.Clear();
            int id = customerRepository.Load6();
            Console.WriteLine($"Generating table Id = {id}");
            Console.WriteLine("Enter Tables size/seat number");
            int tableSeats = Convert.ToInt32(Console.ReadLine());
            while (true)
            {
                if (tableSeats < 0 || tableSeats > 6)
                {
                    Console.WriteLine("Enter right size of seat");
                    tableSeats = Convert.ToInt32(Console.ReadLine());
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine("Enter Table Number");
            string client = Console.ReadLine();
            Console.WriteLine("Enter reservation date");
            string dateTime = Console.ReadLine();
            Console.WriteLine("Enter table status");
            int tableStatus = Convert.ToInt32(Console.ReadLine());
            while (true)
            {
                if (tableStatus < 0 || tableStatus > 1)
                {
                    Console.WriteLine("Enter right table status");
                    tableStatus = Convert.ToInt32(Console.ReadLine());
                }
                else
                {
                    break;
                }
            }

            customerRepository.Save(new Customer(id, dateTime, tableSeats, client, tableStatus));

        }
    }
}
