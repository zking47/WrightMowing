using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Wright.Data.Entities;
using Wright.Models.CategoryModels;

namespace Wright.Models.AutoMap
{
    public class CategoryMapProfile : Profile
    {
        public CategoryMapProfile()
        {
            CreateMap<CategoryEntity, CategoryDetail>();
            CreateMap<CategoryEntity, CategoryIndex>();
            CreateMap<CategoryEntity, CategoryEdit>();

            CreateMap<CategoryCreate, CategoryEntity>();
            CreateMap<CategoryEdit, CategoryEntity>();
        }
    }
}