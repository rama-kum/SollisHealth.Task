using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SollisHealth.Task.Model.GetAllTasks
{
    /// <summary>
    /// TaskResponse class is used to take list of Task details into TaskOutput list and status is updated
    /// </summary>
    public class TaskResponse
    {
        public bool success { get; set; }
        public string Message { get; set; }
        public TasksDetails data { get; set; }

    }  

    public class TasksDetails
    {
        public List<TaskDetail> Tasks { get; set; }
    }

    public class TaskDetail
    {
        public TaskDetailsforUI Task { get; set; }

    }

}
