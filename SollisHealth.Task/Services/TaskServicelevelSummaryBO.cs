using SollisHealth.Task.Interface;
using SollisHealth.Task.Model;
using SollisHealth.Task.Model.GetAllTasks;
using SollisHealth.Task.Model.GetTaskServicelevelSummary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SollisHealth.Task.Services
{
    public class TaskServicelevelSummaryBO : ITaskServicelevelSummaryBO
    {
        private readonly ITaskServicelevelSummaryRepo _TaskRepo;
        public TaskServicelevelSummaryBO(ITaskServicelevelSummaryRepo TaskRepo)
        {
            _TaskRepo = TaskRepo;
        }

  
        public async Task<TaskServicelevelSummaryResponse> gettaskServicelevelSummary(TaskServicelevelSummaryUserRequest taskServicelevelSummaryRequest)
        {
            TaskServicelevelSummaryResponse TaskResponse = await _TaskRepo.gettaskServicelevelSummary(taskServicelevelSummaryRequest);
            return TaskResponse;

        }


    }
}
