using System;
using System.Collections.ObjectModel;
using System.Text;
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
    public async Task<ICollection<ProjectShortModel>> GetProjects(){
        string accessToken = "58d18562-5ed6-4da2-95db-777ab7dd422a";
        Tools.APIHelper.GenericGet<List<ProjectShortModel>> genericGet = new ("https://bugtrackerapi.frengkysinaga.com/api/Project/GetProjects");

        List<KeyValuePair<string, string>> headers = new ();
        headers.Add(new KeyValuePair<string, string>("accesstoken", accessToken));
        
        return await genericGet.Send(headers);
    }
    
    /// <summary>
    /// Get a limited list of project from database
    /// </summary>
    /// <padam name="count">Limit how many project to get</param>
    public async Task<ICollection<ProjectShortModel>> GetProjects(int count){
        var projectList = await GetProjects();

        Collection<ProjectShortModel> newProjectList = new();

        int counter = 0;
        foreach(var project in projectList){
            newProjectList.Add(project);
            counter++;
            if(counter > count) break;
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
        if(project.Guid == Guid.Empty) project.Guid = Guid.NewGuid();

        Tools.APIHelper.GenericPost<Project> createProject = new(targetAddress);

        Tools.Misc.AccessTokenHelper accessToken = new Tools.Misc.AccessTokenHelper();

        List<KeyValuePair<string, string>> headers = new();
        headers.Add(new KeyValuePair<string, string>("accesstoken", accessToken.accessToken));

        try{
            return await createProject.Send(project, headers);
        }
        catch(Exception){
            throw;
        }
    }

    /// <summary>
    /// Read a project from database
    /// </summary>
    /// <param name="projectGuid">Project GUID to use as a reference for reading from database</param>
    public async Task<Project> ReadProject(Guid projectGuid, string address, string accesstoken){
        if(projectGuid == Guid.Empty)
            throw new Exception("For reading the project, I need the GUID.");
        if(string.IsNullOrEmpty(accesstoken))
            throw new Exception("Well, the backend is secured. How should I access if those backend if there you didn't give me something that those backend accespted.");

        string newAddress = (address.EndsWith("/")) ? address + projectGuid : address + "/" + projectGuid;
        System.Console.WriteLine(newAddress);
        Tools.APIHelper.GenericGet<Project> request = new Tools.APIHelper.GenericGet<Project>(newAddress);

        List<KeyValuePair<string, string>> headers = new();
        headers.Add(new KeyValuePair<string, string>("accesstoken", accesstoken));
        return await request.Send(headers);
    }

    /// <summary>
    /// Method to update existing project (You need to fill AccessToken propetry for this to work)
    /// </summary>
    /// <param name="project">Project object to update using project.guid as a reference</param>
    public async Task UpdateProject(Project project, string address){
        if(project == null)
            throw new NullReferenceException("Here is an error for you because you give me something onreasonable to do.");
        
        Tools.APIHelper.GenericRequest request = new Tools.APIHelper.GenericRequest();
        try{
            int result = await request.Send2<Project>(Tools.APIHelper.SendMethod.PUT, address, project);
        }
        catch(Exception){
            throw;
        }
    }

    /// <summary>
    /// Delete project from database
    /// </summary>
    /// <param name="projectGuid">Guid of the project to delete</param>
    /// <param name="address">API endpoint to send this request</param>
    /// <param name="accesstoken">Your access token</param>
    /// <returns></returns>
    public async Task DeleteProject(Guid projectGuid, string address, string accesstoken){
        if(projectGuid == Guid.Empty)
            throw new Exception("Guid is required to perform deletion");
        if(accesstoken == string.Empty)
            throw new Exception("Access token is empty");

        try{
            Tools.APIHelper.GenericRequest delete = new();
            List<KeyValuePair<string, string>> headers = new List<KeyValuePair<string, string>>();
            headers.Add(new KeyValuePair<string, string>("accesstoken", accesstoken));
            int result = await delete.Send(Tools.APIHelper.SendMethod.DELETE, address + "/" + projectGuid.ToString(), headers);
        }
        catch(Exception){
            throw;
        }
    }

}