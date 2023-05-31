using System;
using System.IO;

namespace Models.Tickets;
/// <summary>
/// Ticket model
/// </summary>
public partial class Ticket{

    /// <summary>
    /// Method for getting list of tickets
    /// </summary>
    /// <returns>Dictionary of ticket name and guid</returns>
    public Dictionary<Guid, string> GetTickets(string accesstoken, string address){
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
    /// <returns>Dictionary of tickets assosiated with the specified GUID</returns>
    public Dictionary<Guid, string> GetTickets(Guid projectGuid, string accesstoken){
        Dictionary<Guid, string> tickets = new Dictionary<Guid, string>();

        for(int i = 0; i < 5; i++){
            tickets.Add(Guid.NewGuid(), "Ticket " + i);
        }
        return tickets;
    }

    /// <summary>
    /// Get all tickets for certain project with specific count
    /// </summary>
    /// <param name="projectGuid">GUID of the project to list the tickets</param>
    /// <param name="maxTicketCount">Maximum number of ticket returned</param>
    /// <returns>Dictionary of tickets assosiated with the specified GUID with spesific length</returns>
    public async Task<Dictionary<Guid, string>> GetTicketsAsync(Guid projectGuid, int maxTicketCount, string accesstoken, string address){
        Dictionary<Guid, string> tickets = new Dictionary<Guid, string>();

        Tools.APIHelper.GenericGet<List<Ticket>> request = new Tools.APIHelper.GenericGet<List<Ticket>>(address);
        List<KeyValuePair<string, string>> headers = new();
        headers.Add(new KeyValuePair<string, string>(accesstoken, accesstoken));

        List<Ticket> receivedTickets = await request.Send(headers);

        foreach(Ticket ticket in receivedTickets){
            tickets.Add(ticket.guid, ticket.Name);
        }
        
        return tickets;
    }

    /// <summary>
    /// Get how many ticket are there for the specific project
    /// </summary>
    /// <param name="projectGuid">GUID of the project</param>
    /// <returns></returns>
    public int GetTicketCount(Guid projectGuid){
        return new Random().Next(2, 1000);
    }

    /// <summary>
    /// Get detail of a specific ticket
    /// </summary>
    /// <param name="ticketGuid">GUID of the ticket to get a detailed list from</param>
    /// <returns></returns>
    public Ticket GetTicketDetail(Guid ticketGuid){
        throw new NotImplementedException();
    }

    /// <summary>
    /// Delete spesified ticket
    /// </summary>
    /// <param name="ticketGuid">GUID of the ticket to be deleted</param>
    public void DeleteTicket(Guid ticketGuid){
        throw new NotImplementedException();
    }

    /// <summary>
    /// Update ticket information
    /// </summary>
    /// <param name="ticket">Ticket information to be updated</param>
    public void UpdateTicket(Ticket ticket){
        throw new NotImplementedException();
    }
}
