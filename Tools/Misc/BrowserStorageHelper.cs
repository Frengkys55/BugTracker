using Blazored.LocalStorage;
using Tools.Misc;

namespace Tools.Misc{
    public sealed class LocalStorageHelper{
        private ILocalStorageService _storageService;
        private AccessTokenHelper _accesstokenHelper;
        public LocalStorageHelper(ILocalStorageService storageService, AccessTokenHelper accesstokenHelper){
            this._storageService = storageService;
            this._accesstokenHelper = accesstokenHelper;
            _accesstokenHelper.AccesstokenChangedEventHanler += AccesstokenChanged;
            TryGetAccesstoken();
        }

        private async Task TryGetAccesstoken(){
            Console.WriteLine("Hello from trygetaccesstoken");
            try{
                var result = await _storageService.GetItemAsStringAsync("accesstoken");
                result = result.Replace("\"", "");
                if(!string.IsNullOrEmpty(result))
                    _accesstokenHelper.SetAccesstoken(result);
            }
            catch(Exception){
                
            }
        }

        protected async void AccesstokenChanged(object sender, string e){
            await _storageService.SetItemAsync<string>("accesstoken", _accesstokenHelper.accessToken.Replace("\"", ""));
        }
    }
}