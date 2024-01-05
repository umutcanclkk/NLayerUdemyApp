
using AutoMapper;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Mapping
{
    public class MapProfile: Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();// ReverseMap() çift yönlü bilgi aktarımı için kullanabiliriz?
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<ProductFeature, ProductFeatureDto>().ReverseMap();
            CreateMap<ProductUpdateDto, Product>().ReverseMap();
            CreateMap<Product, ProductWithCategoryDto>().ReverseMap();
            CreateMap<Category, CategoryWithProductsDto>().ReverseMap();
            CreateMap<Customers, CustomersDto>().ReverseMap();
            CreateMap<Payment, PaymentDto>().ReverseMap();
            CreateMap<PaymentUpdateDto,Payment>().ReverseMap();
            CreateMap<CustomersUpdateDto, Customers>().ReverseMap();
            CreateMap<CategoryUpdateDto, Category>().ReverseMap();

            CreateMap<CustomersUpdateDto, CustomersDto>();





        }
    }
}
