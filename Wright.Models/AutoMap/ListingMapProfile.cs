using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Wright.Data.Entities;
using Wright.Models.ListingModels;

namespace Wright.Models.AutoMap
{
    public class ListingMapProfile : Profile
    {
        public ListingMapProfile()
        {
            CreateMap<ListingEntity, ListingDetail>();
            CreateMap<ListingEntity, ListingIndex>();
            CreateMap<ListingEntity, ListingEdit>();

            CreateMap<ListingCreate, ListingEntity>();
            CreateMap<ListingEdit, ListingEntity>();
        }
    }
}