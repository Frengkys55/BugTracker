using System.Text.Json;

namespace Tools.Misc{
    public class JsonConverter<T>{
        public T ReadString(string data){
            if(data == null) throw new NullReferenceException("There is no data proviced.");
            try{
                JsonSerializerOptions options = new JsonSerializerOptions();
                options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                options.PropertyNameCaseInsensitive = true;
                return JsonSerializer.Deserialize<T>(data, options);
            }catch(Exception err){
                throw new Exception("Well, things do happen from time to time. BTW the error from the converter, and the error is " + err.Message);
            }
        }
    }
}