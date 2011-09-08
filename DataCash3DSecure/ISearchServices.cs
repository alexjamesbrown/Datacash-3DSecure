using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreditCardProcessing
{

    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }

    public interface ISearchService
    {
        List<Product> SearchProducts(string keyword);
        List<Product> SearchProducts(string keyword, int max);
    }



    public class AlexSearchService : ISearchService
    {
        public List<Product> SearchProducts(string keyword)
        {
            return null;
        }

        public List<Product> SearchProducts(string keyword, int max)
        {
            return null;
        }
    }


    public class test {

        public void testMe()
        {
            var test = new AlexSearchService();

            var x = test.SearchProducts("test");

            var whatever = from product in 
                           x where product.Price < 10 select x;
 
        }
    }

}
