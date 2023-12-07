using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Wright.Data;
using Wright.Data.Entities;
using Wright.Models.ListingModels;

namespace Wright.Services.ListingServices
{
    public class ListingService : IListingService
    {
        private readonly WrightDbContext _dbContext;
        private readonly IMapper _mapper;

        public ListingService(WrightDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ListingIndex?> CreateNewListingAsync(ListingCreate request)
        {
            var listingEntity = _mapper.Map<ListingCreate, ListingEntity>(request);
            _dbContext.Listings.Add(listingEntity);
            var numberOfChanges = await _dbContext.SaveChangesAsync();
            if(numberOfChanges == 1)
            {
                ListingIndex response = _mapper.Map<ListingEntity, ListingIndex>(listingEntity);
                return response;
            }
            return null;
        }

        public async Task<bool> DeleteListingAsync(int id)
        {
            var listing = await _dbContext.Listings.FindAsync(id);

            if(listing == null)
                return false;

            _dbContext.Listings.Remove(listing);
            return await _dbContext.SaveChangesAsync() == 1;
        }

        public async Task<bool> EditListingAsync(ListingEdit request)
        {
            var listingExists = await _dbContext.Listings.AnyAsync(listing => listing.Id == request.Id);
            if(!listingExists)
                return false;
            var newListing = _mapper.Map<ListingEdit, ListingEntity>(request);
            _dbContext.Entry(newListing).State = EntityState.Modified;
            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<List<ListingIndex>> GetAllListingsAsync()
        {
            var listings = await _dbContext.Listings.Select(entity => _mapper.Map<ListingEntity, ListingIndex>(entity)).ToListAsync();
            return listings;
        }

        public async Task<ListingDetail?> GetListingByIdAsync(int id)
        {
            var listingEntity = await _dbContext.Listings.FirstOrDefaultAsync(e => e.Id == id);
            return listingEntity is null ? null : _mapper.Map<ListingEntity, ListingDetail>(listingEntity);
        }

        public async Task<ListingEdit?> GetListingByIdForEditAsync(int id)
        {
            var listingEntity = await _dbContext.Listings.FirstOrDefaultAsync(e => e.Id == id);
            return listingEntity is null ? null : _mapper.Map<ListingEntity, ListingEdit>(listingEntity);
        }
    }
}