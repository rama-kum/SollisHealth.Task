using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SollisHealth.Task.Model.GetTaskActivitySummary
{
   
    public class TaskActivitySummaryRequest
    {
        public int UserID { get; set; }
        public int RoleID { get; set; }

    }
    public class TaskActivitySummaryUserRequest
    {
        public List<TaskActivitySummaryRequest> TaskSummaryByPriorityRequest { get; set; }
    }

}
