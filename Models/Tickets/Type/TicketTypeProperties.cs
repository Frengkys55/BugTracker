using System;

namespace Models.Tickets;

public partial class Type{

    /// <sumary>
    /// Database ID of the type
    /// </sumary>
    public int id {set; get;}

    /// <sumary>
    /// Guid of the type
    /// </sumary>
    public Guid guid {set; get;}

    /// <sumary>
    /// Name of the type
    /// </sumary>
    public string? Title {set; get;}

    /// <sumary>
    /// Description of the type
    /// </sumary>
    public string? Description {set; get;}
}