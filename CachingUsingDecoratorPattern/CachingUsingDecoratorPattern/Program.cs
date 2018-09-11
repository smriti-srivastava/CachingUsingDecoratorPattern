using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CachingUsingDecoratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            IProductService productService = new MemoryCashProductService();
            List<Product> products = productService.GetProducts();
            while (true)
            {
                Console.WriteLine("Products Available");
                foreach (Product item in products)
                {
                    Console.WriteLine("Id: " + item.Id + "\tName:" + item.Name + "\tPrice:" + item.Price);
                }
                Console.WriteLine("Select One Id: ");
                int id = int.Parse(Console.ReadLine());
                Product product = productService.GetProductById(id);
                Console.WriteLine(product.Id);
                foreach (Product item in products)
                {
                    Console.WriteLine("Id: " + item.Id + "\tName:" + item.Name + "\tPrice:" + item.Price);
                }
                Console.WriteLine("Select Id: ");
                id = int.Parse(Console.ReadLine());
                product = productService.GetProductById(id);
                Console.WriteLine(product.Id);
            }
        }
    }
}
