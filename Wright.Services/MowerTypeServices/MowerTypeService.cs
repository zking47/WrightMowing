using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Wright.Data;
using Wright.Data.Entities;
using Wright.Models.MowerTypeModels;

namespace Wright.Services.MowerTypeServices
{
    public class MowerTypeService : IMowerTypeService
    {
        private readonly WrightDbContext _dbContext;
        private readonly IMapper _mapper;

        public MowerTypeService(WrightDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<MowerTypeIndex?> CreateNewMowerTypeAsync(MowerTypeCreate request)
        {
            var mowerTypeEntity = _mapper.Map<MowerTypeCreate, MowerTypeEntity>(request);
            _dbContext.MowerTypes.Add(mowerTypeEntity);
            var numberOfChanges = await _dbContext.SaveChangesAsync();
            if(numberOfChanges == 1)
            {
                MowerTypeIndex response = _mapper.Map<MowerTypeEntity, MowerTypeIndex>(mowerTypeEntity);
                return response;
            }
            return null;
        }

        public async Task<bool> DeleteMowerTypeAsync(int id)
        {
            var mowerType = await _dbContext.MowerTypes.FindAsync(id);

            if(mowerType == null)
                return false;

            _dbContext.MowerTypes.Remove(mowerType);
            return await _dbContext.SaveChangesAsync() == 1;
        }

        public async Task<bool> EditMowerTypeAsync(MowerTypeEdit request)
        {
            var mowerTypeExists = await _dbContext.MowerTypes.AnyAsync(mowerType => mowerType.Id == request.Id);
            if(!mowerTypeExists)
                return false;
            var newMowerType = _mapper.Map<MowerTypeEdit, MowerTypeEntity>(request);
            _dbContext.Entry(newMowerType).State = EntityState.Modified;
            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<List<MowerTypeIndex>> GetAllMowerTypesAsync()
        {
            var mowerTypes = await _dbContext.MowerTypes.Select(entity => _mapper.Map<MowerTypeEntity, MowerTypeIndex>(entity)).ToListAsync();
            return mowerTypes;
        }

        public async Task<MowerTypeDetail?> GetMowerTypeByIdAsync(int id)
        {
            var mowerTypeEntity = await _dbContext.MowerTypes.FirstOrDefaultAsync(e => e.Id == id);
            return mowerTypeEntity is null ? null : _mapper.Map<MowerTypeEntity, MowerTypeDetail>(mowerTypeEntity);
        }

        public async Task<MowerTypeEdit?> GetMowerTypeByIdForEditAsync(int id)
        {
            var mowerTypeEntity = await _dbContext.MowerTypes.FirstOrDefaultAsync(e => e.Id == id);
            return mowerTypeEntity is null ? null : _mapper.Map<MowerTypeEntity, MowerTypeEdit>(mowerTypeEntity);
        }
    }
}