namespace Models.Comments;

/// <summary>
/// Attachment model for the comment class
/// </summary>
public partial class Attachment{
    /// <summary>
    /// Id of the attachment from database
    /// </summary>
    public int id {set; get;}

    /// <summary>
    /// Guid of the attachment
    /// </summary>
    public Guid guid {set; get;}
    
    /// <summary>
    /// Comment guid this attachment is a part of
    /// </summary>
    public Guid CommentGuid {set; get;}

    /// <summary>
    /// Guid of the attachment type
    /// </summary>
    public Guid TypeGuid {set; get;}

    /// <summary>
    /// Name of the attachment
    /// </summary>
    public string? Name {set; get;}

    /// <summary>
    /// Relative location of the attachment
    /// </summary>
    public string? Location {set; get;}
}