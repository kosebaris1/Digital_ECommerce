using AutoMapper;
using D_Domain_Layer.Entities;
using D_Infrastructure_Layer.DTOs;
using D_Infrastructure_Layer.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_Persistence_Layer.MappingProfiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<MainCategoryDTO, MainCategory>().ReverseMap(); 
            CreateMap<SubCategoryDTO, SubCategory>().ReverseMap(); 
            CreateMap<ProductDTO, Product>().ReverseMap(); 
        }
    }
}
