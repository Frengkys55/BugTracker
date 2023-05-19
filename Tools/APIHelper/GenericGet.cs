using System.Net;

namespace Tools.APIHelper{
    public class GenericGet<T>{

        Uri address;

        public GenericGet(string address){
            this.address = new Uri(address);
        }

        public async Task<T> Send(List<KeyValuePair<string, string>> headers){

            if(address == null){
                throw new NullReferenceException("Well, you didn't give an address to send this thing of yours to...");
            }

            using(var client = new HttpClient()){
                client.BaseAddress = address;
                        
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
}