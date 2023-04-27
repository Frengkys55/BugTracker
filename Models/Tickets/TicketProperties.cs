using System;
using System.IO;

namespace Models.Tickets;

/// @brief Class for ticket
/// 
///
public partial class Ticket{
    public int id {set; get;}
    public Guid guid {set; get;}
    public Guid ProjectGuid{set; get;}
    public Guid UserGuid {set; get;}
    public string? Name {set; get;}
    public string? Description {set; get;}
    public DateTime DateCreated {set; get;}
    public DateTime DateModified {set; get;}
    public Guid SeverityGuid {set; get;}
    public Guid TypeGuid {set; get;}
}

