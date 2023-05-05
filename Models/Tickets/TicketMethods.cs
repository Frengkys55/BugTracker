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

    /// <summary>
    /// Get all tickets for certain project
    /// </summary>
    /// <param name="projectGuid">Project GUID to use as a reference</param>
    public Dictionary<Guid, string> GetTickets(Guid projectGuid){
        Dictionary<Guid, string> tickets = new Dictionary<Guid, string>();

        for(int i = 0; i < 5; i++){
            tickets.Add(Guid.NewGuid(), "Ticket " + i);
        }

        return tickets;
    }

    public Dictionary<Guid, string> GetTickets(Guid projectGuid, int maxTicketCount){
        Dictionary<Guid, string> tickets = new Dictionary<Guid, string>();

        for(int i = 0; i < maxTicketCount; i++){
            tickets.Add(Guid.NewGuid(), "Ticket " + i);
        }

        return tickets;
    }


    public int GetTicketCount(Guid projectGuid){
        return new Random().Next(2, 1000);
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
