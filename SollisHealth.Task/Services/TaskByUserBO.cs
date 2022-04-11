using SollisHealth.Task.Interface;
using SollisHealth.Task.Model;
using SollisHealth.Task.Model.GetTasksByUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SollisHealth.Task.Services
{
    public class TaskByUserBO : ITaskByUserBO
    {
        private readonly ITaskByUserRepo _TaskRepo;
        public TaskByUserBO(ITaskByUserRepo TaskRepo)
        {
            _TaskRepo = TaskRepo;
        }

  
        public async Task<TaskByUserResponse> gettaskbyuser(TaskByUserRequest taskByUserRequest)
        {
            TaskByUserResponse TaskResponse = await _TaskRepo.gettaskbyuser(taskByUserRequest);
            return TaskResponse;

        }  

    }
}
