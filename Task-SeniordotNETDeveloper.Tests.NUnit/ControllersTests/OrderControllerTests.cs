using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Task_SeniordotNETDeveloper.Controllers;
using Task_SeniordotNETDeveloper.Models;
using Task_SeniordotNETDeveloper.Services.Interfaces;

namespace Task_SeniordotNETDeveloper.Tests.NUnit.ControllersTests
{
    public class OrderControllerTests
    {
        private OrderController _orderController;

        [SetUp]
        public void SetUp()
        {
            _orderController = new(
                Substitute.For<IOrderService>()
            );
        }

        [Test]
        public void Test_Constructor()
        {
            Assert.DoesNotThrow(() => new OrderController(
                Substitute.For<IOrderService>()
            ));
        }

        [Test]
        public void Test_ConstructorIfOrderServiceIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new OrderController(null));
        }

        [Test]
        public void Test_MakeNewOrder()
        {
            OrderModel order = new();

            IActionResult result = _orderController.MakeNewOrder(order);

            Assert.IsInstanceOf<OkResult>(result);
        }

        [Test]
        public void Test_MakeNewOrderIfOrderIsNull()
        {
            OrderModel order = null;

            IActionResult result = _orderController.MakeNewOrder(order);

            Assert.IsInstanceOf<BadRequestResult>(result);
        }
    }
}