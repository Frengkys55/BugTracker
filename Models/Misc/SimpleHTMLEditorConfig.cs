using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Models.Misc{
    public class SimpleHTMLEditorConfig{

        [NotNull]
        [JsonPropertyName("WorkingPanel")]
        public string? WorkingPanel{set; get;}
        [NotNull]
        [JsonPropertyName("W3CSSPath")]
        public string? W3CSSPath {set; get;}
        [NotNull]
        [JsonPropertyName("LineAwesomePath")]
        public string? LineAwesomePath {set; get;}
    }
}