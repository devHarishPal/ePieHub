using ePieHut.Entities.Entities;
using ePieHut.Repositories.Interfaces;
using ePieHut.Services.Interfaces;


namespace ePieHut.Services.Implementations
{
    public class AuthService : Services<User>, IAuthService
    {

        private readonly IUserRepo userRepo;
        public AuthService(IUserRepo _repo) : base(_repo)
        {
            userRepo = _repo;


        }

        public bool AddUser(User user, string role)
        {
           return userRepo.AddUser(user, role);
        }

        public UserModel ValidateUser(string EmailId, string Password)
        {
            throw new NotImplementedException();
        }
    }
}
