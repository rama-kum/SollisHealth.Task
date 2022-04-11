using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SollisHealth.Task.Model.GetTaskServicelevelSummary
{
    /// <summary>
    /// TaskResponse class is used to take list of Task details into TaskOutput list and status is updated
    /// </summary>
    public class TaskServicelevelSummaryResponse
    {
        public bool success { get; set; }
        public string Message { get; set; }
        public TaskServicelevelSummaryDetails data { get; set; }

    }

    public class TaskServicelevelSummaryDetails
    {
        public List<TaskServicelevelSummaryDetail> ServiceLevelSummaries { get; set; }
    }
    public class TaskServicelevelSummaryDetail
    {
        public TaskServicelevelSumaryByStatus ServiceLevelSummary { get; set; }


    }

    public class TaskServicelevelSumaryByStatus
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public ListofService ServiceLevelList { get; set; }

    }
    public class ListofService
    {
        public ServiceLevel ServiceLevel { get; set; }
    }
    public class ServiceLevel
    {
        public string ServiceLevelName { get; set; }
        public Int64 SummaryValue { get; set; }
    }


}
