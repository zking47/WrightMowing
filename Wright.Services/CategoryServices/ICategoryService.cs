using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wright.Models.CategoryModels;

namespace Wright.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<CategoryIndex?> CreateNewCategoryAsync(CategoryCreate request);
        Task<List<CategoryIndex>> GetAllCategoriesAsync();
        Task<CategoryDetail?> GetCategoryByIdAsync(int id); 
        Task<bool> EditCategoryAsync(CategoryEdit request);
        Task<bool> DeleteCategoryAsync(int id);
        Task<CategoryEdit?> GetCategoryByIdForEditAsync(int id);
    }
}