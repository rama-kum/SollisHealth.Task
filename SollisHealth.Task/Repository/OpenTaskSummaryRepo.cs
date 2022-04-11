using Microsoft.EntityFrameworkCore;
using SollisHealth.Task.Helper;
using SollisHealth.Task.Interface;
using SollisHealth.Task.Model.GetOpenTaskSummary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SollisHealth.Task.Repository
{
    public class OpenTaskSummaryRepo : IOpenTaskSummaryRepo
    {
        private readonly TaskDbContext _taskdbcontext;

        public OpenTaskSummaryRepo(TaskDbContext taskdbcontext)
        {
            _taskdbcontext = taskdbcontext;

        }

        /// <summary>
        /// This method returns all tasks as output 
        /// </summary>
        /// <returns>if data exists returns tasks with Task details and status =1 and if data not exits returns status 0 </returns>
        public async Task<OpenTaskSummaryResponse> getOpenTaskSummary(OpenTaskSummaryUserRequest openTaskSumRequest)
        {
            List<int> multiuserids = new List<int> { };
            List<int> multiroleids = new List<int> { };

            foreach (var item in openTaskSumRequest.TaskSummaryRequest)
            {
                multiroleids.Add(item.RoleID);
                multiuserids.Add(item.UserID);

            }

            var taskdata = await _taskdbcontext.vm_status_wise_summary.Where(x => multiuserids.Contains(x.User_ID)&& multiroleids.Contains(x.RoleID))
               .Select(p => new OpenTaskSummaryforUI
               {
                   UserID = p.User_ID == null ? 0: p.User_ID,
                   RoleID = p.RoleID == null ? 0 : p.RoleID,
                   UserName = p.User_name == null ? null : p.User_name,
                   Status = p.Status == null ? null : p.Status,
                   Count = p.Count == null ? 0 : p.Count


               }).ToListAsync();

            OpenTaskSummaryResponse taskresponse = new OpenTaskSummaryResponse();
            OpenTaskSummaryDetails obj_tasksummaries = new OpenTaskSummaryDetails();
            List<OpenTaskSummaryDetail> obj_list = new List<OpenTaskSummaryDetail>();

            if (taskdata.Count() != 0)
            {
                foreach (var tasksingle in taskdata)
                {
                    OpenTaskSummaryDetail obj_tasksummary = new OpenTaskSummaryDetail();
                    TaskSumaryByStatus obj_tasksummarybystatus = new TaskSumaryByStatus();
                    ListofStatus obj_listofStatus = new ListofStatus();
                    Status obj_status = new Status();

                    obj_tasksummarybystatus.UserId = tasksingle.UserID;
                    obj_tasksummarybystatus.RoleId = tasksingle.RoleID;
                    obj_status.StatusName = tasksingle.Status;
                    obj_status.StatusValue = tasksingle.Count;
                    obj_listofStatus.Status = obj_status;
                    obj_tasksummarybystatus.StatusList = obj_listofStatus;
                    obj_tasksummary.TaskSummaryByStatus = obj_tasksummarybystatus;
                    obj_list.Add(obj_tasksummary);
                    obj_tasksummary = null;
                    obj_tasksummarybystatus = null;
                    obj_listofStatus = null;
                    obj_status = null;
                }
                obj_tasksummaries.TaskSummariesByStatus = obj_list;
                taskresponse.data = obj_tasksummaries;
                taskresponse.Message = "Getting Open Task Summary details is successful";
                taskresponse.success = true;
                return taskresponse;
            }
            else
            {
                taskresponse.Message="Open Task Summary details not found";
                taskresponse.success = false;
                return taskresponse;
            }
        }



    }
}
