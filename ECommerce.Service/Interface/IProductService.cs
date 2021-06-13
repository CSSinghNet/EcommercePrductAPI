using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ECommerce.Service.ViewModels;
using System.Threading.Tasks;
using ECommerce.EF.CustomModels;

namespace ECommerce.Service.Interface
{
    public interface IProductService
    {
        Task<ResponseModel<ProductResponse>> GetProductDetails(ProductRequest productRequest);
        Task<List<ProductAttributeLookupModel>> GetAttributeLookup();
        Task<List<ProductCategoryModel>> GetProductCategory();
        Task<ProductViewModel> GetProductDetailsById(int productId);
        Task<ProductAttributeModel> GetProductAttribute(int attributeId);
        Task<List<ProductAttributeLookupModel>> GetProductAttributeLookup(int categoryId);
        Task<string> AddProduct(AddUpdateProductViewModel addUpdateProductViewModel);
        Task<string> UpdateProduct(AddUpdateProductViewModel addUpdateProductViewModel);
    }
}
