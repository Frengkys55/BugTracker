using System;
using System.IO;

namespace Models.Tickets;

public partial class Ticket{
    public Dictionary<Guid, string> GetTickets(){
        Dictionary<Guid, string> tickets = new Dictionary<Guid, string>();

        for(int i = 0; i < 5; i++){
            tickets.Add(Guid.NewGuid(), "Ticket " + i);
        }

        return tickets;
    }

    /**
    **/
    public Dictionary<Guid, string> GetTickets(Guid projectGuid){
        Dictionary<Guid, string> tickets = new Dictionary<Guid, string>();

        for(int i = 0; i < 5; i++){
            tickets.Add(Guid.NewGuid(), "Ticket " + i);
        }

        return tickets;
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
