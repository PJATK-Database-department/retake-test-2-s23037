using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApbdTest2.DTO
{
    public class FireTruckDTO
    {
        [Required]
        public int IdFireTruck { get; set; }
        [Required]
        public string OperationalNumber { get; set; }
        [Required]
        public bool SpecialEquipment { get; set; }

        public List<ActionDTO>  actions { get; set; }

}
}
