using OrdersApp.Data;
using OrdersApp.Models;

namespace OrdersApp.Interfaces
{
    public interface IOrderRepository
    {
        ICollection<Order> GetOrders(DateTime date);

        ICollection<Order> GetOrders(Customer customer);    

        ICollection<Order> GetAllOrders();

        public Order GetOrder(int Id);

        public Order GetOrder(Order order);

    }    
}
