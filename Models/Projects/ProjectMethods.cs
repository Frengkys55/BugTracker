using System;
using Microsoft.Data.Sqlite;

namespace Models.Projects;

public partial class Project{

    /// <sumary>
    /// Get full list of projects
    /// </sumary>
    public Dictionary<Guid, string> GetProjects(){
        throw new NotImplementedException();
    }
    
    /// <sumary>
    /// Get a limited list of project from database
    /// </sumary>
    public Dictionary<Guid, string> GetProjects(int count){
        Dictionary<Guid, string> projectList = new ();
        for(int i = 0; i < count; i++){
            Guid guid = Guid.NewGuid();
            string name = "Project" + i;
            projectList.Add(guid, name);

        }
        return projectList;
    }

    /// <sumary>
    /// Create and store new project to database
    /// </sumary>
    public void CreateProject(Project project){
        // Validate project informations
        if(project.Name == string.Empty || project.Name == null) throw new ArgumentException("Project name should not be empty");

        // Complete additional project information
        if(project.guid == null) project.guid = Guid.NewGuid();
        if(project.DateCreated == null) project.DateCreated = project.DateModified = DateTime.Now;

        throw new NotImplementedException();
    }

    public Project ReadProject(Guid projectGuid){
        throw new NotImplementedException();
    }

    public void UpdateProject(Project project){
        throw new NotImplementedException();
    }

    public void DeleteProject(Guid projectGuid){
        throw new NotImplementedException();
    }

}