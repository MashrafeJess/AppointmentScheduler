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
        public string RequestedFor { get; set; }
        public TimeOnly AppointTime { get; set; }
        public DateOnly Date { get; set; }
    }
}
