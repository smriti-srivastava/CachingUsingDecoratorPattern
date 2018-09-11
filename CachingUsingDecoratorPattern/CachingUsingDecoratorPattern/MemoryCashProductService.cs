using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CachingUsingDecoratorPattern
{
    class MemoryCashProductService : ICashProductService
    {
        private IProductService _productService;
        private MemoryCachProvider _memoryCachProvider;
        public MemoryCashProductService()
        {
            _productService = new ProductService();
            _memoryCachProvider = new MemoryCachProvider();
        }
        public Product GetProductById(int id)
        {
            Product product = (Product)_memoryCachProvider.GetItem(Convert.ToString(id));
            if (product != null)
            {
                Console.WriteLine("Getting Product " + id + " From Cache");
                return product;
            }
            product = _productService.GetProductById(id);
            _memoryCachProvider.AddItem(Convert.ToString(product.Id), product);
            return product;
        }

        public List<Product> GetProducts()
        {
            List<Product> products = _productService.GetProducts();
            //foreach(Product product in products)
            //{
            //    if(_memoryCachProvider.GetItem(Convert.ToString(product.Id))==null)
            //    {
            //        Console.WriteLine("Adding Cache");
            //        _memoryCachProvider.AddItem(Convert.ToString(product.Id), product);
            //    }
            //}
            return products;
        }
    }
}
