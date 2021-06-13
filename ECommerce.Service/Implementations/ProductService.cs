using AutoMapper;
using ECommerce.EF.CustomModels;
using ECommerce.EF.Models;
using ECommerce.Repository.Interface;
using ECommerce.Service.Interface;
using ECommerce.Service.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductService(IProductRepository _productRepository, IMapper mapper)
        {
            productRepository = _productRepository;
            this.mapper = mapper;
        }

        public async Task<List<ProductAttributeLookupModel>> GetAttributeLookup()
        {
            var productAttributeLookup = new List<ProductAttributeLookupModel>();
            var query = productRepository.GetProductAttributeLookups().AsQueryable();
            return await query.Select(pal => new ProductAttributeLookupModel
            {
                AttributeId = pal.AttributeId,
                AttributeName = pal.AttributeName,
                ProdCatId = pal.ProdCatId
            }).ToListAsync();
        }

        public async Task<List<ProductCategoryModel>> GetProductCategory()
        {
            var productCategory = new List<ProductCategoryModel>();
            var query = productRepository.GetProductCategories().AsQueryable();
            return await query.Select(pc => new ProductCategoryModel
            {
                ProdCatId = pc.ProdCatId,
                CategoryName = pc.CategoryName
            }).ToListAsync();

        }

        public async Task<ResponseModel<ProductResponse>> GetProductDetails(ProductRequest productRequest)
        {
            var products = new ResponseModel<ProductResponse>();
            var query = productRepository.GetProducts().AsQueryable();

            // Search Filter
            if (!string.IsNullOrWhiteSpace(productRequest.SearchString))
            {
                query.Where(p => p.ProdName.ToLower().Contains(productRequest.SearchString.ToLower()));
            }

            // Sorting
            if (!string.IsNullOrWhiteSpace(productRequest.OrderByField) && !string.IsNullOrWhiteSpace(productRequest.OrderByDirection))
            {
                switch (productRequest.OrderByField.ToLower())
                {
                    case "name":
                        if (productRequest.OrderByDirection.ToLower() == "asc")
                            query = query.OrderBy(p => p.ProdName).AsQueryable();
                        else
                            query = query.OrderByDescending(o => o.ProdName).AsQueryable();
                        break;
                    case "category":
                        if (productRequest.OrderByDirection.ToLower() == "asc")
                            query = query.OrderBy(p => p.ProductCategoryName).AsQueryable();
                        else
                            query = query.OrderByDescending(o => o.ProdName).AsQueryable();
                        break;
                    default:
                        if (productRequest.OrderByDirection.ToLower() == "asc")
                            query = query.OrderBy(o => o.ProdName).AsQueryable();
                        else
                            query = query.OrderByDescending(o => o.ProdName).AsQueryable();
                        break;
                }
            }

            // Response generation
            products.Data = await query.Skip(productRequest.Skip).Take(productRequest.Take)
                .Select(s => new ProductResponse
                {
                    ProductId = s.ProductId,
                    ProdCatId = s.ProdCatId,
                    ProdName = s.ProdName,
                    ProdCategoryName = s.ProductCategoryName,
                    ProdDescription = s.ProdDescription
                }).ToListAsync();
            products.Count = await query.CountAsync();
            return products;
        }

        public async Task<ProductViewModel> GetProductDetailsById(int productId)
        {
            var productresponseObj = await productRepository.GetProductData(productId);
            return mapper.Map<ProductViewModel>(productresponseObj);
        }

        public async Task<ProductAttributeModel> GetProductAttribute(int attributeId)
        {
            return mapper.Map<ProductAttributeModel>(await productRepository.GetProductAttribute(attributeId));
        }

        public async Task<List<ProductAttributeLookupModel>> GetProductAttributeLookup(int categoryId)
        {
            return mapper.Map<List<ProductAttributeLookupModel>>(await productRepository.GetProductAttributeLookup(categoryId));
        }

        public async Task<string> AddProduct(AddUpdateProductViewModel addUpdateProductViewModel)
        {
            if (addUpdateProductViewModel != null)
            {
                ProductModel pm = new ProductModel();
                pm.ProdName = addUpdateProductViewModel.ProductName;
                pm.ProdDescription = addUpdateProductViewModel.ProductDescription;
                pm.ProdCatId = addUpdateProductViewModel.CategoryId;
                var id = await productRepository.AddProduct(pm);
                if (id > 0)
                {
                    var productAttributeModel = new ProductAttributeModel();
                    productAttributeModel.ProductId = id;
                    productAttributeModel.AttributeId = addUpdateProductViewModel.AttributeId;
                    productAttributeModel.AttributeValue = addUpdateProductViewModel.AttributeName;
                    var obj = mapper.Map<ProductAttributeModel, ProductAttribute>(productAttributeModel);
                    var attrId = await productRepository.AddAttribute(obj);
                    if (attrId > 0)
                        return "200";

                }
                return "200";
            }
            else
            {
                return "500";
            }
        }

        public async Task<string> UpdateProduct(AddUpdateProductViewModel addUpdateProductViewModel)
        {
            var obj = await productRepository.GetProductData(addUpdateProductViewModel.ProductId);
            obj.ProdName = addUpdateProductViewModel.ProductName;
            obj.ProdDescription = addUpdateProductViewModel.ProductDescription;
            var response = await productRepository.UpdateProducts(obj);
            if (response == "200")
            {
                var productAttributeModel = new ProductAttributeModel();
                productAttributeModel.ProductId = addUpdateProductViewModel.ProductId;
                productAttributeModel.AttributeId = addUpdateProductViewModel.AttributeId;
                productAttributeModel.AttributeValue = addUpdateProductViewModel.AttributeName;
                var productAttributeObj = mapper.Map<ProductAttributeModel, ProductAttribute>(productAttributeModel);
                var attrId = await productRepository.UpdateAttribute(productAttributeObj);
                     if (attrId > 0)
                    return "200";
                return "200";
            }
            else
            {
                return "500";
            }
        }
    }
}
