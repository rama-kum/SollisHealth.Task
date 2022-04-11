using SollisHealth.Task.Interface;
using SollisHealth.Task.Model;
using SollisHealth.Task.Model.GetOpenTaskSummary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SollisHealth.Task.Services
{
    public class OpenTaskSummaryBO : IOpenTaskSummaryBO
    {
        private readonly IOpenTaskSummaryRepo _TaskRepo;
        public OpenTaskSummaryBO(IOpenTaskSummaryRepo TaskRepo)
        {
            _TaskRepo = TaskRepo;
        }

  
        public async Task<OpenTaskSummaryResponse> getOpenTaskSummary(OpenTaskSummaryUserRequest openTaskSumRequest)
        {
            OpenTaskSummaryResponse TaskResponse = await _TaskRepo.getOpenTaskSummary(openTaskSumRequest);
            return TaskResponse;

        }


    }
}
