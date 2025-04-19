using System.ComponentModel.DataAnnotations;

namespace Database.Model
{
    public class Appointment : BaseModel
    {
        [Key]
        public string AppointmentId { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string RequestedBy { get; set; }

        [Required]
        public string RequestedFor { get; set; }

        [Required]
        public DateTime AppointTime { get; set; }
        public int RoomNo { get; set; }
        public int AppointmentStatus { get; set; }
    }
}
