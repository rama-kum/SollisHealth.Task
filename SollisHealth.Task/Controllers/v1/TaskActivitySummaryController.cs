using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SollisHealth.Task.Interface;
using SollisHealth.Task.Model.GetTaskActivitySummary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SollisHealth.Task.Controllers.v1
{
    [ApiController]
    //[Authorize]

    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}")]
    public class TaskActivitySummaryController : ControllerBase
    {
        private readonly ITaskActivitySummaryBO _ITask;

        private readonly Microsoft.Extensions.Logging.ILogger<TaskActivitySummaryController> _logger;

        public IConfiguration _configuration { get; }

        public TaskActivitySummaryController(ILogger<TaskActivitySummaryController> logger, ITaskActivitySummaryBO ITask)
        {
            _logger = logger;
            _ITask = ITask;

        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        [Route("GetTaskSummaryByPriority")]
        public async Task<IActionResult> GetTaskSummaryByPriority(TaskActivitySummaryUserRequest taskActivitySummaryUser)
        {
            _logger.LogInformation("Task Summary by Priority Controller is running in " + DateTime.Now);
            TaskActivitySummaryValidationResponse taskvalidationobj = new TaskActivitySummaryValidationResponse();
            TaskActivitySummaryValidationResponse taskvalidationobjrepo = new TaskActivitySummaryValidationResponse();
            taskvalidationobj.success = true;
            taskvalidationobj.Message = "";

            taskvalidationobj = validation_func(taskActivitySummaryUser);


            if (taskvalidationobj.success == false)
            {
                _logger.LogError("Getting Task Summary by Priority details not found in " + DateTime.Now);
                taskvalidationobj = BuildTaskActivitySummaryResponseMessage(taskvalidationobj.Message, false, 400);
                return BadRequest(taskvalidationobj);
            }
            else
            {
                TaskActivitySummaryResponse tasklistobj = await _ITask.gettaskActivitySummary(taskActivitySummaryUser);
                if (tasklistobj.success != false)
                {
                    return Ok(tasklistobj);
                }
                else
                {
                    _logger.LogError("Getting Task Summary by Priority details not found in " + DateTime.Now);
                    taskvalidationobjrepo = BuildTaskActivitySummaryResponseMessage(tasklistobj.Message, false, 404);
                    return BadRequest(taskvalidationobjrepo);
                }
            }

        }
        private TaskActivitySummaryValidationResponse validation_func(TaskActivitySummaryUserRequest TaskSumRequest)
        {
            TaskActivitySummaryValidationResponse validationresponse = new TaskActivitySummaryValidationResponse();
            validationresponse.success = true;
            validationresponse.Message = "";

            foreach (var item in TaskSumRequest.TaskSummaryByPriorityRequest)
            {
                if (item.UserID <= 0)
                {
                    validationresponse.success = false;
                    validationresponse.Message = "UserID should be greater than 0";

                }
                else if (item.RoleID <= 0)
                {
                    validationresponse.success = false;
                    validationresponse.Message = "RoleID should be greater than 0";

                }

            }
            return validationresponse;
        }
        //This method is used build response to send to client
        private TaskActivitySummaryValidationResponse BuildTaskActivitySummaryResponseMessage(string message, bool boolmsg, int statuscode)
        {
            TaskActivitySummaryValidationResponse response = new TaskActivitySummaryValidationResponse();

            response.Message = message;
            response.success = boolmsg;
            response.error_code = statuscode;
            return response;
        }
    }
}