using Models;
using Tools.APIHelper;

namespace Models.Comments;

public partial class Comment{
    public async Task<int> AddComment(Comment comment, string address, string accesstoken){
        var headers = new List<KeyValuePair<string, string>>(){
            new KeyValuePair<string, string>("accesstoken", accesstoken)
        };

        GenericRequest request = new GenericRequest();
        try{
            var result = await request.Send2<Comment>(SendMethod.POST, address, comment, headers);
            Models.ResponseMessage responseMessage = new Tools.Misc.JsonConverter<ResponseMessage>().ReadString(await result.Content.ReadAsStringAsync());
            if(responseMessage.statusCode == 201) return 1;
            else return -1;
        }
        catch(Exception){
            throw;
        }
    }

    public async Task<ICollection<Comment>> GetComments(Guid ticketGuid, string address, string accesstoken){
        var headers = new List<KeyValuePair<string, string>>{
            new KeyValuePair<string, string>("accesstoken", accesstoken),
        };

        try{
            var result = await new Tools.APIHelper.GenericRequest().Send2<DBNull>(SendMethod.GET, address, null, headers);
            return new Tools.Misc.JsonConverter<List<Comment>>().ReadString(await result.Content.ReadAsStringAsync());
        }
        catch(Exception err){
            throw;
        }
    }

    public async Task<int> DeleteComment(Guid commentGuid, string address, string accesstoken){
        var headers = new List<KeyValuePair<string, string>>(){
            new KeyValuePair<string, string>("accesstoken", accesstoken)
        };

        try{
            var result = await new GenericRequest().Send(SendMethod.DELETE, address, headers);
            if(result == 1) return result;
            else return -1;
        }
        catch(Exception){
            throw;
        }
    }
}