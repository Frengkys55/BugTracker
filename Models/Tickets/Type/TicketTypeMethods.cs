using System;

namespace Models.Tickets;

public partial class Type{

    /// <summary>
    /// Get list of available ticket types to use
    /// </summary>
    /// <param name="accesstoken"></param>
    /// <param name="address"></param>
    /// <returns></returns>
    public async Task<IEnumerable<Type>> GetAvailableTypes(string accesstoken, string address){
        List<Type> availableTypes = new List<Type>();

        List<KeyValuePair<string, string>> headers = new List<KeyValuePair<string, string>>();
        headers.Add(new KeyValuePair<string, string>("accesstoken", accesstoken));

        try{
            Tools.APIHelper.GenericGet<List<Type>> request = new Tools.APIHelper.GenericGet<List<Type>>(address);
            return await request.Send(headers);
        }
        catch(Exception){
            throw;
        }
    }

    /// <sumary>
    /// Create new ticket type
    /// </sumary>
    public void CreateType(Type type){
        throw new NotImplementedException();
    }

    /// <sumary>
    /// Read ticket type from database
    /// </sumary>
    public Type ReadType(Guid typeGuid){
        throw new NotImplementedException();
    }

    /// <sumary>
    /// Update ticket type
    /// </sumary>
    public void UpdateType(Type type){
        throw new NotImplementedException();
    }

    /// <sumary>
    /// Delete ticket type from database
    /// </sumary>
    public void DeleteType (Guid typeGuid){

        throw new NotImplementedException();
    }
}