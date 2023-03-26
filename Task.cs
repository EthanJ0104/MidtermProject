public class Task : Ticket
{
    public string projectName {get; set;}
    public string dueDate {get; set;}

    public Task(string thisTicketID, string thisSummary, string thisStatus, string thisPriority, string thisSubmitter, string thisAssigned, string thisWatching, string thisProjectName, string thisDueDate)
    {
        ticketID = thisTicketID;
        summary = thisSummary;
        status = thisStatus;
        priority = thisPriority;
        submitter = thisSubmitter;
        assigned = thisAssigned;
        watching = thisWatching;
        projectName = thisProjectName;
        dueDate = thisDueDate;
    }

    public override string Display()
    {
        return $"ID: {ticketID}\nSummary: {summary}\nStatus: {status}\nPriority: {priority}\nSubmitter: {submitter}\nAssigned: {assigned}\nWatching: {watching}\nProject Name: {projectName}\nDue Date: {dueDate}\n";
    }
}