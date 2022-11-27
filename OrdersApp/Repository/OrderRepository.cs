using OrdersApp.Data;
using OrdersApp.Interfaces;
using OrdersApp.Models;

namespace OrdersApp.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;

        public OrderRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Order> GetOrders()
        {
            return _context.Orders.OrderBy(p => p.OrderDate).ToList();
        }
    }
}
