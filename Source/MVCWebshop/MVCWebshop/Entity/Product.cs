namespace MVCWebshop.Entity
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public byte ProductStatus { get; set; }
        public double ProductPrice { get; set; }
        public int ProductUnitsStock { get; set; }
    }
}