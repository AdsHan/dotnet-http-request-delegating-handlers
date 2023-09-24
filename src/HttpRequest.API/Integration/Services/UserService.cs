using HttpRequest.API.DTO;
using HttpRequest.API.Handlers;
using System.Net.Http.Headers;

namespace HttpRequest.API.Integration.Services;
public class UserService : BaseHttpService, IUserService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public UserService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _httpClient.BaseAddress = new Uri(_configuration.GetSection("Apis")["RandomUser"]);
    }

    public async Task<List<UserDTO>> GetAllUsers()
    {
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        var response = await _httpClient.GetAsync($"api/?results=10&nat=br");

        if (!HandleErrorResponse(response))
        {
            return null;
        }

        var result = await DeserializarObjectResponse<Response>(response);

        return UserDTO.ToUserDTO(result);
    }

}
