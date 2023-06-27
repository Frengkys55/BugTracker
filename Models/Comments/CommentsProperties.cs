using Models;

namespace Models.Comments;

public partial class Comment{
    public Guid guid {set; get;}
    public Guid TicketGuid {set; get;}
    public string? CommentText {set; get;}

    public DateTime? DateCreated {set; get;}
}