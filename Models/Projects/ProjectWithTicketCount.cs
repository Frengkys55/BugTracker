using System;

namespace Models.Projects;

/// <sumary>
/// Project model for the database
/// </sumary>
public partial class ProjectWithTicketCount : Project {
    public int TicketCount {set; get;}
}