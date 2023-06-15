using System.Security.Cryptography;
using System.Text;
using Tools.Misc;

namespace Models{
    public partial class UserLoginModel{
        private readonly AccessTokenHelper _accesstokenHelper;
        public UserLoginModel(AccessTokenHelper _accesstokenHelper){
            this._accesstokenHelper = _accesstokenHelper;
        }
        public UserLoginModel(){

        }

        public async Task<string> Login(UserLoginModel user, string address){
            // Hash username and password
            string hashedUsername;
            string hashedPassword;

            var sha512 = SHA512.Create();
            hashedUsername = Convert.ToBase64String(sha512.ComputeHash(Encoding.UTF8.GetBytes(user.UserName)));
            hashedPassword = Convert.ToBase64String(sha512.ComputeHash(Encoding.UTF8.GetBytes(user.password)));

            // Send user login information and get accesstoken
            try{
                var result = await new Tools.APIHelper.GenericRequest().Send2<UserLoginModel>(Tools.APIHelper.SendMethod.POST, address, user);
            }
            catch(Exception){
                throw;
            }

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