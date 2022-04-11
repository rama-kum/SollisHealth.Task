using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SollisHealth.Task.Interface;
using SollisHealth.Task.Model;
using SollisHealth.Task.Model.GetAllTasks;
using SollisHealth.Task.Model.UserCases;
using SollisHealth.Task.UserCases;
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
    public class TaskController : ControllerBase
    {
        private readonly ITaskBO _ITask;
        private readonly IUserBO _IUser;

        private readonly Microsoft.Extensions.Logging.ILogger<TaskController> _logger;
        // private readonly ILoggerFactory _loggerFactory;
        public IConfiguration _configuration { get; }

        public TaskController(ILogger<TaskController> logger, ITaskBO ITask, IUserBO IUser)
        {
            _logger = logger;
            _ITask = ITask;
            _IUser = IUser;

        }


        [HttpGet]
        [MapToApiVersion("1.0")]
        [Route("GetAllTasksInfo")]
        public async Task<IActionResult> GetTasksInfo()
        {
            _logger.LogInformation("Task Controller is running in " + DateTime.Now);
            TaskValidationReponse response = null;
            TaskResponse tasklistobj = await _ITask.gettaskresponse();
            if (tasklistobj.success != false)
            {
                var taskinfolist = tasklistobj.data;
                tasklistobj.Message = "Latest Task details";
                return Ok(tasklistobj);
            }
            else
            {
                _logger.LogError("Task details not found in " + DateTime.Now);
                response = BuildTaskResponseMessage("Latest Task details not found", false, 404);
                return BadRequest(response);
            }

        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        [Route("GetUserSummary")]
        public async Task<IActionResult> GetUserSummary()
        {
            _logger.LogInformation("Task Controller is running in " + DateTime.Now);
            UserCasesValidationResponse response = null;
            UserCasesResponse userlistobj = await _IUser.getusercases();
            if (userlistobj.success != false)
            {
                var taskinfolist = userlistobj.data;
                userlistobj.Message = "Latest User Summary";
                return Ok(userlistobj);
            }
            else
            {
                _logger.LogError("User Summary not found in " + DateTime.Now);
                response = BuildUserResponseMessage("Latest User Summary not found", false, 404);
                return BadRequest(response);
            }

        }
        //This method is used build response to send to client
        private TaskValidationReponse BuildTaskResponseMessage(string message, bool boolmsg, int statuscode)
        {
            TaskValidationReponse response = new TaskValidationReponse();

            response.Message = message;
            response.success = boolmsg;
            response.error_code = statuscode;
            return response;
        }
        private UserCasesValidationResponse BuildUserResponseMessage(string message, bool boolmsg, int statuscode)
        {
            UserCasesValidationResponse response = new UserCasesValidationResponse();

            response.Message = message;
            response.success = boolmsg;
            response.error_code = statuscode;
            return response;
        }


    }
}
