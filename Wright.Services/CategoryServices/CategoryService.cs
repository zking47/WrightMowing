using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Wright.Data;
using Wright.Data.Entities;
using Wright.Models.CategoryModels;

namespace Wright.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly WrightDbContext _dbContext;
        private readonly IMapper _mapper;

        public CategoryService(WrightDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CategoryIndex?> CreateNewCategoryAsync(CategoryCreate request)
        {
            var categoryEntity = _mapper.Map<CategoryCreate, CategoryEntity>(request);
            _dbContext.Categories.Add(categoryEntity);
            var numberOfChanges = await _dbContext.SaveChangesAsync();
            if(numberOfChanges == 1)
            {
                CategoryIndex response = _mapper.Map<CategoryEntity, CategoryIndex>(categoryEntity);
                return response;
            }
            return null;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await _dbContext.Categories.FindAsync(id);

            if(category == null)
                return false;

            _dbContext.Categories.Remove(category);
            return await _dbContext.SaveChangesAsync() == 1;
        }

        public async Task<bool> EditCategoryAsync(CategoryEdit request)
        {
            var categoryExists = await _dbContext.Categories.AnyAsync(category => category.Id == request.Id);
            if(!categoryExists)
                return false;
            var newCategory = _mapper.Map<CategoryEdit, CategoryEntity>(request);
            _dbContext.Entry(newCategory).State = EntityState.Modified;
            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<List<CategoryIndex>> GetAllCategoriesAsync()
        {
            var categories = await _dbContext.Categories.Select(entity => _mapper.Map<CategoryEntity, CategoryIndex>(entity)).ToListAsync();
            return categories;
        }

        public async Task<CategoryDetail?> GetCategoryByIdAsync(int id)
        {
            var categoryEntity = await _dbContext.Categories.FirstOrDefaultAsync(e => e.Id == id);
            return categoryEntity is null ? null : _mapper.Map<CategoryEntity, CategoryDetail>(categoryEntity);
        }

        public async Task<CategoryEdit?> GetCategoryByIdForEditAsync(int id)
        {
            var categoryEntity = await _dbContext.Categories.FirstOrDefaultAsync(e => e.Id == id);
            return categoryEntity is null ? null : _mapper.Map<CategoryEntity, CategoryEdit>(categoryEntity);
        }
    }
}