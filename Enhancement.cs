public class Enhancement : Ticket
{
    public string software {get; set;}
    public string cost {get; set;}
    public string reason {get; set;}
    public string estimate {get; set;}

    // public Enhancement(string thisTicketID, string thisSummary, string thisStatus, string thisPriority, string thisSubmitter, string thisAssigned, string thisWatching, string thisSoftware, string thisCost, string thisReason, string thisEstimate)
    // {
    //     ticketID = thisTicketID;
    //     summary = thisSummary;
    //     status = thisStatus;
    //     priority = thisPriority;
    //     submitter = thisSubmitter;
    //     assigned = thisAssigned;
    //     watching = thisWatching;
    //     software = thisSoftware;
    //     cost = thisCost;
    //     reason = thisReason;
    //     estimate = thisEstimate;
    // }

    public override string Display()
    {
        return $"ID: {ticketID}\nSummary: {summary}\nStatus: {status}\nPriority: {priority}\nSubmitter: {submitter}\nAssigned: {assigned}\nWatching: {watching}\nSoftware: {software}\nCost: {cost}\nReason: {reason}\nEstimate{estimate}\n";
    }
}
