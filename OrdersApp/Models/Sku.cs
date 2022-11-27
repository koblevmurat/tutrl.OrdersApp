using Microsoft.EntityFrameworkCore;
using System.Data.SqlTypes;

namespace OrdersApp.Models
{
    public class Sku
    {
        public int Id { get; set; }
        public int SkuCategoryId { get; set; }
        public string Name { get; set; }
        [Precision(18, 2)]
        public Decimal Price { get; set; }
        public SkuCategory SkuCategory { get; set; }
    }
}
