using RestaurantReservationSystem.Entities;
using RestaurantReservationSystem.Repositories;
using RestaurantReservationSystem;
using Newtonsoft.Json;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System;
using Newtonsoft.Json.Serialization;

namespace Saskaitos_Generavimas_Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(1,10)]
        public void GetTotalRowCalculation(int itemId, int qty)
        {
            ItemsRepository itemsRepository = new ItemsRepository();
            CustomerRepository customerRepository = new CustomerRepository();
            RandomNumberGenerator randomNumberGenerator = new RandomNumberGenerator();
            ItemsOnInvoiceRepository itemsOnInvoiceRepository = new ItemsOnInvoiceRepository();
            CustomerFileRead customerFileRead = new CustomerFileRead();
            CustomerFileReadValidation customerFileReadValidation = new CustomerFileReadValidation();
            //Arrange
            List<ListOfItem> Itemss = new List<ListOfItem>();

            //Act
            var pricing = itemsRepository.Load2(itemId);
            var actualResult = pricing * qty;
            //assert
            var expected = pricing * qty; 
            Assert.AreEqual(expected, actualResult);
        }

        [Test]
        [TestCase(5,5)]
        public void CheckTableUpdate (int id, int yes)
        {
            CustomerRepository customerRepository = new CustomerRepository();

            //Arrange
            customerRepository.WriteToFile(customerRepository.UpdateTableStatus(customerRepository.ReadFromFileCustomers(), yes));
            customerRepository.WriteToFile(customerRepository.UpdateTableStatusAfterPayment(customerRepository.ReadFromFileCustomers(), id));
            var list = JsonConvert.DeserializeObject<List<Customer>>(customerRepository.ReadFromFileCustomers());
            var result = list.SingleOrDefault(x => x.Id == yes);
            //Act

            //assert
            int expected = 0;
            Assert.AreEqual(expected, result.TableStatus);
            
        }

        [Test]
        [TestCase(5, "2022-11-10", 6, "6", 0 )]
        public void ChecktIfPossibleToAddCustumerIfFileEmpty (int id, string dateTime, int tableSeats, string client, int tableStatus)
        {
            CustomerRepository customerRepository = new CustomerRepository();

            //Arrange

            customerRepository.ReadFromFileCustomersTesting();
            customerRepository.WriteToFileTestEmptyFile(new Customer(id, dateTime, tableSeats, client, tableStatus));
            customerRepository.ReadFromFileCustomersTesting();
            //Act

            //assert
            int expected = 0;
            Assert.That(customerRepository.ReadFromFileCustomersTesting(), Is.Not.EqualTo(null));

        }

    }
}