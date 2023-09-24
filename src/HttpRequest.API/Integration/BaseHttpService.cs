using System.Net;
using System.Text.Json;

namespace HttpRequest.API.Handlers;

public abstract class BaseHttpService
{
    protected async Task<T> DeserializarObjectResponse<T>(HttpResponseMessage responseMessage)
    {
        return JsonSerializer.Deserialize<T>(options: new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        }, json: await responseMessage.Content.ReadAsStringAsync());
    }

    protected bool HandleErrorResponse(HttpResponseMessage response)
    {
        if (response.StatusCode == HttpStatusCode.BadRequest)
        {
            return false;
        }

        response.EnsureSuccessStatusCode();

        return true;
    }
}