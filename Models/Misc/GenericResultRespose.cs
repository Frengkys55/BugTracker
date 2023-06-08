namespace Models{

    /// <summary>
    /// Use this class for an enpoint that for some reason 
    /// returning the data you need inside the "result" JSON object
    /// </summary>
    /// <typeparam name="T">Your desired object</typeparam>
    public class ResultResponse<T>{
        public T? Result {set; get;}
    }
}