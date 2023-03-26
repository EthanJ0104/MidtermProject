public class Bug : Ticket
{
    public string severity {get; set;}
    // public Bug(string thisTicketID, string thisSummary, string thisStatus, string thisPriority, string thisSubmitter, string thisAssigned, string thisWatching, string thisSeverity)
    // {
    //     ticketID = thisTicketID;
    //     summary = thisSummary;
    //     status = thisStatus;
    //     priority = thisPriority;
    //     submitter = thisSubmitter;
    //     assigned = thisAssigned;
    //     watching = thisWatching;
    //     severity = thisSeverity;
    // }
    public override string Display()
    {
        return $"ID: {ticketID}\nSummary: {summary}\nStatus: {status}\nPriority: {priority}\nSubmitter: {submitter}\nAssigned: {assigned}\nWatching: {watching}\nSeverity: {severity}\n";
    }
}
