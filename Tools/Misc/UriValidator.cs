using System.Text.RegularExpressions;

namespace Tools.Misc{
    public static class UriValidator{
        /// <summary>
        /// Static class to validate urls (from stackoverflow)
        /// </summary>
        /// <param name="URL">string to check</param>
        /// <returns>Return True if it's valid and false if it's not</returns>
        public static bool IsValidURL(string URL)
        {
            string Pattern = @"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$";
            Regex Rgx = new Regex(Pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return Rgx.IsMatch(URL);
        }
    }
}