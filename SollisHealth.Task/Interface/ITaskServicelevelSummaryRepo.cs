using SollisHealth.Task.Model;
using SollisHealth.Task.Model.GetTaskServicelevelSummary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SollisHealth.Task.Interface
{
    //ITaskRepo interface is inherited by TaskInfoRepo
    public interface ITaskServicelevelSummaryRepo
    {
        Task<TaskServicelevelSummaryResponse> gettaskServicelevelSummary(TaskServicelevelSummaryUserRequest taskServicelevelSummaryRequest);
 
    }
}
