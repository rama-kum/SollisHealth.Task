using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SollisHealth.Task.Model.GetTaskServicelevelSummary
{
   
    public class TaskServicelevelSummaryRequest
    {
        public int UserID { get; set; }
        public int RoleID { get; set; }

    }
    public class TaskServicelevelSummaryUserRequest
    {
        public List<TaskServicelevelSummaryRequest> TaskSummaryByServiceLevelRequest { get; set; }
    }

}
