using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SollisHealth.Task.Interface;
using SollisHealth.Task.Model.GetOpenTaskSummary;
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
    public class OpenTaskSummaryController : ControllerBase
    {
        private readonly IOpenTaskSummaryBO _ITask;

        private readonly Microsoft.Extensions.Logging.ILogger<OpenTaskSummaryController> _logger;

        public IConfiguration _configuration { get; }

        public OpenTaskSummaryController(ILogger<OpenTaskSummaryController> logger, IOpenTaskSummaryBO ITask)
        {
            _logger = logger;
            _ITask = ITask;

        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        [Route("GetOpenTaskSummary")]
        public async Task<IActionResult> GetOpenTaskSummary(OpenTaskSummaryUserRequest openTaskSumRequest )
        {
            _logger.LogInformation("Open Task Controller is running in " + DateTime.Now);
            OpenTaskSummaryValidationResponse taskvalidationobjrepo = new OpenTaskSummaryValidationResponse();
            OpenTaskSummaryValidationResponse taskvalidationobj = new OpenTaskSummaryValidationResponse();
            taskvalidationobj.success = true;
            taskvalidationobj.Message = "";

            taskvalidationobj = validation_func(openTaskSumRequest);

 
            if (taskvalidationobj.success == false)
            {
                _logger.LogError("Open Task Summary details not found in " + DateTime.Now);
                taskvalidationobj = BuildOpenTaskSummaryResponseMessage(taskvalidationobj.Message, false, 400);
                return BadRequest(taskvalidationobj);
            }
            else
            {
                OpenTaskSummaryResponse tasklistobj = await _ITask.getOpenTaskSummary(openTaskSumRequest);
                if (tasklistobj.success != false)
                {
                    return Ok(tasklistobj);
                }
                else
                {
                    _logger.LogError("Open Task Summary details not found in " + DateTime.Now);
                    taskvalidationobjrepo = BuildOpenTaskSummaryResponseMessage(tasklistobj.Message, false, 404);
                    return BadRequest(taskvalidationobjrepo);
                }
            }
 
        
        }
        //This method is used build response to send to client
        private OpenTaskSummaryValidationResponse validation_func(OpenTaskSummaryUserRequest openTaskSumRequest)
        {
            OpenTaskSummaryValidationResponse validationresponse = new OpenTaskSummaryValidationResponse();
            validationresponse.success = true;
            validationresponse.Message = "";

            foreach (var item in openTaskSumRequest.TaskSummaryRequest)
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
        private OpenTaskSummaryValidationResponse BuildOpenTaskSummaryResponseMessage(string message, bool boolmsg, int statuscode)
        {
            OpenTaskSummaryValidationResponse response = new OpenTaskSummaryValidationResponse();

            response.Message = message;
            response.success = boolmsg;
            response.error_code = statuscode;
            return response;
        }
    }
}
