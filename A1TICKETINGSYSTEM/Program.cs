namespace A1TICKETINGSYSTEM
{
    public class Program
    {
        static void Main(string[] args)
        {
            string file = "tickets.csv";
            string choice;
            do
            {
                Console.WriteLine("1) READ TICKET SYSTEM");
                Console.WriteLine("2) ADD TICKET");
                Console.WriteLine("ENTER ANY OTHER KEY TO EXIT");
               
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    if (File.Exists(file))
                    {
                        StreamReader sr = new StreamReader(file);
                        sr.ReadLine();
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            Console.WriteLine(line);
                        }
                        sr.Close();
                    }
                    else
                    {
                        Console.WriteLine("FILE DOES NOT EXIST");
                    }
                }
                else if (choice == "2")
                {
                    StreamWriter sw = new StreamWriter(file, true);
                    char response;
                    do
                    {
                        Console.WriteLine("ENTER ANOTHER TICKET (Y/N)?");
                        response = Convert.ToChar(Console.ReadLine().ToUpper());
                        if (response == 'N')
                            break;
                        Console.WriteLine("ENTER TICKET ID: ");
                        string ID = Console.ReadLine();
                        Console.WriteLine("Enter TICKET SUMMARY: ");
                        string SUMMARY = Console.ReadLine();
                        Console.WriteLine("ENTER STATUS (OPEN/CLOSED): ");
                        string STATUS = Console.ReadLine();
                        Console.WriteLine("ENTER PRIORITY LEVEL (LOW/HIGH): ");
                        string PRIORITY = Console.ReadLine();
                        Console.WriteLine("ENTER FULL NAME OF SUBMITTER: ");
                        string SUBMITTER = Console.ReadLine();
                        Console.WriteLine("ENTER FULL NAME OF ASSIGNED: ");
                        string ASSIGNED = Console.ReadLine();
                        char WATCHING;
                        string WATCH;
                        List<string> WATCHER = new List<string>();
                        do
                        {
                            Console.WriteLine("ENTER FULL NAME OF WATCHER? (Y/N?)");
                            WATCHING = Convert.ToChar(Console.ReadLine().ToUpper());
                            if (WATCHING == 'N')
                                break;
                            WATCHER.Add(Console.ReadLine());
                        } while (WATCHING == 'Y');
                        WATCH = string.Join("|", WATCHER);
                        sw.WriteLine($"{ID},{SUMMARY},{STATUS},{PRIORITY},{SUBMITTER},{ASSIGNED},{WATCH}");
                    } while (response == 'Y');
                    sw.Close();
                }
            } while (choice == "1" || choice == "2");
        }
    }
}
