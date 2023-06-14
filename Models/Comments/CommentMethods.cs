using Models;

namespace Models.Comments;

public partial class Comment{
    public async Task<int> AddComment(Comment comment, string address, string accesstoken){
        throw new NotImplementedException();
    }

    public async Task<ICollection<Comment>> GetComments(Guid ticketGuid, string address, string accesstoken){
        throw new NotImplementedException();
    }

    public async Task<int> DeleteComment(Guid commentGuid, string address, string accesstoken){
        throw new NotFiniteNumberException();
    }
}