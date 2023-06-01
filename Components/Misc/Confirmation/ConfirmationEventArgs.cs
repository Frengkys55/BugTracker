using System.Diagnostics.CodeAnalysis;

namespace Components.Misc.Confirmation
{
    public class ConfirmationEventArgs : EventArgs
    {
        [NotNull]
        public string? Name { set; get; }
        public string? Guid { set; get; }
    }
}