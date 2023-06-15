using System.Security.Cryptography;
using System.Text;
using Tools.Misc;

namespace Models{
    public partial class UserLoginModel{
        private readonly AccessTokenHelper _accesstokenHelper;
        public UserLoginModel(AccessTokenHelper _accesstokenHelper){
            this._accesstokenHelper = _accesstokenHelper;
        }

        public string Login(UserLoginModel user){
            // Hash username and password
            string hashedUsername;
            string hashedPassword;

            var sha512 = SHA512.Create();
            hashedUsername = Convert.ToBase64String(sha512.ComputeHash(Encoding.UTF8.GetBytes(user.UserName)));
            hashedPassword = Convert.ToBase64String(sha512.ComputeHash(Encoding.UTF8.GetBytes(user.password)));
            Console.WriteLine(hashedPassword);
            Console.WriteLine(hashedUsername);

            return "58d18562-5ed6-4da2-95db-777ab7dd422a";
        }
        public bool CheckLogin(string accesstoken){
            throw new NotImplementedException();
        }
        
        public bool Logout(string accesstoken){
            _accesstokenHelper.SetAccesstoken(string.Empty);
            return true;
        }
    }
}