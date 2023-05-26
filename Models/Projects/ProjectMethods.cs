using System;
using Models.Projects;

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
    public async Task<Dictionary<Guid, string>> GetProjects(){
        string accessToken = "58d18562-5ed6-4da2-95db-777ab7dd422a";
        Tools.APIHelper.GenericGet<List<ProjectShortModel>> genericGet = new ("https://bugtrackerapi.frengkysinaga.com/api/Project/GetProjects");

        List<KeyValuePair<string, string>> headers = new ();
        headers.Add(new KeyValuePair<string, string>("accesstoken", accessToken));
        
        List<ProjectShortModel> projects = await genericGet.Send(headers);

        Dictionary<Guid, string> projectList = new Dictionary<Guid, string>();
        foreach(var project in projects){
            projectList.Add(project.guid, project.name);
        }

        return projectList;
    }
    
    /// <summary>
    /// Get a limited list of project from database
    /// </summary>
    /// <padam name="count">Limit how many project to get</param>
    public async Task<Dictionary<Guid, string>> GetProjects(int count){
        Dictionary<Guid, string> projectList = await GetProjects();
        Dictionary<Guid, string> newProjectList = new ();

        int counter = 0;
        foreach(var project in projectList){
            newProjectList.Add(project.Key, project.Value);
            counter++;
            if(counter >= count) break;
        }

        return newProjectList;
    }

    /// <summary>
    /// Create and store new project to database
    /// </summary>
    /// <param name="project">Project to add to database</param>
    /// <param name="connectionString">Database connectionstring</param>
    /// <param name="targetAddress">Where the API is located</param>
    public async Task<HttpResponseMessage> CreateProject(Project project, string targetAddress){
        // Validate project informations
        if(string.IsNullOrEmpty(project.Name)) throw new ArgumentException("Project name should not be empty");

        // Complete additional project information
        if(project.Guid == null) project.Guid = Guid.NewGuid();
        
        // Override dates
        project.DateCreated = DateTime.Now;
        project.DateModified = DateTime.Now;

        Tools.APIHelper.GenericPost<Project> createProject = new(targetAddress);

        Tools.Misc.AccessTokenHelper accessToken = new Tools.Misc.AccessTokenHelper();

        List<KeyValuePair<string, string>> headers = new();
        headers.Add(new KeyValuePair<string, string>("accesstoken", accessToken.accessToken));

        return await createProject.Send(project, headers);
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