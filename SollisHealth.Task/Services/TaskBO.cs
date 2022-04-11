using SollisHealth.Task.Interface;
using SollisHealth.Task.Model;
using SollisHealth.Task.Model.GetAllTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SollisHealth.Task.Services
{
    public class TaskBO: ITaskBO
    {
        private readonly ITaskRepo _TaskRepo;
        public TaskBO(ITaskRepo TaskRepo)
        {
            _TaskRepo = TaskRepo;
        }

  
        public async Task<TaskResponse> gettaskresponse()
        {
            TaskResponse TaskResponse = await _TaskRepo.gettaskresponse();
            return TaskResponse;

        }


    }
}
