using ECommerce.EF.CustomModels;
using ECommerce.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repository.Interface
{
   public interface IProductRepository
    {
        IQueryable<ProductModel> GetProducts();
        Task<Product> GetProductData(int productId);
        IQueryable<ProductAttributeLookup> GetProductAttributeLookups();
        IQueryable<ProductCategory> GetProductCategories();
        Task<string> UpdateProducts(Product product);
        Task<ProductAttribute> GetProductAttribute(int productId);
        Task<List<ProductAttributeLookup>> GetProductAttributeLookup(int categoryId);
        Task<long> AddProduct(ProductModel productModel);
        Task<long> AddAttribute(ProductAttribute productAttribute);
        Task<long> UpdateAttribute(ProductAttribute productAttribute);

    }
}
