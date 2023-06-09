public abstract class Ticket
{
    public string ticketID {get; set;}
    public string summary {get; set;}
    public string status {get; set;}
    public string priority {get; set;}
    public string submitter {get; set;}
    public string assigned {get; set;}
    public string watching {get; set;}

    // public Ticket()
    // {

    // }

    public virtual string Display()
    {
        return $"Id: {ticketID}\nSummary: {summary}\nStatus: {status}\nPriority: {priority}\nSubmitter: {submitter}\nAssigned: {assigned}\nWatching: {watching}\n";
    }
}
