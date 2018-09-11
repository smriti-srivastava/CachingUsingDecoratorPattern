using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CachingUsingDecoratorPattern
{
    class ProductService : IProductService
    {
        public Product GetProductById(int id)
        {
            IRepository productRepo = new SQLProductRepository();
            Console.WriteLine("Getting Product "+id+" From Repository");
            return productRepo.GetProductById(id);
        }

        public List<Product> GetProducts()
        {
            IRepository productRepo = new SQLProductRepository();
            return productRepo.GetAllProducts();
        }
    }
}
