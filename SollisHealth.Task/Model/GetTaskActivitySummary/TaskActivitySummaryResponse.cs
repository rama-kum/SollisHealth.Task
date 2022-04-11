using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SollisHealth.Task.Model.GetTaskActivitySummary
{
    public class TaskActivitySummaryResponse
    {
        public bool success { get; set; }
        public string Message { get; set; }
        public TaskActivitySummaryDetails data { get; set; }

    }

    public class TaskActivitySummaryDetails
    {
        public List<TaskActivitySummaryDetail> TaskSummariesByPriority { get; set; }
    }
    public class TaskActivitySummaryDetail
    {
        public TaskActivitySumaryByStatus TaskSummaryByPriority { get; set; }      
     

    }

    public class TaskActivitySumaryByStatus
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public ListofPriority PriorityList { get; set; }

    }
    public class ListofPriority
    {
        public Priority Priority { get; set; }
    }
    public class Priority
    {
        public string PriorityName { get; set; }
        public Int64 PriorityValue { get; set; }
    }


}
