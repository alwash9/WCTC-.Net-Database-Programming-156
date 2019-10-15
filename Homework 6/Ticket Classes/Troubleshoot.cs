using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_6
{
    class Troubleshoot : Ticket, ITicket
    {
        //public int TicketID { get; set; } //I want this to be private, but to display all the tickets in a file, it needs to be public
        //public string Summary { get; set; }
        //public string Status { get; set; }
        //public string Priority { get; set; }
        //public string Submitter { get; set; }
        //public string Assigned { get; set; }
        //public string Watching { get; set; }
        //public string Severity { get; set; }


        //constructors

        //Probably won't be used 
        public Troubleshoot()
        {
            TicketID = 0;
            Summary = "Blank";
            Status = "Open";
            Priority = "Blank";
            Submitter = "Blank";
            Assigned = "Blank";
            Watching = "Blank";
            Severity = "Blank";
            FileName = AppDomain.CurrentDomain.BaseDirectory + "Tickets_Trouble.csv";
        }

        public Troubleshoot(string summary, string status, string priority, string submitter, string assigned, string watching, string severity)
        {
            Summary = summary;
            Status = status;
            Priority = priority;
            Submitter = submitter;
            Assigned = assigned;
            Watching = watching;
            Severity = severity;
            FileName = AppDomain.CurrentDomain.BaseDirectory + "Tickets_Trouble.csv";
            TicketID = CheckTID(FileName) + 1;

        }

        //Probably won't be used 

        public Troubleshoot(string summary, string priority)
        {
            TicketID = 0;
            Summary = summary;
            Status = "Open";
            Priority = priority;
            Submitter = "Blank";
            Assigned = "Blank";
            Watching = "Blank";
            Severity = "Blank";
            FileName = AppDomain.CurrentDomain.BaseDirectory + "Tickets_Trouble.csv";

        }

        public Troubleshoot(int ID, string summary, string status, string priority, string submitter, string assigned, string watching, string severity)
        {
            TicketID = ID;
            Summary = summary;
            Status = status;
            Priority = priority;
            Submitter = submitter;
            Assigned = assigned;
            Watching = watching;
            Severity = severity;
            FileName = AppDomain.CurrentDomain.BaseDirectory + "Tickets_Trouble.csv";

        }


        public override void WriteTicket()
        {

            if (File.Exists(FileName))
            {
                StreamWriter swt;
                swt = File.AppendText(FileName);

                swt.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7}", TicketID, Summary, Status, Priority, Submitter, Assigned, Watching, Severity);

                swt.Close();
            }
            else
            {
                StreamWriter swt = new StreamWriter(FileName);

                swt.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7}", TicketID, Summary, Status, Priority, Submitter, Assigned, Watching, Severity);

                swt.Close();
            }

        }

        public override void DisplayTicket()
        {
            Console.WriteLine("TicketID: {0}\n Summary: {1}\n Status: {2}\n Priority: {3}\n Submitter: {4}\n Assigned: {5}\n Watching: {6}\n Severity: {7}\n \n",
                TicketID, Summary, Status, Priority, Submitter, Assigned, Watching, Severity);

        }

    }
}
