using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Wright.Data;
using Wright.Data.Entities;
using Wright.Models.SalesInventoryModels;

namespace Wright.Services.SalesInventoryServices
{
    public class SalesInventoryService : ISalesInventoryService
    {
        private readonly WrightDbContext _dbContext;
        private readonly IMapper _mapper;

        public SalesInventoryService(WrightDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<SalesInvIndex?> CreateNewSalesInventoryAsync(SalesInvCreate request)
        {
            var salesInventoryEntity = _mapper.Map<SalesInvCreate, SalesInventoryEntity>(request);
            _dbContext.SalesInventoryEntities.Add(salesInventoryEntity);
            var numberOfChanges = await _dbContext.SaveChangesAsync();
            if(numberOfChanges == 1)
            {
                SalesInvIndex response = _mapper.Map<SalesInventoryEntity, SalesInvIndex>(salesInventoryEntity);
                return response;
            }
            return null;
        }

        public async Task<bool> DeleteSalesInventoryAsync(int id)
        {
            var salesInventory = await _dbContext.SalesInventoryEntities.FindAsync(id);

            if(salesInventory == null)
                return false;

            _dbContext.SalesInventoryEntities.Remove(salesInventory);
            return await _dbContext.SaveChangesAsync() == 1;
        }

        public async Task<bool> EditSalesInventoryAsync(SalesInvEdit request)
        {
            var salesInventoryExists = await _dbContext.SalesInventoryEntities.AnyAsync(salesInventory => salesInventory.Id == request.Id);
            if(!salesInventoryExists)
                return false;
            var newSalesInventory = _mapper.Map<SalesInvEdit, SalesInventoryEntity>(request);
            _dbContext.Entry(newSalesInventory).State = EntityState.Modified;
            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<List<SalesInvIndex>> GetAllSalesInventoriesAsync()
        {
            var salesInventories = await _dbContext.SalesInventoryEntities.Select(entity => _mapper.Map<SalesInventoryEntity, SalesInvIndex>(entity)).ToListAsync();
            return salesInventories;
        }

        public async Task<SalesInvDetail?> GetSalesInventoryByIdAsync(int id)
        {
            var salesInventoryEntity = await _dbContext.SalesInventoryEntities.FirstOrDefaultAsync(e => e.Id == id);
            return salesInventoryEntity is null ? null : _mapper.Map<SalesInventoryEntity, SalesInvDetail>(salesInventoryEntity);
        }

        public async Task<SalesInvEdit?> GetSalesInventoryByIdForEditAsync(int id)
        {
            var salesInventoryEntity = await _dbContext.SalesInventoryEntities.FirstOrDefaultAsync(e => e.Id == id);
            return salesInventoryEntity is null ? null : _mapper.Map<SalesInventoryEntity, SalesInvEdit>(salesInventoryEntity);
        }
    }
}