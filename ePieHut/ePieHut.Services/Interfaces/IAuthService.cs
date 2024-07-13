using ePieHut.Entities.Entities;

namespace ePieHut.Services.Interfaces
{
    public interface IAuthService : IServices<User>
    {

        bool AddUser(User user, string role);

        UserModel ValidateUser(string EmailId, string Password);


    }
}
