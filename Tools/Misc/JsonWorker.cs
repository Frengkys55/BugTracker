using System.Text.Json;

namespace Tools.Misc{
    public class JsonConverter<T>{
        public T ReadString(string data){
            if(data == null) throw new NullReferenceException("There is no data proviced.");

            try{
                return JsonSerializer.Deserialize<T>(data);
            }catch(Exception err){
                throw new Exception("Well, things do happen from time to time. BTW its happening on the converter, so it might have something to do with your data");
            }
        }
    }
}