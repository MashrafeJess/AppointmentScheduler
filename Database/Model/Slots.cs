using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Model
{
    public class Slots
    {
        [Key]
        public int ? SlotId { get; set; }
        public TimeOnly ? Slot {  get; set; }
        public string ? UserId { get; set; }
    }
}
