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
            Console.WriteLine("Comment post result: " + result.Content.ReadAsStringAsync());
        }
        catch(Exception err){
            Console.WriteLine(err.Message);
        }
        throw new NotImplementedException();
    }

    public async Task<ICollection<Comment>> GetComments(Guid ticketGuid, string address, string accesstoken){
        throw new NotImplementedException();
    }

    public async Task<int> DeleteComment(Guid commentGuid, string address, string accesstoken){
        throw new NotFiniteNumberException();
    }
}