using HttpRequest.API.Integration.Services;
using Microsoft.AspNetCore.Mvc;

namespace HttpRequest.API.Controllers;

[Produces("application/json")]
[Route("api/users")]
[ApiController]
public class UserController : ControllerBase
{

    // GET api/user/
    /// <summary>
    /// Obtém os usuários
    /// </summary>   
    /// <returns>Lista de Usuários</returns>                
    /// <response code="200">Sucesso</response>           
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get([FromServices] IUserService service)
    {
        var result = await service.GetAllUsers();

        return Ok(result);
    }

}
