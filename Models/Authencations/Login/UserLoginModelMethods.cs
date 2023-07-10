using System.Security.Cryptography;
using System.Text;
using Tools.Misc;
using Models.Authentications;

namespace Models.Authentications{
    public partial class UserLoginModel{
        private readonly AccessTokenHelper _accesstokenHelper;
        public UserLoginModel(AccessTokenHelper _accesstokenHelper){
            this._accesstokenHelper = _accesstokenHelper;
        }
        public UserLoginModel(){
            
        }

        /// <summary>
        /// Authenticate user
        /// </summary>
        /// <param name="user">User's login information</param>
        /// <param name="address">Address to send this request to</param>
        /// <returns>User's accesstoken</returns>
        public async Task<string> Login(UserLoginModel user, string address){
            UserLoginModel hashedUser = new UserLoginModel(){
                UserName = new Tools.Misc.Hash().SHA512(user.UserName!),
                password = new Tools.Misc.Hash().SHA512(user.password!)
            };

            // Send user login information and get accesstoken
            try{
                var result = await new Tools.APIHelper.GenericRequest().Send2<UserLoginModel>(Tools.APIHelper.SendMethod.POST, address, hashedUser);
                return await result.Content.ReadAsStringAsync();
            }
            catch(Exception err){
                Console.WriteLine(err.Message);
                return string.Empty;
            }
        }
        public bool CheckLogin(string accesstoken){
            throw new NotImplementedException();
        }
        
        public async Task<bool> Logout(string accesstoken, string address){
            List<KeyValuePair<string, string>> headers = new List<KeyValuePair<string, string>>();
            headers.Add(new KeyValuePair<string, string>("accesstoken", accesstoken));

            try{
                var result = await new Tools.APIHelper.GenericRequest().Send(Tools.APIHelper.SendMethod.GET, address, headers);
                _accesstokenHelper.SetAccesstoken(string.Empty);
                return true;
            }
            catch(Exception err){
                Console.WriteLine(err.Message);
                return false;
            }
        }
    
        public async Task<string> LoginAsGuest(string address){
            try{
                var result = await new Tools.APIHelper.GenericRequest().Send2<object>(Tools.APIHelper.SendMethod.GET, address);
                return await result.Content.ReadAsStringAsync();
            }
            catch(Exception){
                throw;
            }
        }
    }
}