using Microsoft.EntityFrameworkCore;
using SollisHealth.Task.Helper;
using SollisHealth.Task.Interface;
using SollisHealth.Task.Model;
using SollisHealth.Task.Model.GetAllTasks;
using SollisHealth.Task.Model.GetTaskServicelevelSummary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SollisHealth.Task.Repository
{
    public class TaskServicelevelSummaryRepo : ITaskServicelevelSummaryRepo
    {
        private readonly TaskDbContext _taskdbcontext;

        public TaskServicelevelSummaryRepo(TaskDbContext taskdbcontext)
        {
            _taskdbcontext = taskdbcontext;

        }

        /// <summary>
        /// This method returns all tasks as output 
        /// </summary>
        /// <returns>if data exists returns tasks with Task details and status =1 and if data not exits returns status 0 </returns>
        public async Task<TaskServicelevelSummaryResponse> gettaskServicelevelSummary(TaskServicelevelSummaryUserRequest taskServicelevelSummaryRequest)
        {
            List<int> multiuserids = new List<int> { };
            List<int> multiroleids = new List<int> { };

            foreach (var item in taskServicelevelSummaryRequest.TaskSummaryByServiceLevelRequest)
            {
                multiroleids.Add(item.RoleID);
                multiuserids.Add(item.UserID);

            }
            //  var taskdata = await _taskdbcontext.vm_priority_wise_summary.Where(m => m.User_ID == openTaskSumRequest.UserID && m.RoleID == openTaskSumRequest.RoleID)
            //   var taskdata = await _taskdbcontext.vm_priority_wise_summary.Where(m => m.User_ID ==1)
            var taskdata = await _taskdbcontext.vm_sla_wise_summary.Where(x => multiuserids.Contains(x.User_ID) && multiroleids.Contains(x.RoleID))
               .Select(p => new TaskServicelevelSummaryforUI
               {
                   UserID = p.User_ID == null ? 0 : p.User_ID,
                   RoleID = p.RoleID == null ? 0 : p.RoleID,
                   ServiceLevelName = p.Status == null ? null : p.Status,
                   SummaryValue = p.Count == null ? 0 : p.Count


               }).ToListAsync();

            TaskServicelevelSummaryResponse taskresponse = new TaskServicelevelSummaryResponse();
            TaskServicelevelSummaryDetails obj_tasksummaries = new TaskServicelevelSummaryDetails();
            List<TaskServicelevelSummaryDetail> objlist = new List<TaskServicelevelSummaryDetail>();

            if (taskdata.Count() != 0)
            {

                foreach (var tasksingle in taskdata)
                {
                    TaskServicelevelSumaryByStatus obj_tasksummarybystatus = new TaskServicelevelSumaryByStatus();
                    TaskServicelevelSummaryDetail obj_tasksummary = new TaskServicelevelSummaryDetail();
                    ListofService obj_listofStatus = new ListofService();
                    ServiceLevel obj_status = new ServiceLevel();

                    obj_tasksummarybystatus.UserId = tasksingle.UserID;
                    obj_tasksummarybystatus.RoleId = tasksingle.RoleID;
                    obj_status.ServiceLevelName = tasksingle.ServiceLevelName;
                    obj_status.SummaryValue = tasksingle.SummaryValue;
                    obj_listofStatus.ServiceLevel = obj_status;
                    obj_tasksummarybystatus.ServiceLevelList = obj_listofStatus;
                    obj_tasksummary.ServiceLevelSummary = obj_tasksummarybystatus;
                    objlist.Add(obj_tasksummary);
                    obj_tasksummary = null;
                    obj_tasksummarybystatus = null;
                    obj_listofStatus = null;
                    obj_status = null;
                }

                obj_tasksummaries.ServiceLevelSummaries = objlist;
                taskresponse.data = obj_tasksummaries;
                taskresponse.Message = "Getting Task Wise Service Level Summary details is successful";
                taskresponse.success = true;
                return taskresponse;
            }
            else
            {
                taskresponse.Message = "Getting Task Wise Service Level Summary details not found";
                taskresponse.success = false;
                return taskresponse;
            }
        }

    }
}
