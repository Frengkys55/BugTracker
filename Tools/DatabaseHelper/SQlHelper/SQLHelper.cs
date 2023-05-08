using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;

namespace SqlHelper;
public class ReadData<T>{
    public Collection<T> Read(string connectionString, string sqlQuery){
        Collection<T> data = new();

        if(connectionString == string.Empty){
            throw new Exception("Connection string cannot be empty");
        }

        if(sqlQuery == string.Empty){
            throw new Exception("Damn! You need to give me a command.");
        }
        throw new NotImplementedException("Blazor WebAssembly does not support SQLServer");
        return data;
    }
}

public class WriteData<T>{

    public WriteData(){

    }

    public WriteData(T data, string connectionString){
        throw new NotImplementedException();
    }

    public void Write(T data, string command){
        throw new NotImplementedException();
    }
}