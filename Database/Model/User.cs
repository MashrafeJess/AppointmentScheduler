using System.ComponentModel.DataAnnotations;

namespace Database.Model
{
    public class User
    {
        [Key]
        [Required]
        public string ? Name { get; set; }
        [Required]   
        public string ? Mail { get; set; }
        [Required]   
        public string ? Password { get; set; }
        [Required]   
        public string ? Designation { get; set; }
        [Required]   
        public string ? Mode { get; set; }
    };
}