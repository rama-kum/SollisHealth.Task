using SollisHealth.Task.Model;
using SollisHealth.Task.Model.GetAllTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SollisHealth.Task.Interface
{
    /// <summary>
    /// ITaskBO interface is inherited by TaskBO
    /// </summary>
    public interface ITaskBO
    {
        Task<TaskResponse> gettaskresponse();

    }
}
