using HttpRequest.API.DTO;

namespace HttpRequest.API.Integration.Services;

public interface IUserService
{
    Task<List<UserDTO>> GetAllUsers();
}