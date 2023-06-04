using System;

namespace Models.Tickets;

public partial class Severity{

    public async Task<List<Severity>> GetAvailableSeverities(string accesstoken, string address){
        
        List<KeyValuePair<string, string>> headers = new List<KeyValuePair<string, string>>();
        headers.Add(new KeyValuePair<string, string>("accesstoken", accesstoken));

        try{
            return await new Tools.APIHelper.GenericGet<List<Severity>>(address).Send(headers);
        }
        catch(Exception){
            throw;
        }
    }

    public void CreateSeverity(Severity severity){
        throw new NotImplementedException();
    }

    public Severity ReadSeverity(Guid severityId){
        throw new NotImplementedException();
    }

    public void UpdateSeverity (Severity severity){
        throw new NotImplementedException();
    }

    public void DeleteSeverity(Guid severityId){
        throw new NotImplementedException();
    }

}