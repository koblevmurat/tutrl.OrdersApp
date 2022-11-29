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

        public ICollection<Order> GetAllOrders()
        {
            return _context.Orders.OrderBy(p => p.OrderDate).ToList();
        }

        public Order GetOrder(int Id)
        {
            return _context.Orders.Where(p => p.Id == Id).FirstOrDefault();
        }

        public Order GetOrder(Order order)
        {
            return _context.Orders.Where(p => p.Id == order.Id).First();
        }

        public ICollection<Order> GetOrders(DateTime date)
        {
            return _context.Orders.Where(p => p.OrderDate.Date >= date.Date &&
            p.OrderDate.Date.AddDays(1).AddTicks(-1) <= date.Date).ToList();
        }

        public ICollection<Order> GetOrders(Customer customer)
        {
            return _context.Orders.Where(p => p.Customer = customer).ToList();
        }
    }
}
