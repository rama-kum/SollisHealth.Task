using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SollisHealth.Task.Model.GetOpenTaskSummary
{
    public class OpenTaskSummaryUserRequest
    {
        public List<OpenTaskSummaryRequest> TaskSummaryRequest { get; set; }
    }
}
