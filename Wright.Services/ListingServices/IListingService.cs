using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wright.Models.ListingModels;

namespace Wright.Services.ListingServices
{
    public interface IListingService
    {
        Task<ListingIndex?> CreateNewListingAsync(ListingCreate request);
        Task<List<ListingIndex>> GetAllListingsAsync();
        Task<ListingDetail?> GetListingByIdAsync(int id); 
        Task<bool> EditListingAsync(ListingEdit request);
        Task<bool> DeleteListingAsync(int id);
        Task<ListingEdit?> GetListingByIdForEditAsync(int id);
    }
}