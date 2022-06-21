using System;
using System.Collections.Generic;

#nullable disable

namespace ApbdTest2.Models
{
    public partial class FireTruckAction
    {
        public int IdFireTruckAction { get; set; }
        public DateTime AssignmentDate { get; set; }
        public int IdAction { get; set; }
        public int IdFireTruck { get; set; }

        public virtual Action IdActionNavigation { get; set; }
        public virtual FireTruck IdFireTruckNavigation { get; set; }
    }
}
