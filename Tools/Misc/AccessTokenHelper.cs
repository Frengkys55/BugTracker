namespace Tools.Misc{
    public sealed class AccessTokenHelper{
        private string _accessToken = string.Empty;
        //private string _accessToken = "58d18562-5ed6-4da2-95db-777ab7dd422a";
        public string accessToken { get{
            return _accessToken;
        } private set{
            _accessToken = value;
        }}

        public void SetAccesstoken(string accesstoken){
            _accessToken = accesstoken;
        }
    }


}