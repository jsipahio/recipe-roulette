using System.Net.Http.Headers;
using RecipeRoulette.Data.Access;
using RecipeRoulette.Data.Models;

namespace RecipeRoulette.Pages
{
    public partial class Login
    {
        private UserManager _userMgr;

        private UserModel _user;
        string message = " ";

        public Login()
        {
            _userMgr = new UserManager();
            _user = new UserModel();
        }

        private void LoginUser()
        {
            bool success = _userMgr.FindUser(_user);
            if (success)
            {
                message = "Logged in successfully";
                _nav.NavigateTo("/");
            }
            else
            {
                message = "Wrong email/password";
            }
        }
    }
}