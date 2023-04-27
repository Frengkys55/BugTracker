using System;

namespace Models.Tickets;

public partial class Severity{
    public int id {set; get;}
    public Guid guid {set; get;}

    /// <sumary>
    /// Name of the severity
    /// </sumary>
    public string? Name {set; get;}

    /// <sumary>
    /// Description about this severity
    /// </sumary>
    public string? Description {set; get;}
}