using System;

namespace Models.Projects;

public partial class Project{
    private string connectionString = string.Empty;

    /// <summary>
    /// Define new project object
    /// </summary>
    public Project(){
    }

    /// <summary>
    /// Define new object with connection string
    /// </summary>
    /// <param name="connectionString">Database connection string</param>
    public Project(string connectionString){
        this.connectionString = connectionString;
    }


    /// <summary>
    /// Get full list of projects
    /// </summary>
    public Dictionary<Guid, string> GetProjects(){
        throw new NotImplementedException();
    }
    
    /// <summary>
    /// Get a limited list of project from database
    /// </summary>
    /// <padam name="count">Limit how many project to get</param>
    public Dictionary<Guid, string> GetProjects(int count){
        Dictionary<Guid, string> projectList = new ();
        for(int i = 0; i < count; i++){
            Guid guid = Guid.NewGuid();
            string name = "Project" + i;
            projectList.Add(guid, name);
        }
        return projectList;
    }

    /// <summary>
    /// Create and store new project to database
    /// </summary>
    /// <param name="project">Project to add to database</param>
    public int CreateProject(Project project, string connectionString){
        // Validate project informations
        if(project.Name == string.Empty || project.Name == null) throw new ArgumentException("Project name should not be empty");
        if(connectionString == string.Empty) throw new Exception("Connection string is empty");

        // Complete additional project information
        if(project.guid == null) project.guid = Guid.NewGuid();
        if(project.DateCreated == null) project.DateCreated = project.DateModified = DateTime.Now;
        #region Create project

        string sqlQuery = "CreateProject";
        int result = -1;
        try{
            throw new NotImplementedException("Blazor WebAssembly does not support SQLServer");
        }catch(Exception err){
            throw new Exception("Updating project to database failed. " + err.Message);
        }
        #endregion Create project

        return result;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Read a project from database
    /// </summary>
    /// <param name="projectGuid">Project GUID to use as a reference for reading from database</param>
    public Project ReadProject(Guid projectGuid){
        SqlHelper.ReadData<Project> helper = new();
        string sqlQuery = "SELECT * FROM PROJECT WHERE ProjectGuid='" + projectGuid + "';";

        Project project = helper.Read(connectionString, sqlQuery)[0];

        return project;
    }

    /// <summary>
    /// Method to update existing project
    /// </summary>
    /// <param name="project">Project object to update using project.guid as a reference</param>
    public void UpdateProject(Project project){

        throw new NotImplementedException();
    }

    public void DeleteProject(Guid projectGuid){
        throw new NotImplementedException();
    }

}