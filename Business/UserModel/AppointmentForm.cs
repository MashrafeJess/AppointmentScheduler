using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Model;

namespace Business.UserModel
{
    public class AppointmentForm : BaseModel
    {
        public string RequestedBy { get; set; }
        public string RequestedTo { get; set; }
        public DateTime AppointTime { get; set; }
        public double Duration { get; set; }    
        public int RoomNO { get; set; }
    }
}
