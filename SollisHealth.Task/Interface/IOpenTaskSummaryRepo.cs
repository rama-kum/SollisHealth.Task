using SollisHealth.Task.Model;
using SollisHealth.Task.Model.GetOpenTaskSummary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SollisHealth.Task.Interface
{
    //ITaskRepo interface is inherited by TaskInfoRepo
    public interface IOpenTaskSummaryRepo
    {
        Task<OpenTaskSummaryResponse> getOpenTaskSummary(OpenTaskSummaryUserRequest openTaskSumRequest);
 
    }
}
