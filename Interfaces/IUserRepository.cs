using MovieDetailsAPI.Models;

namespace MovieDetailsAPI.Interfaces
{
    public interface IUserRepository
    {
        Task<ApplicationUser> RegisterUserAsync(ApplicationUser user, string password);
        Task<ApplicationUser> FindUserByEmailAsync(string email);
    }
}
