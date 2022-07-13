namespace WebApplication12.Models
{
    public class GoodStructure
    {
        public Product[] Products { get; set; }
        public Apikeys ApiKeys { get; set; }
    }

    public class Apikeys
    {
        public string Primary { get; set; }
        public string Secondary { get; set; }
    }

    public class Product
    {
        public string Title { get; set; }
        public int Price { get; set; }
        public string[] Sizes { get; set; }
        public string Description { get; set; }
    }
}