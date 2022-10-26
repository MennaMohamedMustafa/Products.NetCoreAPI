using CourseLibrary.API.Entities;
using PracticeProductsAPI.ResourceParameters;
using System;
using System.Collections.Generic;

namespace CourseLibrary.API.Services
{
    public interface IPracticeProductsRepository
    {
        IEnumerable<Product> GetProducts(ProductsResourceParameters productsResourceParameters);
        IEnumerable<Product> GetProducts();
        Product GetProduct(int productId);
        void AddProduct(Product product);
        void AddProducts(IEnumerable<Product> products);
        bool UpdateProduct(Product product);
        void UpdateProduct(int productId);
        void DeleteProduct(int productId);
        IEnumerable<Category> GetCategories();
        bool ProductExists(int productId);
        bool Save();
    }
}
