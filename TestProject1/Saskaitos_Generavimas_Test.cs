using Saskaitos_generavimas.Entities;
using Saskaitos_generavimas.Repositories;
using Saskaitos_generavimas;
using QuickType;

namespace Saskaitos_Generavimas_Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(10, 5)]
        public void GetTotalRowCalculation(int qty, double price)
        {
            //Arrange
            List<ListOfItem> Itemss = new List<ListOfItem>();
            ItemsRepository itemsRepository = new ItemsRepository();
            var item = new ListOfItem
            {
                Quantyti = qty,
                Price = price,
            };

            //Act
            price = item.Price;
            qty = item.Quantyti;
            var actualResult = price * qty;
            //assert
            var expected = 50; 
            Assert.AreEqual(expected, actualResult);
        }
    }
}