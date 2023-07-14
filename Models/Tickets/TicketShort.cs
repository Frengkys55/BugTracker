using System.Diagnostics.CodeAnalysis;

namespace Models.Tickets{
    public class TicketShortModel{
        
        public Guid Guid {set; get;}
        [NotNull]
        public string? Name {set; get;}
        public DateTime DateCreated {set; get;}
        public DateTime? DateSolved {set; get;}
    }
}