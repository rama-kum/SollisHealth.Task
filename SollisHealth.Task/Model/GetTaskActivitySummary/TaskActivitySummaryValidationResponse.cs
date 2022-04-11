using SollisHealth.Task.Model;
using SollisHealth.Task.Model.GetTaskActivitySummary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SollisHealth.Task.Model.GetTaskActivitySummary
{
    /// <summary>
    /// TaskValidationReponse class is used to build validation response if data not exists
    /// </summary>
    public class TaskActivitySummaryValidationResponse
    {
        public bool success { get; set; }
        public int error_code { get; set; }
        public string Message { get; set; }
        public List<TaskActivitySummaryforUI> data { get; set; }
    }
}
