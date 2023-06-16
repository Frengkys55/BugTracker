using System.Security.Cryptography;
using System.Text;

namespace Tools.Misc{
    public class Hash{
        public string SHA512(string input){
            string result = string.Empty;
            using(var sha512 = System.Security.Cryptography.SHA512.Create()){
                result = Convert.ToBase64String(sha512.ComputeHash(Encoding.UTF8.GetBytes(input)));
            }
            return result;
        }
    }
}