using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SollisHealth.Task.Model.GetOpenTaskSummary
{
    /// <summary>
    /// TaskResponse class is used to take list of Task details into TaskOutput list and status is updated
    /// </summary>
    public class OpenTaskSummaryResponse
    {
        public bool success { get; set; }
        public string Message { get; set; }
        public OpenTaskSummaryDetails data { get; set; }

    }

    public class OpenTaskSummaryDetails
    {
        public List<OpenTaskSummaryDetail> TaskSummariesByStatus { get; set; }
    }
    public class OpenTaskSummaryDetail
    {        
        public TaskSumaryByStatus TaskSummaryByStatus { get; set; }

    }

    public class TaskSumaryByStatus
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public ListofStatus StatusList { get; set; }

    }
    public class ListofStatus
    {
        public Status Status { get; set; }
    }
    public class Status
    {
        public string StatusName { get; set; }
        public Int64 StatusValue { get; set; }
    }

 
}
