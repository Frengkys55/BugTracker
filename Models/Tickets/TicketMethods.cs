using System;
using System.IO;

namespace Models.Tickets;

public partial class Ticket{
    public IEnumerable<string> GetTickets(){
        throw new NotImplementedException();
    }

    public Ticket GetTicketDetail(string ticketId){
        throw new NotImplementedException();
    }

    public void DeleteTicket(string ticketId){
        throw new NotImplementedException();
    }

    public void UpdateTicket(Ticket ticket){
        throw new NotImplementedException();
    }
}
