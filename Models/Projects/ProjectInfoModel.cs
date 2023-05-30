using System.Diagnostics.CodeAnalysis;
using Models;
using Models.Tickets;

namespace Models.Projects;

public class ProjectModel{
    [NotNull]
    public Project? project {set; get;}
    public List<Ticket>? tickets {set; get;}
}