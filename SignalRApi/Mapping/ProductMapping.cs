using AutoMapper;
using EntityLayer.Concrete;
using SignalR.DtoLayer.ProductDto;

namespace SignalRApi.Mapping
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, GetProductDto>().ReverseMap();

            CreateMap<Product, ResultProductWithCategoryDto>().ReverseMap();

            CreateMap<Product, ResultProductWithCategoryDto>()

                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName))

                .ReverseMap();

        }
    }
}
