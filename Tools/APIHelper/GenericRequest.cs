namespace Tools.APIHelper{
    public class GenericRequest{
        public async Task<int> Send<T>(SendMethod method, string address, T data, ICollection<KeyValuePair<string, string>> headers = null){
            using(var client = new HttpClient()){
                HttpRequestMessage request = new();
                request.Method = new HttpMethod(method.ToString());
                request.Content = new StringContent(new Tools.Misc.JsonSerializer<T>().Serialize(data));
                request.RequestUri = new Uri(address);
                if(request != null){
                    foreach(var header in headers){
                        request.Headers.Add(header.Key, header.Value);
                    }
                }

                try{
                    HttpResponseMessage responseMessage = await client.SendAsync(request);
                    return 1;
                }
                catch(Exception err){
                    throw err;
                }
            }
        }

        public async Task<int> Send(SendMethod method, string address, ICollection<KeyValuePair<string, string>> headers = null){
            using (var client = new HttpClient()){
                HttpRequestMessage request = new();
                request.Method = new HttpMethod(method.ToString());
                request.RequestUri = new Uri(address);
                if(request != null){
                    foreach(var header in headers){
                        request.Headers.Add(header.Key, header.Value);
                    }
                }

                try{
                    HttpResponseMessage responseMessage = await client.SendAsync(request);
                    return 1;
                }
                catch(Exception err){
                    throw err;
                }
            }
        }
    }
}