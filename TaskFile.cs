using NLog;

public class TaskFile
{
    public string filePath { get; set; }
    public List<Task> Tasks { get; set; }
    private static NLog.Logger logger = LogManager.LoadConfiguration(Directory.GetCurrentDirectory() + "//nlog.config").GetCurrentClassLogger();

    public TaskFile(string taskFilePath)
    {
        filePath = taskFilePath;
        Tasks = new List<Task>();

        try
        {
            StreamReader sr = new StreamReader(filePath);
            while (!sr.EndOfStream)
            {
                Task task = new Task();
                string line = sr.ReadLine();

                string[] taskDetails = line.Split(',');
                task.ticketID = taskDetails[0];
                task.summary = taskDetails[1];
                task.status = taskDetails[2];
                task.priority = taskDetails[3];
                task.submitter = taskDetails[4];
                task.assigned = taskDetails[5];
                task.watching = taskDetails[6];
                task.projectName = taskDetails[7];
                task.dueDate = taskDetails[8];

                Tasks.Add(task);
            }
            
            sr.Close();
            logger.Info("Tasks in file {Count}", Tasks.Count);
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message);
        }
    }

    public void AddTask(Task task)
    {
        try
        {
            StreamWriter sw = new StreamWriter(filePath, true);
            
            sw.WriteLine($"{task.ticketID}, {task.summary}, {task.status}, {task.priority}, {task.submitter}, {task.assigned}, {task.watching}, {task.projectName}, {task.dueDate}");
            sw.Close();
            
            Tasks.Add(task);
            
            logger.Info("Task id {Id} added", task.ticketID);
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message);
        }
    }
}
