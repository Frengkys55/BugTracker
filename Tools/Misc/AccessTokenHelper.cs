namespace Tools.Misc{
    public sealed class AccessTokenHelper{
        private string _accessToken = string.Empty;
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