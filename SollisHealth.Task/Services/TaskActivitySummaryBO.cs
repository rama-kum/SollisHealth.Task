using SollisHealth.Task.Interface;
using SollisHealth.Task.Model;
using SollisHealth.Task.Model.GetAllTasks;
using SollisHealth.Task.Model.GetTaskActivitySummary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SollisHealth.Task.Services
{
    public class TaskActivitySummaryBO : ITaskActivitySummaryBO
    {
        private readonly ITaskActivitySummaryRepo _TaskRepo;
        public TaskActivitySummaryBO(ITaskActivitySummaryRepo TaskRepo)
        {
            _TaskRepo = TaskRepo;
        }

  
        public async Task<TaskActivitySummaryResponse> gettaskActivitySummary(TaskActivitySummaryUserRequest taskActivitySummaryUser)
        {
            TaskActivitySummaryResponse TaskResponse = await _TaskRepo.gettaskActivitySummary(taskActivitySummaryUser);
            return TaskResponse;

        }


    }
}
