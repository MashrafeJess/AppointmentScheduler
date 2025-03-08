using System.ComponentModel.DataAnnotations;

namespace Database.Model
{
    public class UserInfo : BaseModel
    {
        [Key]
        public string UserId { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string ?Name { get; set; }

        [Required]
        [EmailAddress] 
        public string ?Email { get; set; }

        [Required]
        public string ? PasswordHash { get; set; }

        [Required]
        public string ? Designation { get; set; } 
        public int ? RoomNum{ get; set; } 
        public int ? Mode { get; set; } 
    }
}
