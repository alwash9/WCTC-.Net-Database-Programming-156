using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_6
{
    interface ITicketFile
    {

        List<Ticket> GetTicketList();

        IEnumerable<Ticket> SearchTicketStatus(List<Ticket> list, string criteria);


    }
}
