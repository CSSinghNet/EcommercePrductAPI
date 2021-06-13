using ECommerce.EF.Contexts;
using ECommerce.EF.CustomModels;
using ECommerce.EF.Models;
using ECommerce.Repository.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repository.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly ECommerceContext dbContext;
        public ProductRepository(ECommerceContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public async Task<long> AddProduct(ProductModel productModel)
        {
            var obj = new Product();
            obj.ProductId = productModel.ProductId;
            obj.ProdCatId = productModel.ProdCatId;
            obj.ProdName = productModel.ProdName;
            obj.ProdDescription = productModel.ProdDescription;

            await dbContext.Product.AddAsync(obj);
            await dbContext.SaveChangesAsync();
            return obj.ProductId;
        }

        public async Task<long> AddAttribute(ProductAttribute productAttribute)
        {
            // AS THERE IS NO PRIMARY KEY IN THE TABLE SO, WE HAVE TO USE ExecuteSqlCommandAsync METHOD FOR SAVING DATA IN THE TABLE
            var command = "INSERT ProductAttribute (ProductId,AttributeId,AttributeValue) VALUES (@ProductId,@AttributeId,@AttributeValue)";
            SqlParameter[] parameters = new SqlParameter[] {
                 new SqlParameter("@ProductId", productAttribute.ProductId),
                 new SqlParameter("@AttributeId", productAttribute.AttributeId),
                 new SqlParameter("@AttributeValue", productAttribute.AttributeValue)
               };

            await dbContext.Database.ExecuteSqlCommandAsync(command, parameters);

            return productAttribute.AttributeId;
        }


        public async Task<long> UpdateAttribute(ProductAttribute productAttribute)
        {
            // AS THERE IS NO PRIMARY KEY IN THE TABLE SO, WE HAVE TO USE ExecuteSqlCommandAsync METHOD FOR SAVING DATA IN THE TABLE

            await dbContext.Database.ExecuteSqlCommandAsync("Update ProductAttribute set AttributeId =" +
                " '" + productAttribute.AttributeId + "'," +
                "AttributeValue='" + productAttribute.AttributeValue + "' where AttributeId = " + productAttribute.AttributeId + "");

            //await dbContext.Database.ExecuteSqlCommandAsync(command, parameters);

            return productAttribute.AttributeId;
        }
        public async Task<ProductAttribute> GetProductAttribute(int attributeId)
        {
            return await dbContext.ProductAttribute.FirstOrDefaultAsync(p => p.AttributeId == attributeId);
        }

        public IQueryable<ProductAttributeLookup> GetProductAttributeLookups()
        {
            return dbContext.ProductAttributeLookup;
        }

        public IQueryable<ProductCategory> GetProductCategories()
        {
            return dbContext.ProductCategory;
        }

        public IQueryable<ProductModel> GetProducts()
        {
            var products = from p in dbContext.Product
                           join pc in dbContext.ProductCategory
                           on p.ProdCatId equals pc.ProdCatId
                           select new ProductModel
                           {
                               ProductId = p.ProductId,
                               ProdName = p.ProdName,
                               ProdDescription = p.ProdDescription,
                               ProdCatId = pc.ProdCatId,
                               ProductCategoryName = pc.CategoryName
                           };
            return products;
        }

        public async Task<string> UpdateProducts(Product product)
        {
            dbContext.Product.Update(product);
            try
            {
            var result = await dbContext.SaveChangesAsync();

            return result == 1 ? "200" : "500";
            }
            catch (Exception e)
            {

                throw;
            }

        }

        public async Task<Product> GetProductData(int productId)
        {
            return await dbContext.Product.FirstOrDefaultAsync(x => x.ProductId == productId);
        }

        public async Task<List<ProductAttributeLookup>> GetProductAttributeLookup(int categoryId)
        {
            return await dbContext.ProductAttributeLookup.Where(x => x.ProdCatId == categoryId).ToListAsync();
        }
    }
}
