using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    internal class Appointment
    {
        public int Serial { get; set; }
        public string From { get; set; }
        public string To { get; set; } 
        public DateTime Appoint { get; set; }

        public int RoomNumber   { get; set; }
    }
}
