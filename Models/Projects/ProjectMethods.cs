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

    public async Task<Project> GetProject(Guid projectGuid, string accesstoken, string address){
        List<KeyValuePair<string, string>> headers = new List<KeyValuePair<string, string>>();
        headers.Add(new KeyValuePair<string, string>("accesstoken", accesstoken));

        try{
            var result = await new Tools.APIHelper.GenericGet<Project>(address).Send(headers);
            return result;
        }
        catch(Exception){
            throw;
        }
    }

    /// <summary>
    /// Get full list of projects
    /// </summary>
    public async Task<ICollection<ProjectShortModel>> GetProjects(string address, string accesstoken){
        string accessToken = accesstoken;
        Tools.APIHelper.GenericGet<List<ProjectShortModel>> genericGet = new (address);

        List<KeyValuePair<string, string>> headers = new ();
        headers.Add(new KeyValuePair<string, string>("accesstoken", accessToken));
        
        return await genericGet.Send(headers);
    }
    
    /// <summary>
    /// Get a limited list of project from database
    /// </summary>
    /// <padam name="count">Limit how many project to get</param>
    public async Task<ICollection<ProjectShortModel>> GetProjects(string address, string accesstoken, int count){
        var projectList = await GetProjects(address, accesstoken);

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
            throw new Exception("Well, the backend is secured. How should I access those backend if you didn't give me something that those backend accepted.");

        string newAddress = (address.EndsWith("/")) ? address + projectGuid : address + "/" + projectGuid;
        var request = new Tools.APIHelper.GenericGet<Models.ResultResponse<Project>>(newAddress);

        List<KeyValuePair<string, string>> headers = new();
        headers.Add(new KeyValuePair<string, string>("accesstoken", accesstoken));
        try{
            var receivedData = await request.Send(headers);
            return receivedData.Result;
        }
        catch(Exception){
            throw;
        }
    }

    /// <summary>
    /// Method to update existing project (You need to fill AccessToken propetry for this to work)
    /// </summary>
    /// <param name="project">Project object to update using project.guid as a reference</param>
    public async Task UpdateProject(Project project, string address){
        if(project == null)
            throw new NullReferenceException("Here is an error for you because you gave me something stupid to do.");

        Tools.APIHelper.GenericRequest request = new Tools.APIHelper.GenericRequest();
        try{
            HttpResponseMessage response = await new Tools.APIHelper.GenericRequest().Send2<Project>(Tools.APIHelper.SendMethod.PUT, address, project);
            if(response.StatusCode == System.Net.HttpStatusCode.OK ||
               response.StatusCode == System.Net.HttpStatusCode.NoContent ||
               response.StatusCode == System.Net.HttpStatusCode.Created){
                return;
            }
            else
                throw new HttpRequestException("Project update failed");
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


    public async Task<Projects.ProjectWithTicketCount> GetProjectWithTheMostTicket(string accesstoken, string address){
        List<KeyValuePair<string, string>> headers = new List<KeyValuePair<string, string>>();
        headers.Add(new KeyValuePair<string, string>("accesstoken", accesstoken));

        var request = new Tools.APIHelper.GenericGet<ProjectWithTicketCount>(address);

        try{
            var result = await request.Send(headers);
            return result;
        }
        catch(Exception){
            throw;            
        }
    }
}