using SollisHealth.Task.Model;
using SollisHealth.Task.Model.GetTaskActivitySummary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SollisHealth.Task.Interface
{
    //ITaskRepo interface is inherited by TaskInfoRepo
    public interface ITaskActivitySummaryRepo
    {
        Task<TaskActivitySummaryResponse> gettaskActivitySummary(TaskActivitySummaryUserRequest taskActivitySummaryUser);
 
    }
}
