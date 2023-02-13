using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotManagement
{
    public class Ticket
    {
        public static int TicketId = 1;
        public int TokenNumber { get; set; }
        public DateTime InTime { get; set; }
        public DateTime OutTime { get; set; }
        public TimeSpan Duration { get; set; }
        public double Amount { get; set; }
    }
}
