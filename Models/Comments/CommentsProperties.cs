using Models;

namespace Models.Comments;

public partial class Comment{
    public string? id {set; get;}
    public Guid guid {set; get;}
    public Guid TicketGuid {set; get;}
    public Guid UserGuid {set; get;}
    public string? CommentText {set; get;}
    public Comments.Attachment? Attachment {set; get;}
}