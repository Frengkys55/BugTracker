using System;
using System.IO;
using Models.Authentications;

namespace Models.Users;

public partial class User{

    /// <summary>
    /// Register new user
    /// </summary>
    /// <param name="user">Minimal user information to be registered (should be hashed already)</param>
    public async Task<int> CreateUser(UserRegisterModel user, string address){
        Tools.APIHelper.GenericRequest request = new Tools.APIHelper.GenericRequest();
        try{
            Console.WriteLine("Create user triggered");
            var result = await request.Send2<UserRegisterModel>(Tools.APIHelper.SendMethod.POST, address, user, null);
            var response = new Tools.Misc.JsonConverter<Models.ResponseMessage>().ReadString(await result.Content.ReadAsStringAsync());
            if(response.statusCode == 201)
                return 1;
            else
                return -1;
        }
        catch(Exception err){
            Console.WriteLine(err.Message);
            return -1;
        }
    }

    public User ReadUserDetail(string accesstoken, string address){
        throw new NotImplementedException();
    }

    /// @brief Method to update user information
    public void UpdateUser(User user, string accesstoken, string address){
        throw new NotImplementedException();
    }

    public void Authenticate(Guid usetGuid){
        throw new NotImplementedException();
    }
}
