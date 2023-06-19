namespace Tools.Misc{
    public sealed class AccessTokenHelper{
        private string _accessToken = string.Empty;
        public string accessToken { get{
            return _accessToken;
        } private set{
            _accessToken = value;
        }}

        public EventHandler<string> AccesstokenChangedEventHanler {get; set;}

        public void SetAccesstoken(string accesstoken){
            _accessToken = accesstoken;
            try{
                OnAccesstokenChanged();
            }
            catch{
                
            }
        }

        private void OnAccesstokenChanged(){
            if(AccesstokenChangedEventHanler.GetInvocationList().Count() > 0){
                AccesstokenChangedEventHanler.Invoke(this, accessToken);
            }
        }
    }
}