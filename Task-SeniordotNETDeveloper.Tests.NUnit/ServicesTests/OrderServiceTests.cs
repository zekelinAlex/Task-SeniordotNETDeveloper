using Task_SeniordotNETDeveloper.Models;
using Task_SeniordotNETDeveloper.Services;
using Task_SeniordotNETDeveloper.Services.Interfaces;

namespace Task_SeniordotNETDeveloper.Tests.NUnit.ServicesTests
{
    public class OrderServiceTests
    {
        private IOrderService _orderService;

        [SetUp]
        public void Setup()
        {
            _orderService = new OrderService();

            /*
             * V tomto případě bychom mohli uvnitř testu vytvořit pouze jednu instanci třídy,
             * ale ve velkých projektech budeme mít zřejmě více testů pro danou službu,
             * takže je lepší to napsat v setupu.
             */
        }

        [Test]
        public void Test_Constructor()
        {
            Assert.DoesNotThrow(() => new OrderService());
        }

        [Test]
        public void Test_AddOrder()
        {
            OrderModel order = new()
            {
                ProductId = 1,
                Quantity = 1,
            };

            Assert.DoesNotThrow(() => _orderService.AddOrder(order));
        }

        [Test]
        public void Test_AddOrderIfOrderIsNull()
        {
            OrderModel order = null;

            Assert.Throws<ArgumentNullException>(() => _orderService.AddOrder(order));
        }
    }
}