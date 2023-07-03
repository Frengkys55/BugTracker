using System;
using System.IO;

namespace Models.Tickets;
/// <summary>
/// Ticket model
/// </summary>
public partial class Ticket{

    #region Ticket reading

    /// <summary>
    /// Method for getting list of tickets
    /// </summary>
    /// <returns>Dictionary of ticket name and guid</returns>
    public async Task<ICollection<TicketShortModel>> GetAllTicketsAsync(string accesstoken, string address){
        Dictionary<Guid, string> tickets = new Dictionary<Guid, string>();

        Tools.APIHelper.GenericGet<List<TicketShortModel>> request = new Tools.APIHelper.GenericGet<List<TicketShortModel>>(address);
        List<KeyValuePair<string, string>> headers = new ();
        headers.Add(new KeyValuePair<string, string>("accesstoken", accesstoken));

        try{
            return await request.Send(headers);
        }
        catch(Exception){
            throw;
        }
    }

    /// <summary>
    /// Get list of tickets from a certain project
    /// </summary>
    /// <param name="projectGuid">Project guid to use as a reference</param>
    /// <param name="accesstoken">Your access token</param>
    /// <param name="address">The endpoint to use</param>
    /// <returns></returns>
    public async Task<IEnumerable<TicketShortModel>> GetProjectTickets(Guid projectGuid, string accesstoken, string address){
        Dictionary<Guid, string> tickets = new Dictionary<Guid, string>();

        Tools.APIHelper.GenericGet<List<TicketShortModel>> ticketList = new Tools.APIHelper.GenericGet<List<TicketShortModel>>(address);

        List<KeyValuePair<string, string>> headers = new();
        headers.Add(new KeyValuePair<string, string>("accesstoken", accesstoken));
        try{
            return await ticketList.Send(headers);
        }
        catch(Exception)
        {
            throw;
        }
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
    public async Task<Ticket> GetTicketDetail(Guid ticketGuid, string accesstoken, string address){
        Tools.APIHelper.GenericGet<Ticket> genericGet = new Tools.APIHelper.GenericGet<Ticket>(address);
        List<KeyValuePair<string, string>> headers = new();
        headers.Add(new KeyValuePair<string, string>("accesstoken", accesstoken));

        var result = await genericGet.Send(headers);
        return result;
    }

    public async Task<Ticket> GetLongestUnsolvedTicket(string accesstoken, string address){
        Tools.APIHelper.GenericGet<Ticket> helper = new Tools.APIHelper.GenericGet<Ticket>(address);
        List<KeyValuePair<string, string>> headers = new ();
        headers.Add(new KeyValuePair<string, string>("accesstoken", accesstoken));

        try{
            return await helper.Send(headers);
        }
        catch(Exception){
            throw;
        }
    }

    public async Task<Ticket> GetLongestUnsolvedTickets(string accesstoken, string address){
        Tools.APIHelper.GenericGet<Ticket> helper = new Tools.APIHelper.GenericGet<Ticket>(address);
        List<KeyValuePair<string, string>> headers = new ();
        headers.Add(new KeyValuePair<string, string>("accesstoken", accesstoken));
        try{
            return await helper.Send(headers);
        }
        catch(Exception){
            throw;
        }
    }

    public async Task<ICollection<TicketShortModel>> GetSolvedTickets(string accesstoken, string address){
        if(string.IsNullOrEmpty(accesstoken) || string.IsNullOrEmpty(address)){
            throw new ArgumentException("Are you kidding me...");
        }

        List<KeyValuePair<string, string>> headers = new List<KeyValuePair<string, string>>();
        headers.Add(new KeyValuePair<string, string>("accesstoken", accesstoken));

        try{
            var result = await new Tools.APIHelper.GenericRequest().Send2<TicketShortModel>(Tools.APIHelper.SendMethod.GET, address, null, headers);
            return new Tools.Misc.JsonConverter<List<TicketShortModel>>().ReadString(await result.Content.ReadAsStringAsync());
        }
        catch(Exception err){
            throw;
        }

    }

    #endregion Ticket reading

    /// <summary>
    /// Delete spesified ticket
    /// </summary>
    /// <param name="ticketGuid">GUID of the ticket to be deleted</param>
    public async Task DeleteTicket(Guid ticketGuid, string accesstoken, string address){
        List<KeyValuePair<string, string>> headers = new List<KeyValuePair<string, string>>();
        headers.Add(new KeyValuePair<string, string>("accesstoken", accesstoken));

        try{
            var result = await new Tools.APIHelper.GenericRequest().Send(Tools.APIHelper.SendMethod.DELETE, address, headers);
            if(result == -1)
                throw new Exception("Error deleting ticket");
        }
        catch(Exception){
            throw;
        }
    }

    /// <summary>
    /// Update ticket information
    /// </summary>
    /// <param name="ticket">Ticket information to be updated</param>
    public async Task UpdateTicket(Ticket ticket, string accesstoken, string address){
        
        List<KeyValuePair<string, string>> headers = new List<KeyValuePair<string, string>>();
        headers.Add(new KeyValuePair<string, string>("accesstoken", accesstoken));

        try{
            Tools.APIHelper.GenericRequest request = new Tools.APIHelper.GenericRequest();
            HttpResponseMessage result = await request.Send2<Ticket>(Tools.APIHelper.SendMethod.PUT, address, ticket, headers);

            var message = new Tools.Misc.JsonConverter<Models.ResponseMessage>().ReadString(await result.Content.ReadAsStringAsync());
        }
        catch(Exception){
            throw;
        }
    }

    /// <summary>
    /// Add ticket to project
    /// </summary>
    /// <param name="ticket">Ticket to add</param>
    /// <param name="accesstoken">User's access token</param>
    /// <param name="address">Address to send the request to</param>
    /// <returns></returns>
    public async Task AddTicket(Ticket ticket, string accesstoken, string address){

        List<KeyValuePair<string, string>> headers = new List<KeyValuePair<string, string>>();
        headers.Add(new KeyValuePair<string, string>("accesstoken", accesstoken));

        try{
            Tools.APIHelper.GenericRequest request = new Tools.APIHelper.GenericRequest();
            HttpResponseMessage result = await request.Send2<Ticket>(Tools.APIHelper.SendMethod.POST, address, ticket, headers);

            var message = new Tools.Misc.JsonConverter<Models.ResponseMessage>().ReadString(await result.Content.ReadAsStringAsync());
        }
        catch(Exception){
            throw;
        }
    }

    /// <summary>
    /// Mark ticket as solved
    /// </summary>
    /// <param name="TicketGuid">Ticket's Guid to mark</param>
    /// <param name="accesstoken">User's access token</param>
    /// <param name="address">Address to send the request to</param>
    /// <returns>Return TRUE if executed succesfully and FALSE when not.</returns>
    public async Task<bool> MarkTicketSolved(Guid TicketGuid, string accesstoken, string address){
        List<KeyValuePair<string, string>> headers = new List<KeyValuePair<string, string>>();
        headers.Add(new KeyValuePair<string, string>("accesstoken", accesstoken));
        try{
            var result = await new Tools.APIHelper.GenericRequest().Send2<object>(Tools.APIHelper.SendMethod.GET, address, null, headers);
            if(result.StatusCode == System.Net.HttpStatusCode.OK){
                return true;
            }
            else{
                return false;
            }
        }
        catch(Exception){
            return false;
        }
    }
}
