using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SollisHealth.Task.Model.GetTasksByUser;
using SollisHealth.Task.Interface;
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
    public class TasksByUserController : ControllerBase
    {
        private readonly ITaskByUserBO _ITask;

        private readonly Microsoft.Extensions.Logging.ILogger<TasksByUserController> _logger;
        
        public IConfiguration _configuration { get; }

        public TasksByUserController(ILogger<TasksByUserController> logger, ITaskByUserBO ITask)
        {
            _logger = logger;
            _ITask = ITask;          

        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        [Route("GetTaskListByUser")]
        public async Task<IActionResult> GetTaskListByUser(TaskByUserRequest taskByUserRequest)
        {
            _logger.LogInformation("Task Controller is running in " + DateTime.Now);
            TaskByUserValidationResponse tasklistvalidationobj = new TaskByUserValidationResponse();
            TaskByUserValidationResponse tasklistvalidationobjrepo = new TaskByUserValidationResponse();
            tasklistvalidationobj.success = true;
            tasklistvalidationobj.Message = "";

            tasklistvalidationobj = validation_func(taskByUserRequest);

            if (tasklistvalidationobj.success == false)
            {
                _logger.LogError("Task List information for user not found in " + DateTime.Now);
                tasklistvalidationobj = BuildTaskResponseMessage(tasklistvalidationobj.Message, false, 400);
                return BadRequest(tasklistvalidationobj);
            }
            else
            {
                TaskByUserResponse tasklistobj = await _ITask.gettaskbyuser(taskByUserRequest);
                if (tasklistobj.success != false)
                {
                    return Ok(tasklistobj);
                }
                else
                {
                    _logger.LogError("Task List information for user not found in " + DateTime.Now);
                    tasklistvalidationobjrepo = BuildTaskResponseMessage(tasklistobj.Message, false, 404);
                    return BadRequest(tasklistvalidationobjrepo);
                }
            }

        }

        private TaskByUserValidationResponse validation_func(TaskByUserRequest taskByUserRequest)
        {
            TaskByUserValidationResponse validationresponse = new TaskByUserValidationResponse();
            validationresponse.success = true;
            validationresponse.Message = "";

 
                if (taskByUserRequest.AssignedUserId <= 0)
                {
                    validationresponse.success = false;
                    validationresponse.Message = "AssignedUserID should be greater than 0";

                }
                else if (taskByUserRequest.RoleId <= 0)
                {
                    validationresponse.success = false;
                    validationresponse.Message = "RoleID should be greater than 0";

                }
            
            return validationresponse;
        }
        //This method is used build response to send to client
        private TaskByUserValidationResponse BuildTaskResponseMessage(string message, bool boolmsg, int statuscode)
        {
            TaskByUserValidationResponse response = new TaskByUserValidationResponse();

            response.Message = message;
            response.success = boolmsg;
            response.error_code = statuscode;
            return response;
        }

    }
}
