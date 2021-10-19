using LoginAPI.Models;

namespace LoginAPI.Services
{
    public interface ITokenService
    {

        public string CreateToken(UserDTO userDTO);
    }
}