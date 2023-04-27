using System;

namespace Models.Tickets;

public partial class Comment{

    /// <sumary>
    /// Database ID of the comment
    /// </sumary>
    public int id {set; get;}

    /// <sumary>
    /// Guid of the comment
    /// </sumary>
    public Guid guid {set; get;}

    /// <sumary>
    /// Guid of the ticket this comment is a part of
    /// </sumary>
    public Guid TicketGuid {set; get;}

    /// <sumary>
    /// Guid of the user that send the comment
    /// </sumary>
    public Guid UserGuid {set; get;}

    /// <sumary>
    /// Text of the comment
    /// </sumary>
    public string? CommentText {set; get;}

    /// <sumary>
    /// The date that the comment is published
    /// </sumary>
    public DateTime CommentCreated {set; get;}
}