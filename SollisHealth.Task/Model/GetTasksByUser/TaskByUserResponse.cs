using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SollisHealth.Task.Model.GetTasksByUser
{
    /// <summary>
    /// TaskResponse class is used to take list of Task details into TaskOutput list and status is updated
    /// </summary>
    public class TaskByUserResponse
    {
        public bool success { get; set; }
        public string Message { get; set; }
        public TasksByUser data { get; set; }

    }

    public class TasksByUser
    {        
        public List<TaskByUser> UserTasks { get; set; }

    }

    public class TaskByUser
    {
        public TaskByUserDetailsforUI UserTask { get; set; }
    }

}
