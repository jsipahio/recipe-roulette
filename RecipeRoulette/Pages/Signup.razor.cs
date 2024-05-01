using System.Net.Http.Headers;
using RecipeRoulette.Data.Access;
using RecipeRoulette.Data.Models;

namespace RecipeRoulette.Pages
{
    public partial class Signup
    {
        private UserManager _userMgr;

        private UserModel _user;

        public Signup()
        {
            _userMgr = new UserManager();
            _user = new UserModel();
        }

        private void SignupUser()
        {
            _userMgr.AddUser(_user);
        }
    }
}