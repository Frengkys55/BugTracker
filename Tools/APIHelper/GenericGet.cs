using System.Net;

namespace Tools.APIHelper{

    /// <summary>
    /// Generic class for sending GET requests
    /// </summary>
    /// <typeparam name="T">Your class model object</typeparam>
    public class GenericGet<T>{
        Uri address;

        public GenericGet(string address){
            this.address = new Uri(address);
        }

        /// <summary>
        /// Send GET request to a server
        /// </summary>
        /// <param name="headers">Additional headers that you want to add</param>
        /// <returns>Your specified T object</returns>
        public async Task<T> Send(List<KeyValuePair<string, string>> headers){

            if(address == null)
                throw new NullReferenceException("Well, you didn't give an address to send this thing of yours to...");

            using(var client = new HttpClient()){
                client.BaseAddress = address;
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                if(headers != null){
                    foreach(var header in headers){
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }
                try{
                    var message = await client.GetAsync(address);
                    if(message.StatusCode == HttpStatusCode.BadRequest) throw new Exception("You've got Bad Request");
                    return new Tools.Misc.JsonConverter<T>().ReadString(await message.Content.ReadAsStringAsync());
                }
                catch(Exception err){
                    throw;
                }
            }
        }
    }
}