using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wright.Models.SalesInventoryModels;

namespace Wright.Services.SalesInventoryServices
{
    public interface ISalesInventoryService
    {
        Task<SalesInvIndex?> CreateNewSalesInventoryAsync(SalesInvCreate request);
        Task<List<SalesInvIndex>> GetAllSalesInventoriesAsync();
        Task<SalesInvDetail?> GetSalesInventoryByIdAsync(int id); 
        Task<bool> EditSalesInventoryAsync(SalesInvEdit request);
        Task<bool> DeleteSalesInventoryAsync(int id);
        Task<SalesInvEdit?> GetSalesInventoryByIdForEditAsync(int id);
    }
}