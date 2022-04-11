using Microsoft.EntityFrameworkCore;
using SollisHealth.Task.Helper;
using SollisHealth.Task.Interface;
using SollisHealth.Task.Model;
using SollisHealth.Task.Model.GetTasksByUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SollisHealth.Task.Repository
{
    public class TaskByUserRepo : ITaskByUserRepo
    {
        private readonly TaskDbContext _taskdbcontext;

        public TaskByUserRepo(TaskDbContext taskdbcontext)
        {
            _taskdbcontext = taskdbcontext;

        }

        /// <summary>
        /// This method returns all tasks as output 
        /// </summary>
        /// <returns>if data exists returns tasks with Task details and status =1 and if data not exits returns status 0 </returns>
        public async Task<TaskByUserResponse> gettaskbyuser(TaskByUserRequest taskByUserRequest)
        {
            TaskByUserResponse taskresponse = new TaskByUserResponse();
            TasksByUser obj_taskDetails = new TasksByUser();
            List<TaskByUser> obj_taskDetail = new List<TaskByUser>();

            var taskdata = await _taskdbcontext.vm_task_details.Where(m => m.role_id == taskByUserRequest.RoleId && m.Assigned_User_id == taskByUserRequest.AssignedUserId)
               .Select(p => new TaskByUserDetailsforUI
               {
                   TaskID =p.Task_ID,  
                   TaskOpenDate=p.Task_Open_Date == null ? System.DateTime.Now : p.Task_Open_Date,
                   RequestTypeName=p.Request_Type_Name == null ? null : p.Request_Type_Name,
                   RequestTypeID = p.Request_Type_ID == 0 ? 0 : p.Request_Type_ID,

                   SLAPriorityName = p.SLA_Priority_Name == null ? null : p.SLA_Priority_Name,
                   SLACloseUnit = p.SLA_Close_Unit == null ? null : p.SLA_Close_Unit,
                   SLARiskVAL = p.SLA_Risk_VAL == 0 ? 0 : p.SLA_Risk_VAL,
                   SLAExceedVAL = p.SLA_Exceed_VAL == 0 ? 0 : p.SLA_Exceed_VAL,
                   SLAPriorityID = p.SLA_Priority_ID == 0 ? 0 : p.SLA_Priority_ID,
                   TaskRoleID = p.Task_Role_ID == 0 ? 0 : p.Task_Role_ID,
                   RoleId = p.role_id == 0 ? 0 : p.role_id,
                   MemberID = p.Member_ID == null ? null : p.Member_ID,
                   MemberInfo = p.Member_Info == null ? null : p.Member_Info,
                   MemberDetails = p.Member_Details == null ? null : p.Member_Details,
                   AssignedUserId = p.Assigned_User_id == 0 ? 0 : p.Assigned_User_id,
                   AssignedUserName = p.Assigned_User_name == null ? null : p.Assigned_User_name,
                   TaskCloseDate = p.Task_Close_Date == null ? System.DateTime.Now : p.Task_Close_Date,
                   ElapsedTime = p.Elapsed_Time == null ? System.DateTime.Now.TimeOfDay.ToString(@"hh\:mm\:ss") : p.Elapsed_Time.ToString(),
                   TaskStatusName = p.task_status_name == null ? null : p.task_status_name,
                   TaskStatusID = p.Task_Status_ID == 0 ? 0 : p.Task_Status_ID,
                   Resolution = p.Resolution == null ? null : p.Resolution

               }).ToListAsync();
            if (taskdata.Count()!= 0)
            {

                foreach (var tasksingle in taskdata)
                {
                    obj_taskDetail.Add(new TaskByUser { UserTask = tasksingle });
                }


                obj_taskDetails.UserTasks = obj_taskDetail;

                if (obj_taskDetails != null)
                {
                    taskresponse.data = obj_taskDetails;
                    taskresponse.Message= "Getting Task List information for user is successful";
                    taskresponse.success = true;
                }
                else
                {
                    taskresponse.Message = "Task List information for user not found";
                    taskresponse.success = false;
                }
                return taskresponse;
            }
            else
            {
                taskresponse.Message = "Task List information for user not found";
                taskresponse.success = false;
                return taskresponse;

            }
        }



    }
}
