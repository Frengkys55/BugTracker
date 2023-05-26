using System;

namespace Models.Projects;

/// <sumary>
/// Project model for the database
/// </sumary>
public partial class Project{
    public int id {set; get;}
    public Guid Guid {set; get;}
    public string? Name {set; get;}
    public string? AccessToken {set; get;}
    public string? ProjectStatus {set; get;} = "N/A";
    public string? Description {set; get;}
    public DateTime DateCreated {set; get;}
    public DateTime DateModified {set; get;}
    public string? IconUrl {set; get;}
    public string? BackgroundImageUrl {set; get;}

}