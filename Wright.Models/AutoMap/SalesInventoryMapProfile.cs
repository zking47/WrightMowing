using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Wright.Data.Entities;
using Wright.Models.SalesInventoryModels;

namespace Wright.Models.AutoMap
{
    public class SalesInventoryMapProfile : Profile
    {
        public SalesInventoryMapProfile()
        {
            CreateMap<SalesInventoryEntity, SalesInvDetail>();
            CreateMap<SalesInventoryEntity, SalesInvIndex>();
            CreateMap<SalesInventoryEntity, SalesInvEdit>();

            CreateMap<SalesInvCreate, SalesInventoryEntity>();
            CreateMap<SalesInvEdit, SalesInventoryEntity>();
        }
    }
}