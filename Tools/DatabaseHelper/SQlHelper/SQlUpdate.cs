using System.Reflection;
using Models;

namespace SqlHelper;

public class UpdateData<T>{

    string connectionString = string.Empty;
    public UpdateData(string connectionString){
        this.connectionString = connectionString;
    }

    public void UpdateUsingProcedures(T data, string procedureName){
        throw new NotImplementedException("Blazor WebAssembly does not support SQLServer");
    }
}