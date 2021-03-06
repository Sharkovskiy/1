using System.Linq;
using WebApplication12.Models;

namespace WebApplication12.Lists
{
    public class Logic
    {
        public String MostCommonWords(List<Product> list)
        {
            String ArString = "";
            foreach (Product product in list) {
                ArString += product.Description.Replace(".", "") + " ";
            }
            string[] SplitedStr = ArString.Split(new char[] { ' ' });

            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            foreach (string s in SplitedStr.SkipLast(1))
            {
                if (dictionary.Keys.Contains(s)) dictionary[s]++;
                else dictionary.Add(s, 1);
            }

            int k = 0;
            string output = "";

            foreach (KeyValuePair<string, int> word in dictionary.OrderByDescending(a => a.Value)) 
            {
                if (k < 15 && k >= 5)
                {
                    output += word.Key + " - " + word.Value + "\n";
                }
                k++;
            }
            return output;
        }

        public String AllSizeOfAllProducts(List<Product> list) {
            string? allSizes = "";
            
            string?[,] strings = new string[list.Count, 3];
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list[i].Sizes.Length; j++)
                {
                    strings[i, j] = list[i].Sizes[j]; 
                    allSizes += strings[i,j] + " ";
                }
                allSizes += "\n";
            }
            return allSizes;
        }    
    }
}
