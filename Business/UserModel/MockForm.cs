using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;
using Database.Model;

namespace Business.UserModel
{
    public class MockForm : BaseModel
    {
        [Required, MaxLength(50)]
        public string? Name { get; set; }
        [Required, EmailAddress]
        public string? Email { get; set; }
        [Required, MinLength(8)]
        public string? Password { get; set; }
        public string? Designation { get; set; }
        public int? RoomNumber { get; set; }
        public int Mode { get; set; }
    }
}
