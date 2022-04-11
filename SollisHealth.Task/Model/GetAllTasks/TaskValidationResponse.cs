using SollisHealth.Task.Model;
using SollisHealth.Task.Model.GetAllTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SollisHealth.Task.Model.GetAllTasks
{
    /// <summary>
    /// TaskValidationReponse class is used to build validation response if data not exists
    /// </summary>
    public class TaskValidationReponse
    {
        public bool success { get; set; }
        public int error_code { get; set; }
        public string Message { get; set; }
        public List<TaskDetailsforUI> data { get; set; }
    }
}
