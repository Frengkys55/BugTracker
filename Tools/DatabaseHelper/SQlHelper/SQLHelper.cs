using Microsoft.Data.SqlClient;
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

        SqlConnection con = new SqlConnection(connectionString);
        con.Open();
        SqlCommand com = new SqlCommand(sqlQuery, con);
        
        try{
            SqlDataReader reader = com.ExecuteReader();
            if(reader != null){
                while(reader.Read()){
                    // Create new instance of the target object
                    object obj = Activator.CreateInstance(typeof(T));
                    Type type = obj.GetType(); // Get object information
                    PropertyInfo[] properties = type.GetProperties();
                    for(int i = 0; i < properties.Length; i++){
                        string name = properties[i].Name;
                        object? value = null;
                        try{
                            value = reader[name];
                        }
                        catch{
                            value = null;
                        }
                        properties[i].SetValue(obj, value);
                    }
                    data.Add((T)obj);
                }
            }
            if(reader != null){
                reader.Close();
                reader.DisposeAsync();
            } 
        }
        catch(Exception){
            throw;
        }
        finally{
            con.Close();
            com.DisposeAsync();
            con.DisposeAsync();
        }
        return data;
    }
}

public class WriteData<T>{

    public WriteData(){

    }

    public WriteData(T data, string connectionString){
        throw new NotImplementedException();
    }

    public void Write(T data, SqlCommand command){
        throw new NotImplementedException();
    }
}