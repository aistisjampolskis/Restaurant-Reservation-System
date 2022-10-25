using Saskaitos_generavimas.Entities;
using Saskaitos_generavimas.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace Saskaitos_generavimas
{
    public class CreatingItem
    {
        ItemsRepository itemsRepository = new ItemsRepository();

        public void CreatingItem2()
        {
            int invoiceId = 0;
            List<Item> Items = new List<Item>();
            Console.Clear();
            Console.WriteLine("Enter item Id");
            int id = Convert.ToInt32(Console.ReadLine());
            while (true)
            {
                if (id <= 0)
                {
                    Console.WriteLine("Enter right item id");
                    id = Convert.ToInt32(Console.ReadLine());
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine("Enter item description");
            string description = Console.ReadLine();
            Console.WriteLine("Enter item price");
            double resultPrice = Convert.ToDouble(Console.ReadLine());
            while (true)
            {
                if (resultPrice <= 0 || resultPrice == '.')
                {
                    Console.WriteLine("Enter right price");
                    resultPrice = Convert.ToDouble(Console.ReadLine());
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine("Enter item producer");
            string resultProducer = Console.ReadLine();
            itemsRepository.Save(new Item(id, invoiceId, description, resultPrice, resultProducer));
        }
    }
}
