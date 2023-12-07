using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Wright.Data.Entities;
using Wright.Models.MowerTypeModels;

namespace Wright.Models.AutoMap
{
    public class MowerTypeMapProfile : Profile
    {
        public MowerTypeMapProfile()
        {
            CreateMap<MowerTypeEntity, MowerTypeDetail>();
            CreateMap<MowerTypeEntity, MowerTypeIndex>();
            CreateMap<MowerTypeEntity, MowerTypeEdit>();

            CreateMap<MowerTypeCreate, MowerTypeEntity>();
            CreateMap<MowerTypeEdit, MowerTypeEntity>();
        }
    }
}