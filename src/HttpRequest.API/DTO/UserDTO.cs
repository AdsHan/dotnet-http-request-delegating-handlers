namespace HttpRequest.API.DTO;

public class UserDTO
{
    public string Gender { get; set; }
    public string Name { get; set; }

    public static List<UserDTO> ToUserDTO(Response user)
    {
        return user.Results.Select(x => new UserDTO()
        {
            Gender = x.Gender,
            Name = string.Concat(x.Name.First, x.Name.Last)
        }).ToList();
    }

}