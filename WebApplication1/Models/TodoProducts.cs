namespace WebApplication1.Models
{
        public class TodoProducts
        {
            public List<Product> products { get; set; }
            public Apikeys apiKeys { get; set; }
        }

        public class Apikeys
        {
            public String primary { get; set; }
            public String secondary { get; set; }
        }

        public class Product
        {
            public String title { get; set; }
            public int price { get; set; }
            public List<Sizes> sizes { get; set; }
            public String description { get; set; }
        }
            public class Sizes 
            { 
                public String small { get; set; }
                public String medium { get; set; }
                public String large { get; set; }
            }

    }
