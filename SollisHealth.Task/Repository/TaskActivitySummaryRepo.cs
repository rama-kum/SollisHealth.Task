using Microsoft.EntityFrameworkCore;
using SollisHealth.Task.Helper;
using SollisHealth.Task.Interface;
using SollisHealth.Task.Model;
using SollisHealth.Task.Model.GetAllTasks;
using SollisHealth.Task.Model.GetTaskActivitySummary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SollisHealth.Task.Repository
{
    public class TaskActivitySummaryRepo : ITaskActivitySummaryRepo
    {
        private readonly TaskDbContext _taskdbcontext;

        public TaskActivitySummaryRepo(TaskDbContext taskdbcontext)
        {
            _taskdbcontext = taskdbcontext;

        }

        /// <summary>
        /// This method returns all tasks as output 
        /// </summary>
        /// <returns>if data exists returns tasks with Task details and status =1 and if data not exits returns status 0 </returns>
        public async Task<TaskActivitySummaryResponse> gettaskActivitySummary(TaskActivitySummaryUserRequest taskActivitySummaryUser)
        {
            List<int> multiuserids = new List<int> { };
            List<int> multiroleids = new List<int> { };

            foreach (var item in taskActivitySummaryUser.TaskSummaryByPriorityRequest)
            {
                multiroleids.Add(item.RoleID);
                multiuserids.Add(item.UserID);

            }
            //  var taskdata = await _taskdbcontext.vm_priority_wise_summary.Where(m => m.User_ID == openTaskSumRequest.UserID && m.RoleID == openTaskSumRequest.RoleID)
            //   var taskdata = await _taskdbcontext.vm_priority_wise_summary.Where(m => m.User_ID ==1)
            var taskdata = await _taskdbcontext.vm_priority_wise_summary.Where(x => multiuserids.Contains(x.User_ID) && multiroleids.Contains(x.RoleID))
               .Select(p => new TaskActivitySummaryforUI
               {
                   UserID = p.User_ID == null ? 0 : p.User_ID,
                   RoleID = p.RoleID == null ? 0 : p.RoleID,
                   PriorityName = p.Priority_Name == null ? null : p.Priority_Name,
                   PriorityValue = p.No_Of_Priority == null ? 0 : p.No_Of_Priority


               }).ToListAsync();

            TaskActivitySummaryResponse taskresponse = new TaskActivitySummaryResponse();  
            TaskActivitySummaryDetails obj_tasksummaries = new TaskActivitySummaryDetails();
            List<TaskActivitySummaryDetail> objlist = new List<TaskActivitySummaryDetail>(); 

            if (taskdata.Count() != 0)
            {              
                
                foreach (var tasksingle in taskdata)
                {
                    TaskActivitySumaryByStatus obj_tasksummarybystatus = new TaskActivitySumaryByStatus();
                    TaskActivitySummaryDetail obj_tasksummary = new TaskActivitySummaryDetail();
                    ListofPriority obj_listofStatus = new ListofPriority();
                    Priority obj_status = new Priority();

                    obj_tasksummarybystatus.UserId = tasksingle.UserID;
                    obj_tasksummarybystatus.RoleId = tasksingle.RoleID;
                    obj_status.PriorityName = tasksingle.PriorityName;
                    obj_status.PriorityValue = tasksingle.PriorityValue;
                    obj_listofStatus.Priority = obj_status;
                    obj_tasksummarybystatus.PriorityList = obj_listofStatus;
                    obj_tasksummary.TaskSummaryByPriority = obj_tasksummarybystatus;
                    objlist.Add( obj_tasksummary);
                    obj_tasksummary = null;
                    obj_tasksummarybystatus = null;
                    obj_listofStatus = null;
                    obj_status = null;
                }

                obj_tasksummaries.TaskSummariesByPriority = objlist;
                taskresponse.data = obj_tasksummaries;
                taskresponse.Message = "Getting Task Summary by Priority details is successful";
                taskresponse.success = true;
                return taskresponse;
            }
            else
            {
                taskresponse.Message = "Getting Task Summary by Priority details not found";
                taskresponse.success = false;
                return taskresponse;
            }
        }

    }
  
}
