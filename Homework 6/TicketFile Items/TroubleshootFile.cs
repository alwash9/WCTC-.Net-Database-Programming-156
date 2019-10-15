using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_6
{
    class TroubleshootFile : TicketFile, ITicketFile
    {
        public TroubleshootFile()
        {
            FileName = AppDomain.CurrentDomain.BaseDirectory + "Tickets_Trouble.csv";
        }

        public override List<Ticket> GetTicketList()
        {
            List<Ticket> ticketList = new List<Ticket>();

            if (File.Exists(FileName))
            {
                string[] fileContents = File.ReadAllLines(FileName);
                for (int i = 0; i < fileContents.Length; i++)
                {
                    string line = fileContents[i];
                    string[] aspects = line.Split(',');
                    if (Int32.TryParse(aspects[0], out int parseID))
                    {
                        Ticket ticket = new Troubleshoot
                        {
                            TicketID = parseID,
                            Summary = aspects[1],
                            Status = aspects[2],
                            Priority = aspects[3],
                            Submitter = aspects[4],
                            Assigned = aspects[5],
                            Watching = aspects[6],
                            Severity = aspects[7]
                        };

                        ticketList.Add(ticket);
                    }
                    else
                    {
                        Console.WriteLine("\nThere was a problem reading the file. Please make sure the file is formatted correctly.");
                        break;
                    }


                }

            }
            return ticketList;

        }


    }
}
