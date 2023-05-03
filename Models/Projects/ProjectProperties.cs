using System;

namespace Models.Projects;

/// <sumary>
/// Project model for the database
/// </sumary>
public partial class Project{
    public int id {set; get;}
    public Guid guid {set; get;}
    public string? Name {set; get;}
    public Guid UserGuid {set; get;}
    public Guid ProjectStatusGuid {set; get;}
    public string? Description {set; get;}
    public DateTime DateCreated {set; get;}
    public DateTime DateModified {set; get;}
    public string? ProjectImage {set; get;}
}