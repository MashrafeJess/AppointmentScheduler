using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Model
{
    public class Role : BaseModel
    {
        [Key]
        public int ? RoleNum { get; set; }
        public string ? RoleName { get; set; }
    }
}
