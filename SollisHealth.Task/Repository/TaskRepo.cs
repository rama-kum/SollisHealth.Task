using Microsoft.EntityFrameworkCore;
using SollisHealth.Task.Helper;
using SollisHealth.Task.Interface;
using SollisHealth.Task.Model;
using SollisHealth.Task.Model.GetAllTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SollisHealth.Task.Repository
{
    public class TaskRepo : ITaskRepo
    {
        private readonly TaskDbContext _taskdbcontext;

        public TaskRepo(TaskDbContext taskdbcontext)
        {
            _taskdbcontext = taskdbcontext;

        }

        /// <summary>
        /// This method returns all tasks as output 
        /// </summary>
        /// <returns>if data exists returns tasks with Task details and status =1 and if data not exits returns status 0 </returns>
        public async Task<TaskResponse> gettaskresponse()
        {
            TaskResponse taskresponse = new TaskResponse();
            TasksDetails obj_taskDetails = new TasksDetails();
            List<TaskDetail> obj_taskDetail = new List<TaskDetail>();
           // var taskdata1 = await _taskdbcontext.vm_task_details.ToListAsync();

            var taskdata = await _taskdbcontext.vm_task_details_old
               .Select(p => new TaskDetailsforUI
               {
                   UserName=p.UserName == null  ? null: p.UserName,    
                   TaskID =p.Task_ID == 0 ? 0 : p.Task_ID,  
                   TaskOpenDate=p.Task_Open_Date == null ? System.DateTime.Now : p.Task_Open_Date,
                   RequestTypeName=p.Request_Type_Name == null ? null : p.Request_Type_Name,
                   MemberID=p.Member_ID == null ? null : p.Member_ID,
                   TaskPriorityName=p.Task_Priority_Name == null ? null : p.Task_Priority_Name,
                   SLACloseUnit=p.SLA_Close_Unit == null ? null : p.SLA_Close_Unit,
                   SLACloseVal=p.SLA_CLOSE_VAL == 0 ? 0 : p.SLA_CLOSE_VAL,
                   TaskStatusID=p.Task_Status_ID == 0 ? 0 : p.Task_Status_ID,
                   AssignedUser=p.Assigned_User == null ? null : p.Assigned_User,
                   TaskDescription=p.Task_Description == null ? null : p.Task_Description,
                   TaskStatusName=p.Task_Status_Name == null ? null : p.Task_Status_Name,
                   TaskCloseDate=p.Task_Close_Date == null ? System.DateTime.Now : p.Task_Close_Date

               }).ToListAsync();

            foreach (var tasksingle in taskdata)
            {
                obj_taskDetail.Add(new TaskDetail { Task = tasksingle });
            }


            obj_taskDetails.Tasks = obj_taskDetail;

               if (obj_taskDetails != null)
               {
                   taskresponse.data = obj_taskDetails;
                   taskresponse.success = true;
               }
               else
               {
                   taskresponse.success = false;
               }
                 return taskresponse;
        }



    }
}
