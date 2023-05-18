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
    
    public async Task<HttpResponseMessage> Send(T data){
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri(targetAddress);
        client.DefaultRequestHeaders.Add("Access-Control-Allow-Origin", "*");
        string serializedJson = JsonSerializer.Serialize(data);
        return await client.PostAsync(client.BaseAddress, new StringContent(serializedJson, Encoding.UTF8, "application/json"));
    }

    public async Task<T> GenericGet(string address, List<KeyValuePair<string, string>> headers){

        if (string.IsNullOrEmpty(address)) throw new ArgumentException("Well, I your want me to connect to get some data to you, please give me where should I get this data that you need....");
        using(var client = new HttpClient()){
            client.BaseAddress = new Uri(address);
                    
            if(headers != null){
                foreach(var header in headers){
                    client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }

            HttpResponseMessage message = await client.GetAsync(address);

            if(message.StatusCode == HttpStatusCode.BadRequest) throw new Exception("You've got Bad Request");

            return new Tools.Misc.JsonConverter<T>().ReadString(await message.Content.ReadAsStringAsync());
        }
    }


}