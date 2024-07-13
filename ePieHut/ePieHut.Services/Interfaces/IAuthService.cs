using ePieHut.Entities.Entities;

namespace ePieHut.Services.Interfaces
{
    public interface IAuthService
    {

        bool AddUser(User user, string role);

        UserModel ValidateUser(string EmailId, string Password);


    }
}
