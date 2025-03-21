using NewProductCategoryAPI.DTOs;
using NewProductCategoryAPI.Models;

namespace NewProductCategoryAPI.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task<Category> AddCategoryAsync(CategoryDTO categoryDto);
        Task<Category> UpdateCategoryAsync(int id, CategoryDTO categoryDto);
        Task<bool> DeleteCategoryAsync(int id);
    }
}
