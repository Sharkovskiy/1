namespace WebApplication7.Models
{
    public class GoodsStructure
    {
        public Product[] products { get; set; }
        public Apikeys apikeys { get; set; }
    }

    public class Apikeys
    {
        public string primary { get; set; }
        public string secondary { get; set; }
    }

    public class Product
    {
        public string title { get; set; }
        public int price { get; set; }
        public String[] sizes { get; set; }
        public string description { get; set; }
    }
}



