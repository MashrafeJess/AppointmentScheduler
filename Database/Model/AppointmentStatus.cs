using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Model
{
    public class AppointmentStatus
    {
        [Key]
        public int StatusNum { get; set; }
        public string StatusName { get; set; }
    }
}
