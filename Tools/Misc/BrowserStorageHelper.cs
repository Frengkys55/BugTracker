using System.Diagnostics;
using Blazored.LocalStorage;
using Tools.Misc;

namespace Tools.Misc{
    public sealed class LocalStorageHelper{
        private ILocalStorageService _storageService;

        public LocalStorageHelper(ILocalStorageService storageService /*, AccessTokenHelper accesstokenHelper*/){
            this._storageService = storageService;
        }

        public async Task<string> TryGetAccesstoken(){
            try{
                var result = await _storageService.GetItemAsStringAsync("accesstoken");
                result = result.Replace("\"", "");
                return result;
            }
            catch(Exception){
                throw;
            }
        }

        public async void AccesstokenChanged(object sender, string e){
            await _storageService.SetItemAsync<string>("accesstoken", e.Replace("\"", ""));
        }
    }
}