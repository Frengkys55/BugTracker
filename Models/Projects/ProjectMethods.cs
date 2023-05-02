using System;
using Microsoft.Data.Sqlite;

namespace Models.Projects;

public partial class Project{

    public Dictionary<Guid, string> GetProjects(){
        throw new NotImplementedException();
    }
    
    public Dictionary<Guid, string> GetProjects(int count){
        Dictionary<Guid, string> projectList = new ();
        for(int i = 0; i < count; i++){
            Guid guid = Guid.NewGuid();
            string name = "Project" + i;
            projectList.Add(guid, name);

        }
        return projectList;
    }

    public void CreateProject(Project project){
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