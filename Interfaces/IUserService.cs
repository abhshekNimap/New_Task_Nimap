using MovieDetailsAPI.DTOs;

namespace MovieDetailsAPI.Interfaces
{
    public interface IUserService
    {
        Task<string> RegisterUserAsync(UserRegisterDTO userRegisterDTO);
        Task<string> LoginUserAsync(UserLoginDTO userLoginDTO);
    }
}
