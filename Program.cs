// See https://aka.ms/new-console-template for more information
using NLog;

// See https://aka.ms/new-console-template for more information
string path = Directory.GetCurrentDirectory() + "//nlog.config";

// create instance of Logger
var logger = LogManager.LoadConfiguration(path).GetCurrentClassLogger();
string bugFilePath = Directory.GetCurrentDirectory() + "//Bugs.csv";
string enhancementFilePath = Directory.GetCurrentDirectory() + "//Enhancements.csv";
string taskFilePath = Directory.GetCurrentDirectory() + "//Tasks.csv";

logger.Info("Program started");

BugFile bugFile = new BugFile(bugFilePath);
EnhancementFile enhancementFile = new EnhancementFile(enhancementFilePath);
TaskFile taskFile = new TaskFile(taskFilePath);

string choice = "";
string ticketChoice = "";

do
{
    Console.WriteLine("1) Add a ticket");
    Console.WriteLine("2) Display tickets");
    Console.WriteLine("3) Search Tickets");
    Console.WriteLine("Enter to quit");

    choice = Console.ReadLine();

    if (choice == "1")
    {
        Console.Write("bug, enhancement, or task: ");
        ticketChoice = Console.ReadLine();

        if (ticketChoice == "bug")
        {
            Bug bug = new Bug();

            Console.Write("Ticket ID: ");
            bug.ticketID = Console.ReadLine();

            Console.Write("Summary: ");
            bug.summary = Console.ReadLine();

            Console.Write("Status: ");
            bug.status = Console.ReadLine();

            Console.Write("Priority: ");
            bug.priority = Console.ReadLine();

            Console.Write("Submitter: ");
            bug.submitter = Console.ReadLine();

            Console.Write("Assigned: ");
            bug.assigned = Console.ReadLine();

            Console.Write("Watching: ");
            bug.watching = Console.ReadLine();

            Console.Write("Severity: ");
            bug.severity = Console.ReadLine();

            bugFile.AddBug(bug);
        }

        if (ticketChoice == "enhancement")
        {
            Enhancement enhancement = new Enhancement();

            Console.Write("Ticket ID: ");
            enhancement.ticketID = Console.ReadLine();

            Console.Write("Summary: ");
            enhancement.summary = Console.ReadLine();

            Console.Write("Status: ");
            enhancement.status = Console.ReadLine();

            Console.Write("Priority: ");
            enhancement.priority = Console.ReadLine();

            Console.Write("Submitter: ");
            enhancement.submitter = Console.ReadLine();

            Console.Write("Assigned: ");
            enhancement.assigned = Console.ReadLine();

            Console.Write("Watching: ");
            enhancement.watching = Console.ReadLine();

            Console.Write("Software: ");
            enhancement.software = Console.ReadLine();

            Console.Write("Cost: ");
            enhancement.cost = Console.ReadLine();

            Console.Write("Reason: ");
            enhancement.reason = Console.ReadLine();

            Console.Write("Estimate: ");
            enhancement.estimate = Console.ReadLine();

            enhancementFile.AddEnhancement(enhancement);
        }

        if (ticketChoice == "task")
        {
            Task task = new Task();

            Console.Write("Ticket ID: ");
            task.ticketID = Console.ReadLine();

            Console.Write("Summary: ");
            task.summary = Console.ReadLine();

            Console.Write("Status: ");
            task.status = Console.ReadLine();

            Console.Write("Priority: ");
            task.priority = Console.ReadLine();

            Console.Write("Submitter: ");
            task.submitter = Console.ReadLine();

            Console.Write("Assigned: ");
            task.assigned = Console.ReadLine();

            Console.Write("Watching: ");
            task.watching = Console.ReadLine();

            Console.Write("Project Name: ");
            task.projectName = Console.ReadLine();

            Console.Write("Due Date: ");
            task.dueDate = Console.ReadLine();

            taskFile.AddTask(task);
        }
    }

    if (choice == "2")
    {
        Console.WriteLine("Bugs:");
        foreach (Bug b in bugFile.Bugs)
        {
            Console.WriteLine(b.Display());
        }

        Console.WriteLine();

        Console.WriteLine("Enhancements:");
        foreach (Enhancement e in enhancementFile.Enhancements)
        {
            Console.WriteLine(e.Display());
        }

        Console.WriteLine();

        Console.WriteLine("Tasks:");
        foreach (Task t in taskFile.Tasks)
        {
            Console.WriteLine(t.Display());
        }
    }

    if (choice == "3")
    {
        string search = "";
        Console.Write("Press 1 to search by status, 2 to search by priority, 3 to search by submitter: ");
        string ticketType = Console.ReadLine();

        if (ticketType == "1")
        {
            Console.Write("Enter status: ");
            search = Console.ReadLine();

            var bugStatus = bugFile.Bugs.Where(m => m.status.Contains(search)).Select(m => m.status);
            Console.WriteLine($"There are {bugStatus.Count()} bugs with that status.");
            foreach (string t in bugStatus)
            {
                Console.WriteLine($" {t}");
            }

            var enhancementStatus = enhancementFile.Enhancements.Where(m => m.status.Contains(search)).Select(m => m.status);
            Console.WriteLine($"There are {enhancementStatus.Count()} enhancements with that status.");
            foreach (string t in enhancementStatus)
            {
                Console.WriteLine($" {t}");
            }

            var taskStatus = taskFile.Tasks.Where(m => m.status.Contains(search)).Select(m => m.status);
            Console.WriteLine($"There are {taskStatus.Count()} tasks with that status.");
            foreach (string t in taskStatus)
            {
                Console.WriteLine($" {t}");
            }
        }

        else if (ticketType == "2")
        {
            Console.Write("Enter priority: ");
            search = Console.ReadLine();

            var bugPriority = bugFile.Bugs.Where(m => m.priority.Contains(search)).Select(m => m.priority);
            Console.WriteLine($"There are {bugPriority.Count()} bugs with that priority.");
            foreach (string t in bugPriority)
            {
                Console.WriteLine($" {t}");
            }

            var enhancementPriority = enhancementFile.Enhancements.Where(m => m.priority.Contains(search)).Select(m => m.priority);
            Console.WriteLine($"There are {enhancementPriority.Count()} enhancements with that priority.");
            foreach (string t in enhancementPriority)
            {
                Console.WriteLine($" {t}");
            }

            var taskPriority = taskFile.Tasks.Where(m => m.priority.Contains(search)).Select(m => m.priority);
            Console.WriteLine($"There are {taskPriority.Count()} tasks with that priority.");
            foreach (string t in taskPriority)
            {
                Console.WriteLine($" {t}");
            }
        }

        else if (ticketType == "3")
        {
            Console.Write("Enter submitter: ");
            search = Console.ReadLine();

            var bugSubmitter = bugFile.Bugs.Where(m => m.submitter.Contains(search)).Select(m => m.submitter);
            Console.WriteLine($"There are {bugSubmitter.Count()} bugs with that submitter.");
            foreach (string t in bugSubmitter)
            {
                Console.WriteLine($" {t}");
            }

            var enhancementSubmitter = enhancementFile.Enhancements.Where(m => m.submitter.Contains(search)).Select(m => m.submitter);
            Console.WriteLine($"There are {enhancementSubmitter.Count()} enhancements with that submitter.");
            foreach (string t in enhancementSubmitter)
            {
                Console.WriteLine($" {t}");
            }

            var taskSubmitter = taskFile.Tasks.Where(m => m.submitter.Contains(search)).Select(m => m.submitter);
            Console.WriteLine($"There are {taskSubmitter.Count()} tasks with that submitter.");
            foreach (string t in taskSubmitter)
            {
                Console.WriteLine($" {t}");
            }
        }

        else
        {
            Console.WriteLine("Invalid Input");
        }
    }
} while (choice == "1" || choice == "2");

logger.Info("Program ended");
