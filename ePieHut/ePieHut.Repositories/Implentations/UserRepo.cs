using ePieHut.Entities;
using ePieHut.Entities.Entities;
using ePieHut.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace ePieHut.Repositories.Implentations
{

    public class UserRepo : Repository<User>, IUserRepo
    {
        public UserRepo(AppDbContext Context) : base(Context)
        {
        }

        public bool AddUser(User user, string Role)
        {
            Role role = context.Roles.Where(user => user.Name == Role).FirstOrDefault();

            try
            {

                if (role != null)
                {
                    user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                    user.Roles.Add(role);
                    context.Users.Add(user);

                    context.SaveChanges();

                    return true;

                }

            }
            catch (Exception ex)
            {

                throw ex;


            }


            return false;







        }





        public UserModel ValidateUser(string Email, string Password)
        {
            User user = context.Users.Include(u => u.Roles).Where(u => u.Email == Email).FirstOrDefault();

            if (user != null)
            {
             

                bool isValid = BCrypt.Net.BCrypt.Verify(Password, user.Password);
                if (isValid)
                {
                    UserModel userModel = new UserModel
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        Roles = user.Roles.Select(r => r.Name).ToArray()
                    };
                    return userModel;
                }
            }
            return null;
        }
    }
}
