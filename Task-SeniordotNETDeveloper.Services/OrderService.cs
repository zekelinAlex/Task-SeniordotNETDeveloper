using Task_SeniordotNETDeveloper.Models;
using Task_SeniordotNETDeveloper.Services.Interfaces;

namespace Task_SeniordotNETDeveloper.Services
{
    public class OrderService : IOrderService
    {
        private readonly List<OrderModel> _mockDB;

        private readonly Timer _timer;
        private readonly List<OrderModel> _ordersForLasr20Sec;

        public OrderService()
        {
            _mockDB = new();

            _timer = new(SaveOrders, null, TimeSpan.Zero, TimeSpan.FromSeconds(20));
            _ordersForLasr20Sec = new();
        }

        public void AddOrder(OrderModel order)
        {
            ArgumentNullException.ThrowIfNull(order, nameof(order));

            _ordersForLasr20Sec.Add(order);
        }

        private void SaveOrders(object state)
        {
            if (_ordersForLasr20Sec.Count == 0)
            {
                return;
            }

            _mockDB.AddRange(_ordersForLasr20Sec);

            _ordersForLasr20Sec.Clear();

            /*
                Pokud bychom chtěli použít entity fraimwork, museli bychom napsat takto
                
                ICollection<OrderEntities> ordersEntities = _mapper.ToEntities(_ordersForLasr20Sec);
                
                _orderRepository.Create(ordersEntities);            
                
                A pak uvnitř repozitáře

                _context.OrdersEntities.AddRange(entities);

                _context.SaveChanges();
           */
        }
    }
}