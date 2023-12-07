using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wright.Models.MowerTypeModels;

namespace Wright.Services.MowerTypeServices
{
    public interface IMowerTypeService
    {
        Task<MowerTypeIndex?> CreateNewMowerTypeAsync(MowerTypeCreate request);
        Task<List<MowerTypeIndex>> GetAllMowerTypesAsync();
        Task<MowerTypeDetail?> GetMowerTypeByIdAsync(int id); 
        Task<bool> EditMowerTypeAsync(MowerTypeEdit request);
        Task<bool> DeleteMowerTypeAsync(int id);
        Task<MowerTypeEdit?> GetMowerTypeByIdForEditAsync(int id);
    }
}