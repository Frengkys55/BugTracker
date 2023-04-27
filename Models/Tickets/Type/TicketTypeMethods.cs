using System;

namespace Models.Tickets;

public partial class Type{

    /// <sumary>
    /// Get a list of available types from database (guid and name)
    /// </sumary>
    public Dictionary<Guid, string> GetTypes(){
        throw new NotImplementedException();
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