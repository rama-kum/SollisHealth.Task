using SollisHealth.Task.Model;

using SollisHealth.Task.Model.GetTaskServicelevelSummary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SollisHealth.Task.Interface
{
    /// <summary>
    /// ITaskBO interface is inherited by TaskBO
    /// </summary>
    public interface ITaskServicelevelSummaryBO
    {
        Task<TaskServicelevelSummaryResponse> gettaskServicelevelSummary(TaskServicelevelSummaryUserRequest taskServicelevelSummaryRequest);

    }
}
