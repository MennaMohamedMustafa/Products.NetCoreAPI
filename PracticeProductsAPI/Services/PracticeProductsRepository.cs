using CourseLibrary.API.DbContexts;
using CourseLibrary.API.Entities;
using PracticeProductsAPI.ResourceParameters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CourseLibrary.API.Services
{
    public class PracticeProductsRepository : IPracticeProductsRepository, IDisposable
    {
        private readonly PracticeProductsContext _context;

        public PracticeProductsRepository(PracticeProductsContext context )
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Product GetProduct(int productId)
        {
            if (productId == null)
            {
                throw new ArgumentNullException(nameof(productId));
            }

            return _context.Products
              .Where(c => c.Id == productId).FirstOrDefault();

        }
        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList<Product>();
        }

        public IEnumerable<Product> GetProducts(ProductsResourceParameters productsResourceParameters)
        {
            if (productsResourceParameters == null)
            {
                throw new ArgumentNullException(nameof(productsResourceParameters));
            }

            if (string.IsNullOrWhiteSpace(productsResourceParameters.CategoryId))
            {
                return GetProducts();
            }

            var collection = _context.Products as IQueryable<Product>;

            if (!string.IsNullOrWhiteSpace(productsResourceParameters.CategoryId))
            {
                var categoryId = productsResourceParameters.CategoryId.Trim();
                collection = collection.Where(a => a.CategoryId == int.Parse(categoryId));
            }

            return collection.ToList();
        }

        public void AddProduct(Product product)
        {

            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            // always set the CategoryId to the passed-in categoryId
            //product.CategoryId = categoryId;
            _context.Products.Add(product); 
        }

        public void AddProducts(IEnumerable<Product> products)
        {

        }

        public void DeleteProduct(int productId)
        {
            var product = _context.Products.Where(p => p.Id == productId).FirstOrDefault();
            _context.Products.Remove(product);
        }

        public bool UpdateProduct(Product productToUpdate)
        {
            if (productToUpdate == null)
            {
                throw new ArgumentNullException("product");
            }
            var  product = _context.Products.Where(p => p.Id == productToUpdate.Id).FirstOrDefault();
            if (product == null)
            {
                return false;
            }
            _context.Products.Remove(product);
            _context.Products.Add(productToUpdate);
            return true;
        }

        public void UpdateProduct(int productId)
        {
            // no code in this implementation
        }

        public  bool ProductExists(int productId)
        {
            if (productId == null)
            {
                throw new ArgumentNullException(nameof(productId));
            }

            return _context.Products.Any(a => a.Id == productId);
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.ToList<Category>();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
               // dispose resources when needed
            }
        }
    }
}
