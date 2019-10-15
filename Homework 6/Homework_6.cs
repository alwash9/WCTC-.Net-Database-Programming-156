using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Homework_6
{
    class Homework_6
    {

        //Prompt for input for properties of tickets
        public static string[] PromptAspects(string code)
        {

            Console.WriteLine("\nSummary?");
            string summary = Console.ReadLine();
            Console.WriteLine("\nStatus?");
            string status = Console.ReadLine();
            Console.WriteLine("\nPriority?");
            string priority = Console.ReadLine();
            Console.WriteLine("\nSubmitter?");
            string submitter = Console.ReadLine();
            Console.WriteLine("\nAssigned?");
            string assigned = Console.ReadLine();
            Console.WriteLine("\nWatching?");
            string watching = Console.ReadLine();

            if (code == "TS")
            {
                Console.WriteLine("\nSeverity?");
                string severity = Console.ReadLine();
                string[] aspects =
                {
                    summary,
                    status,
                    priority,
                    submitter,
                    assigned,
                    watching,
                    severity
                };
                return aspects;
            }
            else if (code == "TK")
            {
                Console.WriteLine("\nProject Name?");
                string projectName = Console.ReadLine();
                Console.WriteLine("\nHow many days after today will the ticket be due? For default (5 days) enter \"5\" or any non-number character");

                //due date will default to five days after ticket creation
                int days = 5;
                Int32.TryParse(Console.ReadLine(), out days);

                DateTime dueDate = DateTime.Now.AddDays(days);

                if (dueDate.DayOfWeek == DayOfWeek.Saturday)
                {
                    dueDate.AddDays(2);
                }
                else if (dueDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    dueDate.AddDays(1);
                }
                else
                {
                    //just here for clarity
                    dueDate = dueDate;
                }


                string[] aspects =
                {
                    summary,
                    status,
                    priority,
                    submitter,
                    assigned,
                    watching,
                    projectName,
                    dueDate.ToString()

                };
                return aspects;

            }
            else if (code == "EH")
            {
                Console.WriteLine("\nSoftware");
                string software = Console.ReadLine();
                Console.WriteLine("\nCost");
                string cost = Console.ReadLine();
                Console.WriteLine("\nReason");
                string reason = Console.ReadLine();
                Console.WriteLine("\nEstimate");
                string estimate = Console.ReadLine();
                string[] aspects =
                {
                    summary,
                    status,
                    priority,
                    submitter,
                    assigned,
                    watching,
                    software,
                    cost,
                    reason,
                    estimate

                };
                return aspects;
            }
            else //Should never get here
            {
                Console.WriteLine("Operation not performed");
                string[] aspects =
                {
                    "Blank",
                    "Blank",
                    "Blank",
                    "Blank",
                    "Blank",
                    "Blank"
                };
                return aspects;

            }

        }

        //fills the properties of a ticket from the prompts in PromptAspects method and creates a ticket
        public static Ticket FillTicket(string code)
        {
            try
            {
                //Calls method to ask user for ticket properties
                string[] aspects = PromptAspects(code);
                Ticket ticket;

                if (code == "TS")
                {
                    ticket = new Troubleshoot
                        (aspects[0], aspects[1], aspects[2], aspects[3], aspects[4], aspects[5], aspects[6]);

                    return ticket;

                }
                else if (code == "TK")
                {
                    ticket = new Task
                        (aspects[0], aspects[1], aspects[2], aspects[3], aspects[4], aspects[5], aspects[6], DateTime.Parse(aspects[7]));

                    return ticket;
                }
                else if (code == "EH")
                {
                    //intialize the double properties with negative numbers to hopefully indicate that a proper double data type entry wasn't entered cost and/or estimate.
                    double defCost = -0.01;
                    double defEstimate = -0.01;
                    double.TryParse(aspects[7], out defCost);
                    double.TryParse(aspects[9], out defEstimate);

                    ticket = new Enhancement
                        (aspects[0], aspects[1], aspects[2], aspects[3], aspects[4], aspects[5], aspects[6], defCost, aspects[8], defEstimate);

                    return ticket;
                }
                else
                {
                    Console.WriteLine("Something went wrong. Operation not completed. Creating a blank trouble ticket. Please try again");
                    ticket = new Troubleshoot();
                    return ticket;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An issue has occurred with passing the correct code in order to fill the ticket. Please notify your administrator.");
                throw e;
            }

        }

        //Creates ticket object and writes to the file
        public static void CreateTicket(string code)
        {

            string cont = "Y";

            do
            {
                //If N breaks, if Y fill a ticket and call its write method, if neither loop back with message.
                if (cont == "N")
                {
                    break;
                }
                else if (cont == "Y")
                {


                    //Fill the properties of a ticket and create it and call its write method
                    FillTicket(code).WriteTicket();


                    Console.WriteLine("\nCreate a new ticket? (Y/N)");
                    cont = Console.ReadLine().ToUpper();
                }
                else
                {
                    Console.WriteLine("\nPlease press the \"Y\" or \"N\" key. \n");
                    cont = Console.ReadLine().ToUpper();
                }

            } while (1 == 1);

        }

        //Displays tickets in a file
        public static void DisplayTickets(string code)
        {
            TicketFile display;

            //Based on the code passed, reads in ticket properties from the appropriate file, creates a ticket file, and calls its display method which calls the respective ticket display method
            switch (code)
            {
                case "TS":
                    display = new TroubleshootFile();
                    display.DisplayTicketList();
                    break;


                case "TK":
                    display = new TaskFile();
                    display.DisplayTicketList();
                    break;

                case "EH":
                    display = new EnhancementFile();
                    display.DisplayTicketList();
                    break;

                default:
                    Console.WriteLine("A problem with passing the proper code has occurred.");
                    break;
            }

        }

        //Takes the code sent from main menu to organize operations for different types of tickets
        public static void SubMenu(string code)
        {
            //Only used to generalize console display text.
            //this should never be "unknown" but it needs a default initialization. 
            string ticketType = "unknown";

            //Loop until break
            while (true)
            {
                //Sets ticketType
                switch (code)
                {
                    case "TS":
                        ticketType = "troublshooting";
                        Console.WriteLine($"\n---{ticketType.ToUpper()} TICKET MENU---\n");
                        goto default;

                    case "EH":
                        ticketType = "enhancement";
                        Console.WriteLine($"\n---{ticketType.ToUpper()} TICKET MENU---\n");
                        goto default;

                    case "TK":
                        ticketType = "task";
                        Console.WriteLine($"\n---{ticketType.ToUpper()} TICKET MENU---\n");
                        goto default;

                    //displays options
                    default:
                        Console.WriteLine($"Create a new {ticketType} ticket (1)");
                        Console.WriteLine("Display ticket history (2)");
                        Console.WriteLine("Press (B) or (Q) to go back to the main menu. \n");
                        break;
                }

                ConsoleKeyInfo keyPress = Console.ReadKey();
                Console.WriteLine("\n");

                //Create or display tickets
                if (keyPress.Key == ConsoleKey.D1 || keyPress.Key == ConsoleKey.NumPad1)
                {
                    CreateTicket(code);
                }
                else if (keyPress.Key == ConsoleKey.D2 || keyPress.Key == ConsoleKey.NumPad2)
                {
                    DisplayTickets(code);

                }
                else if (keyPress.Key == ConsoleKey.B || keyPress.Key == ConsoleKey.Q || keyPress.Key == ConsoleKey.Escape)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please try again with a valid key: 1, 2, B, Q, Esc");
                }
            }
        }

        public static void SearchAllTickets()
        {
            TicketFile troubleFile = new TroubleshootFile();
            TicketFile enhancementFile = new EnhancementFile();
            TicketFile taskFile = new TaskFile();

            /*This can all be handled in the ticketfile class, but I want to reduce the amount of times
            the files are read.*/
            List<Ticket> troubleList = troubleFile.GetTicketList();
            List<Ticket> enhancementList = enhancementFile.GetTicketList();
            List<Ticket> taskList = taskFile.GetTicketList();

            do
            {
                Console.WriteLine($"\nSearch by: \n {"",5}Status (1) \n {"",5}Priority (2) \n {"",5}Submitter (3)");
                Console.WriteLine("Press b to return to the main menu. \n");
                var category = Console.ReadKey();
                Console.WriteLine("");

                if(category.Key == ConsoleKey.B)
                {
                    break;
                }

                List<ConsoleKey> acceptableInputs = new List<ConsoleKey>
                {
                    ConsoleKey.D1, ConsoleKey.NumPad1,
                    ConsoleKey.D2, ConsoleKey.NumPad2,
                    ConsoleKey.D3, ConsoleKey.NumPad3
                };

                do
                {
                    string criteria = "";

                    if (acceptableInputs.Exists(x => x == category.Key))
                    {

                        Console.Write("Search?:   ");
                        criteria = Console.ReadLine();
                        Console.WriteLine("");

                    }

                    if (category.Key == ConsoleKey.D1 || category.Key == ConsoleKey.NumPad1)
                    {
                        var troubleResult = troubleFile.SearchTicketStatus(troubleList, criteria);
                        var enhancementResult = enhancementFile.SearchTicketStatus(troubleList, criteria);
                        var taskResult = taskFile.SearchTicketStatus(troubleList, criteria);

                        IEnumerable<Ticket> totalResult = troubleResult.Concat(enhancementResult.Concat(taskResult));
                        Console.WriteLine($"{totalResult.Count()} total results found \n");
                        foreach (var ticket in totalResult)
                        {
                            ticket.DisplayTicket();
                        }

                    }

                    else if (category.Key == ConsoleKey.D2 || category.Key == ConsoleKey.NumPad2)
                    {
                        var troubleResult = troubleFile.SearchTicketPriority(troubleList, criteria);
                        var enhancementResult = enhancementFile.SearchTicketPriority(troubleList, criteria);
                        var taskResult = taskFile.SearchTicketPriority(troubleList, criteria);

                        IEnumerable<Ticket> totalResult = troubleResult.Concat(enhancementResult.Concat(taskResult));

                        Console.WriteLine($"{totalResult.Count()} total results found \n");
                        foreach (var ticket in totalResult)
                        {
                            ticket.DisplayTicket();
                        }

                    }

                    else if (category.Key == ConsoleKey.D3 || category.Key == ConsoleKey.NumPad3)
                    {
                        var troubleResult = troubleFile.SearchTicketSubmitter(troubleList, criteria);
                        var enhancementResult = enhancementFile.SearchTicketSubmitter(troubleList, criteria);
                        var taskResult = taskFile.SearchTicketSubmitter(troubleList, criteria);

                        IEnumerable<Ticket> totalResult = troubleResult.Concat(enhancementResult.Concat(taskResult));

                        Console.WriteLine($"{totalResult.Count()} total results found \n");
                        foreach (var ticket in totalResult)
                        {
                            ticket.DisplayTicket();
                        }
                    }

                    else
                    {
                        Console.WriteLine("Please press a valid key: 1,2,3, or b");
                    }

                    Console.WriteLine("END OF SEARCH RESULTS");
                    Console.WriteLine("Press y to search this category again or any key to go back.");
                    var cont = Console.ReadKey();

                    if(cont.Key != ConsoleKey.Y)
                    {
                        break;
                    }

                }
                while (true);

            } while (true);
        }

        //Main menu. Holds options to get to the sub menu.
        public static void MainMenu()
        {
            //Loop until break
            do
            {
                Console.WriteLine("\n---MAIN MENU---\n");

                Console.WriteLine("Trouble Tickets (1)");
                Console.WriteLine("Enhancement Tickets (2)");
                Console.WriteLine("Task Tickets (3)");
                Console.WriteLine("Search Tickets (4)");
                Console.WriteLine("Press Q or Esc to Exit");

                ConsoleKeyInfo keyPress = Console.ReadKey();
                Console.WriteLine("");

                //Carries a code to SubMenu() to perform the correct formatting.
                if (keyPress.Key == ConsoleKey.D1 || keyPress.Key == ConsoleKey.NumPad1)
                {
                    SubMenu("TS");
                }

                else if (keyPress.Key == ConsoleKey.D2 || keyPress.Key == ConsoleKey.NumPad2)
                {
                    SubMenu("EH");
                }

                else if (keyPress.Key == ConsoleKey.D3 || keyPress.Key == ConsoleKey.NumPad3)
                {
                    SubMenu("TK");
                }
                else if (keyPress.Key == ConsoleKey.D4 || keyPress.Key == ConsoleKey.NumPad4)
                {
                    SearchAllTickets();
                }
                else if (keyPress.Key == ConsoleKey.Q || keyPress.Key == ConsoleKey.Escape)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please press a valid key: 1, 2, 3, Q, or ESC \n");
                }
            } while (true);

        }


        public static void Main(string[] args)
        {
            Console.WriteLine("Hello!");

            MainMenu();

            Console.WriteLine("Goodbye.");
        }
    }
}
