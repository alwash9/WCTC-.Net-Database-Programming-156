using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_6
{
    //Started as an abstract class, but ended up using it to create generic tickets
    public abstract class Ticket : ITicket
    {

        public string FileName { get; set; }
        public int TicketID { get; set; } //I want this to be private, but to display all the tickets in a file, it needs to be public
        public string Summary { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public string Submitter { get; set; }
        public string Assigned { get; set; }
        public string Watching { get; set; }
        public string Severity { get; set; }
        public string Software { get; set; }
        public double Cost { get; set; }
        public string Reason { get; set; }
        public double Estimate { get; set; }
        public string ProjectName { get; set; }
        public DateTime DueDate { get; set; }



        //Reads the file to find the last id used
        protected int CheckTID(string file)
        {

            if (File.Exists(file))
            {

                string[] fileContent = File.ReadAllLines(file);
                string line = fileContent[fileContent.Length - 1];
                string[] lineContent = line.Split(',');

                int.TryParse(lineContent[0], out int tID);

                try
                {
                    return tID;
                }
                catch (Exception e)
                {
                    Console.WriteLine("ERROR: There was a problem in finding the lastest ticket ID. The file may be improperly formatted.");
                    throw e;
                }
            }
            else
            {
                return -1;
            }


        }

        public virtual void WriteTicket()
        {
            Console.WriteLine("This method is meant to be overidded by subclasses");
        }

        public virtual void DisplayTicket()
        {
            Console.WriteLine("This method is meant to be overidded by subclasses");
        }

    }
}
