using System.Net;
using System.Text;
using System.Text.Json;

namespace Tools.APIHelper;

public class GenericPost<T>{

    string targetAddress = string.Empty;

    public GenericPost(string targetAddress){
        if(string.IsNullOrEmpty(targetAddress)) throw new ArgumentException("Argument couldn't be null or empty string");
        this.targetAddress = targetAddress;
    }
    
    public async Task<HttpResponseMessage> Send(T data, List<KeyValuePair<string, string>> headers){
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri(targetAddress);
        
        // Add headers (if available)
        if(headers != null){
            foreach(var header in headers){
                client.DefaultRequestHeaders.Add(header.Key, header.Value);
            }
        }

        // Serialize data
        string serializedJson = JsonSerializer.Serialize(data);

        HttpResponseMessage receivedMessage = await client.PostAsync(client.BaseAddress, new StringContent(serializedJson, Encoding.UTF8, "application/json"));

        return receivedMessage;
    }

    


}