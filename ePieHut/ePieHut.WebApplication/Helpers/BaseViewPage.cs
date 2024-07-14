using Microsoft.AspNetCore.Mvc.Razor;

namespace ePieHut.WebApplication.Helpers
{
    public abstract class BaseViewPage<TModel> : RazorPage<TModel>
    {

        public UserModel CurrentUser
        {
            get
            {
                if (Context.User.Identity.IsAuthenticated)
                {
                    var strData = Context.User.FindFirst(System.Security.Claims.ClaimTypes.UserData).Value;
                    var user = System.Text.Json.JsonSerializer.Deserialize<UserModel>(strData);
                    return user;
                }
                return null;
            }
        }



    }
}
