using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_6
{
    class Task : Ticket, ITicket
    {
        //public int TicketID { get; set; }
        //public string Summary { get; set; }
        //public string Status { get; set; }
        //public string Priority { get; set; }
        //public string Submitter { get; set; }
        //public string Assigned { get; set; }
        //public string Watching { get; set; }
        //public string ProjectName { get; set; }
        //public DateTime DueDate { get; set; }

        public Task()
        {
            TicketID = 0;
            Summary = "Blank";
            Status = "Open";
            Priority = "Blank";
            Submitter = "Blank";
            Assigned = "Blank";
            Watching = "Blank";
            ProjectName = "Blank";
            if (DateTime.Now.AddDays(5).DayOfWeek == DayOfWeek.Saturday)
            {
                DueDate = DateTime.Now.AddDays(7);
            }
            else if (DateTime.Now.AddDays(5).DayOfWeek == DayOfWeek.Sunday)
            {
                DueDate = DateTime.Now.AddDays(6);
            }
            else
            {
                DueDate = DateTime.Now.AddDays(5);
            }

            FileName = AppDomain.CurrentDomain.BaseDirectory + "Tickets_Task.csv";
        }

        public Task(string summary, string status, string priority, string submitter, string assigned, string watching, string projectName, DateTime dueDate)
        {
            Summary = summary;
            Status = status;
            Priority = priority;
            Submitter = submitter;
            Assigned = assigned;
            Watching = watching;
            ProjectName = projectName;
            DueDate = dueDate;
            FileName = AppDomain.CurrentDomain.BaseDirectory + "Tickets_Task.csv";
            TicketID = CheckTID(FileName) + 1;

        }

        public Task(int ID, string summary, string status, string priority, string submitter, string assigned, string watching, string projectName, DateTime dueDate)
        {
            TicketID = ID;
            Summary = summary;
            Status = status;
            Priority = priority;
            Submitter = submitter;
            Assigned = assigned;
            Watching = watching;
            ProjectName = projectName;
            DueDate = dueDate;
            FileName = AppDomain.CurrentDomain.BaseDirectory + "Tickets_Task.csv";
        }

        public override void WriteTicket()
        {
            //Create tickets.

            if (File.Exists(FileName))
            {
                StreamWriter swt;
                swt = File.AppendText(FileName);

                //Write variables to file
                swt.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8}",
                    TicketID, Summary, Status, Priority, Submitter, Assigned, Watching, ProjectName, DueDate);

                swt.Close();
            }
            else
            {
                StreamWriter swt = new StreamWriter(FileName);

                //Write variables to file
                swt.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8}",
                    TicketID, Summary, Status, Priority, Submitter, Assigned, Watching, ProjectName, DueDate);

                swt.Close();
            }

        }


        public override void DisplayTicket()
        {
            //write ticket properties to console
            Console.WriteLine("TicketID: {0}\n Summary: {1}\n Status: {2}\n Priority: {3}\n Submitter: {4}\n Assigned: {5}\n Watching: {6}\n ProjectName: {7}\n DueDate: {8}\n \n",
                TicketID, Summary, Status, Priority, Submitter, Assigned, Watching, ProjectName, DueDate);

        }

    }
}
