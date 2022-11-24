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
    public class CreatingItem
    {
        ItemsRepository itemsRepository = new ItemsRepository();

        public void CreatingItem2()
        {
            int invoiceId = 0;
            List<Item> Items = new List<Item>();
            Console.Clear();
             int id = itemsRepository.LoadIdGeneratorChekerDrinks();
            int id2 = itemsRepository.LoadIdGeneratorChekerFood();
            Console.WriteLine($"Generating Item Id = {id}");
            Console.WriteLine("Enter item description");
            string description = Console.ReadLine();
            Console.WriteLine("Enter item price");
            double price = Convert.ToDouble(Console.ReadLine());
            while (true)
            {
                if (price <= 0 || price == '.')
                {
                    Console.WriteLine("Enter right price");
                    price = Convert.ToDouble(Console.ReadLine());
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine("Enter 1 for Food and 2 for Drink");
            int producer = Convert.ToInt32(Console.ReadLine());
            while (true)
            {
                if (producer < 0 || producer > 2)
                {
                    Console.WriteLine("Enter right option 1 for Food and 2 for Drink");
                    producer = Convert.ToInt32(Console.ReadLine());
                }
                else
                {
                    break;
                }
            }
            if (producer == 1)
            itemsRepository.Save(new Item(id2, invoiceId, description, price, producer));
            else
            itemsRepository.Save2(new Item(id, invoiceId, description, price, producer));
        }
    }
}
