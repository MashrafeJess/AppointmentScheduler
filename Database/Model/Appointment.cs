using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Model
{
    internal class Appointment
    {
        [Key]
        public string AppointmentId { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string ? From { get; set; }
        [Required]
        public string ? To { get; set; }
        [Required]
        public DateTime ? Appoint { get; set; }
        [Required]

        public int ? RoomNumber { get; set; }
        public bool IsBooked { get; set; }

    }
}
