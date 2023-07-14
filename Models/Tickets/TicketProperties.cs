using System;
using System.IO;

namespace Models.Tickets;

/// @brief Class for ticket
/// 
///
using System.Diagnostics.CodeAnalysis;

public partial class Ticket{
    [NotNull]
    public int id {set; get;}
    public Guid guid {set; get;}
    public string? Project{set; get;}
    public Guid UserGuid {set; get;}
    [NotNull]
    public string? Name {set; get;}
    [NotNull]
    public string? Description {set; get;}

    [NotNull]
    public DateTime? DateCreated {set; get;}
    public DateTime? DateModified {set; get;}
    public DateTime? DateSolved {set; get;}
    public string? Severity {set; get;}
    public string? Type {set; get;}
}