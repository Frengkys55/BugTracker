using Blazored.LocalStorage;

namespace Tools.Misc{
    public sealed class AccessTokenHelper{
        private readonly LocalStorageHelper _localStorageHelper;
        private string _accessToken = string.Empty;
        private bool isFirstTime = true;
        public string accessToken { get{
            return _accessToken;
        } private set{
            _accessToken = value;
        }}

        public AccessTokenHelper(){
            // Default constructor
        }

        public AccessTokenHelper(LocalStorageHelper localStorageHelper){
            _localStorageHelper = localStorageHelper;
            if(string.IsNullOrEmpty(_accessToken)){
                try{
                    AccesstokenChangedEventHanler += localStorageHelper.AccesstokenChanged;
                    ReadLocalStorageAsync();
                }
                catch(Exception err){
                    Console.WriteLine(err.Message);
                }
            }
        }

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
    
        public async Task ReadLocalStorageAsync(){
            string oldData = _accessToken;
            _accessToken = await _localStorageHelper.TryGetAccesstoken();
            if(oldData != _accessToken){
                OnAccesstokenChanged();
            }
        }
    }
}