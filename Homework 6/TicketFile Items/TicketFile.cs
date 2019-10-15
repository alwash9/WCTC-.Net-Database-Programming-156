using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_6
{
    abstract class TicketFile : ITicketFile
    {
        public string FileName { get; set; }

        public abstract List<Ticket> GetTicketList();
        //{
        //    Console.WriteLine("There was an error. Operation not performed");
        //    List < Ticket > emptyTicketList = new List<Ticket>();
        //    return emptyTicketList;
        //}

        public void DisplayTicketList()
        {
            try
            {
                List<Ticket> ticketList = GetTicketList();

                foreach (Ticket tick in ticketList)
                {
                    tick.DisplayTicket();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("There was an error in getting the list of tickets");
                throw e;
            }

            //Console.WriteLine("This method is meant to be overrided");
        }

        public IEnumerable<Ticket> SearchTicketStatus(List<Ticket> list, string criteria)
        {

            IEnumerable<Ticket> result = list.Where(m => m.Status.Contains(criteria));
            return result;
        }

        public IEnumerable<Ticket> SearchTicketStatus(string criteria)
        {
            List<Ticket> troubleList = GetTicketList();
            IEnumerable<Ticket> result = troubleList.Where(m => m.Status.Contains(criteria));
            return result;
        }

        public IEnumerable<Ticket> SearchTicketPriority(List<Ticket> list, string criteria)
        {

            IEnumerable<Ticket> result = list.Where(m => m.Priority.Contains(criteria));
            return result;
        }

        public IEnumerable<Ticket> SearchTicketPriority(string criteria)
        {
            List<Ticket> troubleList = GetTicketList();
            IEnumerable<Ticket> result = troubleList.Where(m => m.Priority.Contains(criteria));
            return result;
        }

        public IEnumerable<Ticket> SearchTicketSubmitter(List<Ticket> list, string criteria)
        {

            IEnumerable<Ticket> result = list.Where(m => m.Submitter.Contains(criteria));
            return result;
        }

        public IEnumerable<Ticket> SearchTicketSubmitter(string criteria)
        {
            List<Ticket> troubleList = GetTicketList();
            IEnumerable<Ticket> result = troubleList.Where(m => m.Submitter.Contains(criteria));
            return result;
        }


    }
}
