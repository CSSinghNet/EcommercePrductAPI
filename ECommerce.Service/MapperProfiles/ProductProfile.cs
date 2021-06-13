using AutoMapper;
using ECommerce.EF.Models;
using ECommerce.Service.ViewModels;

namespace ECommerce.Service.MapperProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductResponse>()
                .ForMember(dest => dest.ProductId, src => src.MapFrom(p => p.ProductId))
                .ForMember(dest => dest.ProdCatId, src => src.MapFrom(p => p.ProdCatId))
                .ForMember(dest => dest.ProdName, src => src.MapFrom(p => p.ProdName))
                .ForMember(dest => dest.ProdDescription, src => src.MapFrom(p => p.ProdDescription));

            CreateMap<Product, ProductViewModel>()
              .ForMember(dest => dest.ProductId, src => src.MapFrom(p => p.ProductId))
              .ForMember(dest => dest.ProdCatId, src => src.MapFrom(p => p.ProdCatId))
              .ForMember(dest => dest.ProdName, src => src.MapFrom(p => p.ProdName))
              .ForMember(dest => dest.ProdDescription, src => src.MapFrom(p => p.ProdDescription));

            CreateMap<ProductResponse, Product>()
                .ForMember(dest => dest.ProductId, src => src.MapFrom(p => p.ProductId))
                .ForMember(dest => dest.ProdCatId, src => src.MapFrom(p => p.ProdCatId))
                .ForMember(dest => dest.ProdName, src => src.MapFrom(p => p.ProdName))
                .ForMember(dest => dest.ProdDescription, src => src.MapFrom(p => p.ProdDescription));

            CreateMap<ProductAttribute, ProductAttributeModel>()
                .ForMember(dest => dest.ProductId, src => src.MapFrom(p => p.ProductId))
                .ForMember(dest => dest.AttributeId, src => src.MapFrom(p => p.AttributeId))
                .ForMember(dest => dest.AttributeValue, src => src.MapFrom(p => p.AttributeValue));
            CreateMap<ProductAttributeModel, ProductAttribute>()
              .ForMember(dest => dest.ProductId, src => src.MapFrom(p => p.ProductId))
              .ForMember(dest => dest.AttributeId, src => src.MapFrom(p => p.AttributeId))
              .ForMember(dest => dest.AttributeValue, src => src.MapFrom(p => p.AttributeValue));

            CreateMap<ProductAttributeLookup, ProductAttributeLookupModel>()
               .ForMember(dest => dest.ProdCatId, src => src.MapFrom(p => p.ProdCatId))
               .ForMember(dest => dest.AttributeId, src => src.MapFrom(p => p.AttributeId))
               .ForMember(dest => dest.AttributeName, src => src.MapFrom(p => p.AttributeName));
        }
    }
}
