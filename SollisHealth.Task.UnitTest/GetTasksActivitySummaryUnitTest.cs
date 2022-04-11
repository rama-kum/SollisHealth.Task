using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SollisHealth.Task.Controllers.v1;
using SollisHealth.Task.Helper;
using SollisHealth.Task.Interface;
using SollisHealth.Task.Model;
using SollisHealth.Task.Model.GetTaskActivitySummary;
using SollisHealth.Task.Repository;
using SollisHealth.Task.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SollisHealth.Task.UnitTest
{
    [TestClass]
    public class GetTasksActivitySummaryUnitTest
    {
        [TestMethod]
        public void GetTaskActivitySummaryUnitTest_Repository_SUCCESS()
        {
            var options = new DbContextOptionsBuilder<TaskDbContext>()
                        .UseInMemoryDatabase(databaseName: "TaskListDataBase")
                        .Options;

            using (var context = new TaskDbContext(options))
            {
                context.vm_priority_wise_summary.Add(new TaskActivitySummaryOutput
                {
                    User_ID = 1,
                    RoleID = 1,
                    Priority_Name = "dd",
                    No_Of_Priority = 1
                });
 
 
                context.SaveChanges();

                TaskActivitySummaryRepo repoObject = new TaskActivitySummaryRepo(context);
                TaskActivitySummaryUserRequest usertaskpriority = new TaskActivitySummaryUserRequest();
                List<TaskActivitySummaryRequest> userrequest_list = new List<TaskActivitySummaryRequest>();
                TaskActivitySummaryRequest userrequest = new TaskActivitySummaryRequest();
                userrequest.UserID = 1;
                userrequest.RoleID = 1;
                userrequest_list.Add(userrequest);
                usertaskpriority.TaskSummaryByPriorityRequest = userrequest_list;

                Task<TaskActivitySummaryResponse> result = repoObject.gettaskActivitySummary(usertaskpriority);

                Assert.AreEqual(result.Result.success, true);
                Assert.IsTrue(result.IsCompletedSuccessfully);
            }

        }

    

        [TestMethod]
        public void GetTaskActivitySummaryUnitTest_Repository_FAILURE()
        {
            var options = new DbContextOptionsBuilder<TaskDbContext>()
                        .UseInMemoryDatabase(databaseName: "TaskListDataBase")
                        .Options;

            using (var context = new TaskDbContext(options))
            {

                TaskActivitySummaryRepo repoObject = new TaskActivitySummaryRepo(context);
                TaskActivitySummaryUserRequest usertaskpriority = new TaskActivitySummaryUserRequest();
                List<TaskActivitySummaryRequest> userrequest_list = new List<TaskActivitySummaryRequest>();
                TaskActivitySummaryRequest userrequest = new TaskActivitySummaryRequest();
                userrequest_list.Add(userrequest);
                usertaskpriority.TaskSummaryByPriorityRequest = userrequest_list;
                Task<TaskActivitySummaryResponse> result = repoObject.gettaskActivitySummary(usertaskpriority);

                Assert.AreEqual(result.Result.success,false);                
                Assert.IsTrue(result.IsCompletedSuccessfully);
            }
        }


        [TestMethod]
        public void GetTaskActivitySummaryUnitTest_SUCCESS_BO()
        {
            TaskActivitySummaryUserRequest usertaskpriority = new TaskActivitySummaryUserRequest();
            List<TaskActivitySummaryRequest> userrequest_list = new List<TaskActivitySummaryRequest>();
            TaskActivitySummaryRequest userrequest = new TaskActivitySummaryRequest();
            userrequest.UserID = 1;
            userrequest.RoleID = 1;
            userrequest_list.Add(userrequest);
            usertaskpriority.TaskSummaryByPriorityRequest = userrequest_list;

            var mockRepo = new Mock<ITaskActivitySummaryRepo>();
            mockRepo.Setup(x => x.gettaskActivitySummary(usertaskpriority)).Returns(GetTasksValiddata);

            TaskActivitySummaryBO userBO = new TaskActivitySummaryBO(mockRepo.Object);
            Task<TaskActivitySummaryResponse> result = userBO.gettaskActivitySummary(usertaskpriority);

            Assert.IsTrue(result.IsCompletedSuccessfully);
            Assert.AreEqual(result.Result.success, true);
        }

        private Task<TaskActivitySummaryResponse> GetTasksValiddata()
        {
            TaskActivitySummaryResponse obj_taskresponse = new TaskActivitySummaryResponse();
            TaskActivitySummaryDetails obj_tasksummaries = new TaskActivitySummaryDetails();
            List<TaskActivitySummaryDetail> objlist = new List<TaskActivitySummaryDetail>();

            TaskActivitySummaryforUI output = new TaskActivitySummaryforUI();
            output.RoleID = 1;
            output.UserID = 1;
            output.PriorityName="ppp";
            output.PriorityValue = 1;

            TaskActivitySumaryByStatus obj_tasksummarybystatus = new TaskActivitySumaryByStatus();
            TaskActivitySummaryDetail obj_tasksummary = new TaskActivitySummaryDetail();
            ListofPriority obj_listofStatus = new ListofPriority();
            Priority obj_status = new Priority();

            obj_tasksummarybystatus.UserId = output.UserID;
            obj_tasksummarybystatus.RoleId = output.RoleID;
            obj_status.PriorityName = output.PriorityName;
            obj_status.PriorityValue = output.PriorityValue;
            obj_listofStatus.Priority = obj_status;
            obj_tasksummarybystatus.PriorityList = obj_listofStatus;
            obj_tasksummary.TaskSummaryByPriority = obj_tasksummarybystatus;
            objlist.Add(obj_tasksummary);      

            obj_tasksummaries.TaskSummariesByPriority = objlist;
            obj_taskresponse.data = obj_tasksummaries;
            obj_taskresponse.success = true;

            return System.Threading.Tasks.Task.FromResult(obj_taskresponse);
        }

        [TestMethod]
        public void GetTaskActivitySummaryUnitTest_FAILURE_BO()
        {
            TaskActivitySummaryUserRequest usertaskpriority = new TaskActivitySummaryUserRequest();
            List<TaskActivitySummaryRequest> userrequest_list = new List<TaskActivitySummaryRequest>();
            TaskActivitySummaryRequest userrequest = new TaskActivitySummaryRequest();
             userrequest_list.Add(userrequest);
            usertaskpriority.TaskSummaryByPriorityRequest = userrequest_list;
            var mockRepo = new Mock<ITaskActivitySummaryRepo>();
            mockRepo.Setup(x => x.gettaskActivitySummary(usertaskpriority)).Returns(GetTasksInValiddata);

            TaskActivitySummaryBO userBO = new TaskActivitySummaryBO(mockRepo.Object);
            Task<TaskActivitySummaryResponse> result = userBO.gettaskActivitySummary(usertaskpriority);

            Assert.IsTrue(result.IsCompletedSuccessfully);
            Assert.AreEqual(result.Result.success, false);
        }

        private Task<TaskActivitySummaryResponse> GetTasksInValiddata()
        {
            TaskActivitySummaryResponse obj_taskresponse = new TaskActivitySummaryResponse();
            TaskActivitySummaryDetails obj_tasksummaries = new TaskActivitySummaryDetails();
            List<TaskActivitySummaryDetail> objlist = new List<TaskActivitySummaryDetail>();

            TaskActivitySummaryforUI output = new TaskActivitySummaryforUI();
            TaskActivitySumaryByStatus obj_tasksummarybystatus = new TaskActivitySumaryByStatus();
            TaskActivitySummaryDetail obj_tasksummary = new TaskActivitySummaryDetail();
            ListofPriority obj_listofStatus = new ListofPriority();
            Priority obj_status = new Priority();

            obj_tasksummarybystatus.UserId = output.UserID;
            obj_tasksummarybystatus.RoleId = output.RoleID;
            obj_status.PriorityName = output.PriorityName;
            obj_status.PriorityValue = output.PriorityValue;
            obj_listofStatus.Priority = obj_status;
            obj_tasksummarybystatus.PriorityList = obj_listofStatus;
            obj_tasksummary.TaskSummaryByPriority = obj_tasksummarybystatus;
            objlist.Add(obj_tasksummary);

            obj_tasksummaries.TaskSummariesByPriority = objlist;
            obj_taskresponse.data = obj_tasksummaries;
            obj_taskresponse.success = false;

            return System.Threading.Tasks.Task.FromResult(obj_taskresponse);
        }

 

        [TestMethod]
        public void GetTasksListByUserUnitTest_SUCCESS_Controller()
        {
            TaskActivitySummaryUserRequest usertaskpriority = new TaskActivitySummaryUserRequest();
            List<TaskActivitySummaryRequest> userrequest_list = new List<TaskActivitySummaryRequest>();
            TaskActivitySummaryRequest userrequest = new TaskActivitySummaryRequest();
            userrequest.UserID = 1;
            userrequest.RoleID = 1;
            userrequest_list.Add(userrequest);
            usertaskpriority.TaskSummaryByPriorityRequest = userrequest_list;

            var mockLogger = new Mock<ILogger<TaskActivitySummaryController>>();
            ILogger<TaskActivitySummaryController> logger = mockLogger.Object;

            var mocktask = new Mock<ITaskActivitySummaryBO>();
            TaskActivitySummaryController taskControllerobj = new TaskActivitySummaryController(logger, mocktask.Object);
            mocktask.Setup(x => x.gettaskActivitySummary(usertaskpriority)).Returns(GetTasksValiddata);
            Task<IActionResult> result = taskControllerobj.GetTaskSummaryByPriority(usertaskpriority);
            ObjectResult obj = (ObjectResult)result.Result;
            Assert.IsTrue(result.IsCompletedSuccessfully);
            Assert.AreEqual(obj.StatusCode, 200);
        }

        /// <summary>
        /// Check User TaskByUser Controller class if exists member ID
        /// </summary>
        [TestMethod]
        public void GetTaskActivitySummaryUnitTest_FAILURE_Controller()
        {
            TaskActivitySummaryUserRequest usertaskpriority = new TaskActivitySummaryUserRequest();
            List<TaskActivitySummaryRequest> userrequest_list = new List<TaskActivitySummaryRequest>();
            TaskActivitySummaryRequest userrequest = new TaskActivitySummaryRequest();
            userrequest_list.Add(userrequest);
            usertaskpriority.TaskSummaryByPriorityRequest = userrequest_list;

            var mockLogger = new Mock<ILogger<TaskActivitySummaryController>>();
            ILogger<TaskActivitySummaryController> logger = mockLogger.Object;

            var mocktask = new Mock<ITaskActivitySummaryBO>();
            TaskActivitySummaryController taskControllerobj = new TaskActivitySummaryController(logger,mocktask.Object);
            mocktask.Setup(x => x.gettaskActivitySummary(usertaskpriority)).Returns(GetTasksInValiddata);
            Task<IActionResult> result = taskControllerobj.GetTaskSummaryByPriority(usertaskpriority);
            ObjectResult obj = (ObjectResult)result.Result;
            Assert.IsTrue(result.IsCompletedSuccessfully);
            Assert.AreEqual(obj.StatusCode, 400);
        }

    }
}
