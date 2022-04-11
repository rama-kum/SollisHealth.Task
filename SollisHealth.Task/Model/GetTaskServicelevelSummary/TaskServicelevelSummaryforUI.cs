using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SollisHealth.Task.Model.GetTaskServicelevelSummary
{
    public class TaskServicelevelSummaryforUI
    {
        [Key]
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public string ServiceLevelName { get; set; }
        public Int64 SummaryValue { get; set; }
     
       
    }

}
