using NLog;

public class BugFile
{
    public string filePath { get; set; }
    public List<Bug> Bugs { get; set; }
    private static NLog.Logger logger = LogManager.LoadConfiguration(Directory.GetCurrentDirectory() + "//nlog.config").GetCurrentClassLogger();

    public BugFile(string bugFilePath)
    {
        filePath = bugFilePath;
        Bugs = new List<Bug>();

        try
        {
            StreamReader sr = new StreamReader(filePath);
            while (!sr.EndOfStream)
            {
                Bug bug = new Bug();
                string line = sr.ReadLine();

                string[] bugDetails = line.Split(',');
                bug.ticketID = bugDetails[0];
                bug.summary = bugDetails[1];
                bug.status = bugDetails[2];
                bug.priority = bugDetails[3];
                bug.submitter = bugDetails[4];
                bug.assigned = bugDetails[5];
                bug.watching = bugDetails[6];
                bug.severity = bugDetails[7];

                Bugs.Add(bug);
            }
            
            sr.Close();
            logger.Info("Bugs in file {Count}", Bugs.Count);
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message);
        }
    }

    public void AddBug(Bug bug)
    {
        try
        {
            StreamWriter sw = new StreamWriter(filePath, true);
            
            sw.WriteLine($"{bug.ticketID}, {bug.summary}, {bug.status}, {bug.priority}, {bug.submitter}, {bug.assigned}, {bug.watching}, {bug.severity}");
            sw.Close();
            
            Bugs.Add(bug);
            
            logger.Info("Bug id {Id} added", bug.ticketID);
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message);
        }
    }
}
