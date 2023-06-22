namespace Tools.APIHelper{
    public class GenericRequest{

        public async Task<int> Send(SendMethod method, string address, ICollection<KeyValuePair<string, string>> headers = null){
            System.Console.WriteLine("Method: " + method.ToString());
            System.Console.WriteLine("Address: " + address);
            System.Console.WriteLine("Headers: " + headers.ToList());
            using (var client = new HttpClient()){
                HttpRequestMessage request = new HttpRequestMessage();
                request.Method = new HttpMethod(method.ToString());
                request.RequestUri = new Uri(address);
                if(request != null){
                    foreach(var header in headers){
                        request.Headers.Add(header.Key, header.Value);
                    }
                }
                
                try{
                    HttpResponseMessage responseMessage = await client.SendAsync(request);
                    if(responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
                        return 1;
                    else
                        return -1;
                }
                catch(Exception){
                    throw;
                }
            }
        }

        /// <summary>
        /// Generic send method with data the data of T to the target endpoint
        /// </summary>
        /// <param name="method">Method to use (GET, POST, etc)</param>
        /// <param name="address">Address to send the request</param>
        /// <param name="data">Data to include in the request body (set to null if there is no data to be included in the body)</param>
        /// <param name="headers">Additional headers to include in the request</param>
        /// <typeparam name="T">Your object type to send</typeparam>
        /// <returns></returns>
        public async Task<HttpResponseMessage> Send2<T>(SendMethod method, string address, T data = default, ICollection<KeyValuePair<string, string>> headers = null){
            using(var client = new HttpClient()){
                HttpRequestMessage request = new HttpRequestMessage(new HttpMethod(method.ToString()), address);

                if(data != null){
                    string serializedData = new Tools.Misc.JsonSerializer<T>().Serialize(data);
                    
                    request.Content = new StringContent(serializedData, new System.Net.Http.Headers.MediaTypeHeaderValue("application/json"));
                }

                if(headers != null){
                    foreach(var header in headers){
                        request.Headers.Add(header.Key, header.Value);
                    }
                }

                try{
                    return await client.SendAsync(request);
                }
                catch(Exception err){
                    throw new Exception("Sending error: " + err.Message);
                }
            }
        }

        
    }
}