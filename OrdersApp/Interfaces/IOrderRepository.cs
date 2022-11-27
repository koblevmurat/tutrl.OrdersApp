using OrdersApp.Data;
using OrdersApp.Models;

namespace OrdersApp.Interfaces
{
    public interface IOrderRepository
    {
        ICollection<Order> GetOrders();
    }
}
