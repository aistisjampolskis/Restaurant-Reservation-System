using Saskaitos_generavimas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saskaitos_generavimas.Repositories
{
    public class ItemsRepository
    {
        private List<Item> Items { get; set; } = new List<Item>();

        public ItemsRepository()
        {
            Items.Add(new Item(1, 1, "Pienas", 2.20, "Žemaitijos pienas"));
            Items.Add(new Item(2, 1,"Duona", 1.38, "Kėdainių duona"));
            Items.Add(new Item(3, 1, "Batonas", 0.38, "Krekenavos Batonas"));
            Items.Add(new Item(4, 1, "Sūris", 3.38, "Rokiškio sūris"));
            Items.Add(new Item(5, 1, "Dešra", 2.38, "Biovela"));
            Items.Add(new Item(6, 1, "Kefyras", 2.99, "Vylkiškiai"));
            Items.Add(new Item(11, 1, "Snickers", 2.99, "Nike"));
        }

        public List<Item> RetrieveList()
        {
            return Items;
        }

        public Item RetrieveById(int id)
        {
            return Items.SingleOrDefault(x => x.Id == id);
        }

        public Item RetrievebyDescription(string description)
        {
            return Items.SingleOrDefault(x => x.Description == description);
        }

        public void Save(Item item)
        {
            Items.Add(item);
        }
       /*// public List<Item> RetrievById(int id)
        {
            return Items.SingleOrDefault(x => x.Id == id);
        }*/

    }
}
