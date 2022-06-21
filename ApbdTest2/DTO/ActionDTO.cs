using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApbdTest2.DTO
{
    public class ActionDTO
    {
        [Required]
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        [Required]
        public int NumOfFirefighter { get; set; }
        [Required]
        public DateTime AssignmentDate { get; set; }


    }
}
