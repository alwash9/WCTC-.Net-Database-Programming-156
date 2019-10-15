using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Homework_6
{
    class EnhancementFile : TicketFile, ITicketFile
    {
        public EnhancementFile()
        {
            FileName = AppDomain.CurrentDomain.BaseDirectory + "Tickets_Enhancement.csv";
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
                        double defCost = -0.01;
                        double defEstimate = -0.01;
                        double.TryParse(aspects[8], out defCost);
                        double.TryParse(aspects[10], out defEstimate);

                        Ticket ticket = new Enhancement
                        {
                            TicketID = parseID,
                            Summary = aspects[1],
                            Status = aspects[2],
                            Priority = aspects[3],
                            Submitter = aspects[4],
                            Assigned = aspects[5],
                            Watching = aspects[6],
                            Software = aspects[7],
                            Cost = defCost,
                            Reason = aspects[9],
                            Estimate = defEstimate

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
