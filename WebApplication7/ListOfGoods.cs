//using System.Net;
//using WebApplication7;
//using Newtonsoft.Json;
//using Microsoft.AspNetCore.Mvc;


//namespace WebApplication7
//{
//    public class ListOfGoods
//    {
//        private String html;

//        public ListOfGoods(String url)
//        {
//            Uri uri = new Uri(url);
//            html = new WebClient().DownloadString(uri);
//        }

//        public void PrintList() {
//            var list = JsonConvert.DeserializeObject<GoodsStructure>(html);

//            for (int i = 0; i < list.products.Count; i++)
//            {
                
//                Console.WriteLine(list.products[i].title + " - " + list.products[i].price + " Griven" + "\n" + "Sizes: ");
//                for (int j = 0; j < list.products[i].sizes.Count; j++)
//                {
//                    Console.WriteLine(list.products[i].sizes[j]);
//                }
//                Console.WriteLine("Description: " + list.products[i].description);
//                Console.WriteLine("----------------------------");
//            }
            
//        }
//        public String Title() {
//            var list = JsonConvert.DeserializeObject<GoodsStructure>(html);
//            String title = "";
//            for (int i = 0; i < list.products.Count; i++)
//            {
//                title = list.products[i].title;
//            }
//                return title;
//        }
//    }
//}
