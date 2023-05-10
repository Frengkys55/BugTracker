using System.Text;
using System.Text.Json;

namespace Tools.APIHelper;

public class GenericPost<T>{

    string targetAddress = string.Empty;

    public GenericPost(string targetAddress){
        if(string.IsNullOrEmpty(targetAddress)) throw new ArgumentException("Argument couldn't be null or empty string");
        this.targetAddress = targetAddress;
    }
    
    public async Task<HttpResponseMessage> Send(T data){
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri(targetAddress);
        client.DefaultRequestHeaders.Add("Access-Control-Allow-Origin", "*");
        string serializedJson = JsonSerializer.Serialize(data);
        return await client.PostAsync(client.BaseAddress, new StringContent(serializedJson, Encoding.UTF8, "application/json"));
    }
}