using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Model
{
    public class Mode
    {
        [Key]
        public int ? Role { get; set; }
        public string ? ModeName { get; set; }
    }
}
