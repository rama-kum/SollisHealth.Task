using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SollisHealth.Task.Interface;
using SollisHealth.Task.Model.GetTaskServicelevelSummary;
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
    public class TaskServicelevelSummaryController : ControllerBase
    {
        private readonly ITaskServicelevelSummaryBO _ITask;

        private readonly Microsoft.Extensions.Logging.ILogger<TaskServicelevelSummaryController> _logger;

        public IConfiguration _configuration { get; }

        public TaskServicelevelSummaryController(ILogger<TaskServicelevelSummaryController> logger, ITaskServicelevelSummaryBO ITask)
        {
            _logger = logger;
            _ITask = ITask;

        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        [Route("GetTaskwiseServiceLevelSummary")]
        public async Task<IActionResult> GetTaskwiseServiceLevelSummary(TaskServicelevelSummaryUserRequest taskServicelevelSummaryRequest)
        {
            _logger.LogInformation("Task Wise Service Level Summary Controller is running in " + DateTime.Now);
            TaskServicelevelSummaryValidationResponse taskvalidationobj = new TaskServicelevelSummaryValidationResponse();
            TaskServicelevelSummaryValidationResponse taskvalidationobjrepo = new TaskServicelevelSummaryValidationResponse();
            taskvalidationobj.success = true;
            taskvalidationobj.Message = "";

            taskvalidationobj = validation_func(taskServicelevelSummaryRequest);


            if (taskvalidationobj.success == false)
            {
                _logger.LogError("Getting Task Wise Summary Level details not found in " + DateTime.Now);
                taskvalidationobj = BuildTaskServiceSummaryResponseMessage(taskvalidationobj.Message, false, 400);
                return BadRequest(taskvalidationobj);
            }
            else
            {
                TaskServicelevelSummaryResponse tasklistobj = await _ITask.gettaskServicelevelSummary(taskServicelevelSummaryRequest);
                if (tasklistobj.success != false)
                {
                    return Ok(tasklistobj);
                }
                else
                {
                    _logger.LogError("Getting Task Wise Summary Level details not found in " + DateTime.Now);
                    taskvalidationobjrepo = BuildTaskServiceSummaryResponseMessage(tasklistobj.Message, false, 404);
                    return BadRequest(taskvalidationobjrepo);
                }
            }


        }

        private TaskServicelevelSummaryValidationResponse validation_func(TaskServicelevelSummaryUserRequest taskServicelevelSummaryRequest)
        {
            TaskServicelevelSummaryValidationResponse validationresponse = new TaskServicelevelSummaryValidationResponse();
            validationresponse.success = true;
            validationresponse.Message = "";

            foreach (var item in taskServicelevelSummaryRequest.TaskSummaryByServiceLevelRequest)
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
        private TaskServicelevelSummaryValidationResponse BuildTaskServiceSummaryResponseMessage(string message, bool boolmsg, int statuscode)
        {
            TaskServicelevelSummaryValidationResponse response = new TaskServicelevelSummaryValidationResponse();

            response.Message = message;
            response.success = boolmsg;
            response.error_code = statuscode;
            return response;
        }
    }
}
