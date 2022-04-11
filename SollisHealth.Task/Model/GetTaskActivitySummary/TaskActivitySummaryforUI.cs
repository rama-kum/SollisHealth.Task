using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SollisHealth.Task.Model.GetTaskActivitySummary
{
    public class TaskActivitySummaryforUI
    {
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public string PriorityName { get; set; }
        public int PriorityValue{ get; set; }
    }

}
