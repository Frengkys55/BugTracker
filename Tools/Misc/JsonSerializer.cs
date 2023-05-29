using System.Text.Json;

namespace Tools.Misc{
    public class JsonSerializer<T>{
        public string Serialize(T data){
            return System.Text.Json.JsonSerializer.Serialize(data);
        }
    }
}