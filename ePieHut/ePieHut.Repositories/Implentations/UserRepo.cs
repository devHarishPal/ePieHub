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

        public UserModel ValidateUser(string EmailId, string Password)
        {
            User user = context.Users.Include(role => role.Roles).Where(user=>user.Email.Equals(EmailId)).FirstOrDefault();

            if (user != null)
            {
                bool IsValid = BCrypt.Net.BCrypt.Verify(Password, user.Password);

                if (IsValid)
                {
                    UserModel User = new UserModel()
                    {
                        Id = user.Id,
                        Name = user.Name,
                        PhoneNumber = user.PhoneNumber,
                        Email = user.Email,
                        Roles = user.Roles.Select(Role => Role.Name).ToArray()
                    };


                    return User;




                }


            }

            return null;



        }
    }
}
