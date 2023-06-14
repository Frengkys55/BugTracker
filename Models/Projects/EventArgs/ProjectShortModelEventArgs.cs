using System.Diagnostics.CodeAnalysis;

namespace Models.Projects{
    public class ProjectShortEventArgs : EventArgs{
        [NotNull]
        public string? guid {set; get;}
        [NotNull]
        public string? Name {set; get;}
    }
}