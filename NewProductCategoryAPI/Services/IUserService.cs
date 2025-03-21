using NewProductCategoryAPI.DTOs;
using NewProductCategoryAPI.Models;

namespace NewProductCategoryAPI.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> AddUserAsync(UserDTO userDto);
        Task<User> UpdateUserAsync(int id, UserDTO userDto);
        Task<bool> DeleteUserAsync(int id);
    }
}
