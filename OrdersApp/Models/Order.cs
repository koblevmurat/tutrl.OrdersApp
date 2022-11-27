namespace OrdersApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public Customer Customer { get; set; }

        public ICollection <OrderSku> OrderSkus { get; set; }
    }
}
