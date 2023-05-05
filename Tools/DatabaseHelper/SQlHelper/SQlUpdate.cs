using System.Reflection;
using Microsoft.Data.SqlClient;
using Models;

namespace SqlHelper;

public class UpdateData<T>{

    string connectionString = string.Empty;
    public UpdateData(string connectionString){
        this.connectionString = connectionString;
    }

    public void UpdateUsingProcedures(T data, string procedureName){
        SqlConnection con = new SqlConnection(connectionString);
        con.Open();
        SqlCommand com = new SqlCommand(procedureName, con);
        com.CommandType = System.Data.CommandType.StoredProcedure;
        
        Type type = data.GetType();
        PropertyInfo[] properties = type.GetProperties();
        foreach(var parameter in properties){
            string name = parameter.Name;
            object? value = parameter.GetValue(properties);
            com.Parameters.Add(new SqlParameter("@" + name, value));
        }
        com.ExecuteNonQuery();
    }
}