using MovieDetailsAPI.Models;

namespace MovieDetailsAPI.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(ApplicationUser user);

    }
}
