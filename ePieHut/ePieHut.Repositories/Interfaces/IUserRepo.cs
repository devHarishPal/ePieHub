using ePieHut.Entities.Entities;
using ePieHut.Models;
namespace ePieHut.Repositories.Interfaces
{
    public interface IUserRepo : IRepository<User>
    {

        bool AddUser(User user,string role);

        UserModel ValidateUser(string EmailId, string Password);



    }
}
