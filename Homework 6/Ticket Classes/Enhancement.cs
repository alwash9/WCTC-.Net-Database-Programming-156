using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_6
{
    class Enhancement : Ticket, ITicket
    {

        //public int TicketID { get; set; } 
        //public string Summary { get; set; }
        //public string Status { get; set; }
        //public string Priority { get; set; }
        //public string Submitter { get; set; }
        //public string Assigned { get; set; }
        //public string Watching { get; set; }
        //public string Software { get; set; }
        //public double Cost { get; set; }
        //public string Reason { get; set; }
        //public double Estimate { get; set; }

        public Enhancement()
        {
            TicketID = 0;
            Summary = "Blank";
            Status = "Open";
            Priority = "Blank";
            Submitter = "Blank";
            Assigned = "Blank";
            Watching = "Blank";
            Software = "Blank";
            Cost = 0.00;
            Reason = "Blank";
            Estimate = 0.00;
            FileName = AppDomain.CurrentDomain.BaseDirectory + "Tickets_Enhancement.csv";
        }

        public Enhancement(string summary, string status, string priority, string submitter, string assigned, string watching, string software, double cost, string reason, double estimate)
        {
            Summary = summary;
            Status = status;
            Priority = priority;
            Submitter = submitter;
            Assigned = assigned;
            Watching = watching;
            Software = software;
            Cost = cost;
            Reason = reason;
            Estimate = estimate;
            FileName = AppDomain.CurrentDomain.BaseDirectory + "Tickets_Enhancement.csv";
            TicketID = CheckTID(FileName) + 1;

        }

        public Enhancement(int ID, string summary, string status, string priority, string submitter, string assigned, string watching, string software, double cost, string reason, double estimate)
        {
            TicketID = ID;
            Summary = summary;
            Status = status;
            Priority = priority;
            Submitter = submitter;
            Assigned = assigned;
            Watching = watching;
            Software = software;
            Cost = cost;
            Reason = reason;
            Estimate = estimate;
            FileName = AppDomain.CurrentDomain.BaseDirectory + "Tickets_Enhancement.csv";
        }

        public override void WriteTicket()
        {
            //Create tickets.

            if (File.Exists(FileName))
            {
                StreamWriter swt;
                swt = File.AppendText(FileName);

                //Write variables to file
                swt.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}", TicketID, Summary, Status, Priority, Submitter, Assigned, Watching, Software, Cost, Reason, Estimate);

                swt.Close();
            }
            else
            {
                StreamWriter swt = new StreamWriter(FileName);

                //Write variables to file
                swt.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}", 
                    TicketID, Summary, Status, Priority, Submitter, Assigned, Watching, Software, Cost, Reason, Estimate);

                swt.Close();
            }

        }


        public override void DisplayTicket()
        {
            //write ticket properties to console
            Console.WriteLine("TicketID: {0}\n Summary: {1}\n Status: {2}\n Priority: {3}\n Submitter: {4}\n Assigned: {5}\n Watching: {6}\n Software: {7}\n Cost: {8}\n Reason: {9}\n Estimate: {10}\n \n",
                TicketID, Summary, Status, Priority, Submitter, Assigned, Watching, Software, Cost, Reason, Estimate);

        }

    }
}
