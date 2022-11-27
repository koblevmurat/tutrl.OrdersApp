using Microsoft.EntityFrameworkCore;
using System.Data.SqlTypes;

namespace OrdersApp.Models
{
    public class OrderSku
    {
        public int Id { get; set; }
        public Sku Sku { get; set; }
        public Double Amount { get; set; }
        [Precision(18, 2)]
        public Decimal Sum { get; set; }

        public Order Order { get; set; }
        public int OrderId { get; set; }
    }
}
