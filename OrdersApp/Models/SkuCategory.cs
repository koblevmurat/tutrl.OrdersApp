namespace OrdersApp.Models
{
    public class SkuCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Sku> Skus { get; set; }
    }
}
