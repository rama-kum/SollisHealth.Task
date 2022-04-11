using Microsoft.EntityFrameworkCore;
using SollisHealth.Task.Helper;
using SollisHealth.Task.Interface;
using SollisHealth.Task.Model;
using SollisHealth.Task.Model.UserCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SollisHealth.Task.Repository
{
  
    public class UserCasesRepo : IUserRepo
    {
        private readonly TaskDbContext _taskdbcontext;

        public UserCasesRepo(TaskDbContext taskdbcontext)
        {
            _taskdbcontext = taskdbcontext;

        }

        /// <summary>
        /// This method returns all tasks as output 
        /// </summary>
        /// <returns>if data exists returns tasks with Task details and status =1 and if data not exits returns status 0 </returns>
        public async Task<UserCasesResponse> getusercases()
        {
            UserCasesResponse userresponse = new UserCasesResponse();
            UserSummaries obj_userDetails = new UserSummaries();
            List<UserSummary> obj_userDetail = new List<UserSummary>();


            var usersummarydata = await _taskdbcontext.vm_task_sla_old//.FromSqlRaw($"Select * from vm_task_sla")
               .Select(p => new UserOpenCasesUI
               {
                   Title=p.Title,
                   Username=p.UserName,
                   OpenCases=p.OpenCases

               }).ToListAsync();


            foreach (var usersingle in usersummarydata)
            {

                obj_userDetail.Add(new UserSummary { summary = usersingle });
            }

            obj_userDetails.summaries = obj_userDetail;

            if (obj_userDetails != null)
            {
                userresponse.data = obj_userDetails;
                userresponse.success = true;
            }
            else
            {
                userresponse.success = false;
            }
            return userresponse;
        }


    }
}


