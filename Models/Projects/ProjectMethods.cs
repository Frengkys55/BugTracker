using System;
using Microsoft.Data.Sqlite;

namespace Models.Projects;

public partial class Project{
    public IEnumerable<Dictionary<Guid, string>> GetProjects(){
        throw new NotImplementedException();
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