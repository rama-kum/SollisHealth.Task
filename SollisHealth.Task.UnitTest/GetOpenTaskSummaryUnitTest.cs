using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SollisHealth.Task.Controllers.v1;
using SollisHealth.Task.Helper;
using SollisHealth.Task.Interface;
using SollisHealth.Task.Model;
using SollisHealth.Task.Model.GetOpenTaskSummary;
using SollisHealth.Task.Repository;
using SollisHealth.Task.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SollisHealth.Task.UnitTest
{
    [TestClass]
    public class GetOpenTaskSummaryUnitTest
    {
        [TestMethod]
        public void GetOpenTaskSummaryUnitTest_Repository_SUCCESS()
        {
            var options = new DbContextOptionsBuilder<TaskDbContext>()
                        .UseInMemoryDatabase(databaseName: "TaskListDataBase")
                        .Options;

            using (var context = new TaskDbContext(options))
            {
                context.vm_status_wise_summary.Add(new OpenTaskSummaryOutput
                {
                    User_ID = 1,
                    RoleID = 1,
                    Status = "dd",
                    Count = 1
                });
 
 
                context.SaveChanges();

                OpenTaskSummaryRepo repoObject = new OpenTaskSummaryRepo(context);
                OpenTaskSummaryUserRequest usertaskpriority = new OpenTaskSummaryUserRequest();
                List<OpenTaskSummaryRequest> userrequest_list = new List<OpenTaskSummaryRequest>();
                OpenTaskSummaryRequest userrequest = new OpenTaskSummaryRequest();
                userrequest.UserID = 1;
                userrequest.RoleID = 1;
                userrequest_list.Add(userrequest);
                usertaskpriority.TaskSummaryRequest = userrequest_list;

                Task<OpenTaskSummaryResponse> result = repoObject.getOpenTaskSummary(usertaskpriority);

                Assert.AreEqual(result.Result.success, true);
                Assert.IsTrue(result.IsCompletedSuccessfully);
            }

        }

    

        [TestMethod]
        public void GetOpenTaskSummaryUnitTest_Repository_FAILURE()
        {
            var options = new DbContextOptionsBuilder<TaskDbContext>()
                        .UseInMemoryDatabase(databaseName: "TaskListDataBase")
                        .Options;

            using (var context = new TaskDbContext(options))
            {

                OpenTaskSummaryRepo repoObject = new OpenTaskSummaryRepo(context);
                OpenTaskSummaryUserRequest usertaskpriority = new OpenTaskSummaryUserRequest();
                List<OpenTaskSummaryRequest> userrequest_list = new List<OpenTaskSummaryRequest>();
                OpenTaskSummaryRequest userrequest = new OpenTaskSummaryRequest();
                userrequest_list.Add(userrequest);
                usertaskpriority.TaskSummaryRequest = userrequest_list;
                Task<OpenTaskSummaryResponse> result = repoObject.getOpenTaskSummary(usertaskpriority);

                Assert.AreEqual(result.Result.success,false);                
                Assert.IsTrue(result.IsCompletedSuccessfully);
            }
        }


        [TestMethod]
        public void GetOpenTaskSummaryUnitTest_SUCCESS_BO()
        {
            OpenTaskSummaryUserRequest usertaskpriority = new OpenTaskSummaryUserRequest();
            List<OpenTaskSummaryRequest> userrequest_list = new List<OpenTaskSummaryRequest>();
            OpenTaskSummaryRequest userrequest = new OpenTaskSummaryRequest();
            userrequest.UserID = 1;
            userrequest.RoleID = 1;
            userrequest_list.Add(userrequest);
            usertaskpriority.TaskSummaryRequest = userrequest_list;

            var mockRepo = new Mock<IOpenTaskSummaryRepo>();
            mockRepo.Setup(x => x.getOpenTaskSummary(usertaskpriority)).Returns(GetTasksValiddata);

            OpenTaskSummaryBO userBO = new OpenTaskSummaryBO(mockRepo.Object);
            Task<OpenTaskSummaryResponse> result = userBO.getOpenTaskSummary(usertaskpriority);

            Assert.IsTrue(result.IsCompletedSuccessfully);
            Assert.AreEqual(result.Result.success, true);
        }

        private Task<OpenTaskSummaryResponse> GetTasksValiddata()
        {
            OpenTaskSummaryResponse obj_taskresponse = new OpenTaskSummaryResponse();
            OpenTaskSummaryDetails obj_tasksummaries = new OpenTaskSummaryDetails();
            List<OpenTaskSummaryDetail> objlist = new List<OpenTaskSummaryDetail>();

            OpenTaskSummaryforUI output = new OpenTaskSummaryforUI();
            output.RoleID = 1;
            output.UserID = 1;
            output.Status="ppp";
            output.Count = 1;

            OpenTaskSummaryDetail obj_tasksummary = new OpenTaskSummaryDetail();
            TaskSumaryByStatus obj_tasksummarybystatus = new TaskSumaryByStatus();
            ListofStatus obj_listofStatus = new ListofStatus();
            Status obj_status = new Status();

            obj_tasksummarybystatus.UserId = output.UserID;
            obj_tasksummarybystatus.RoleId = output.RoleID;
            obj_status.StatusName = output.Status;
            obj_status.StatusValue = output.Count;
            obj_listofStatus.Status = obj_status;
            obj_tasksummarybystatus.StatusList = obj_listofStatus;
            obj_tasksummary.TaskSummaryByStatus = obj_tasksummarybystatus;
            objlist.Add(obj_tasksummary);

            obj_tasksummaries.TaskSummariesByStatus = objlist;
            obj_taskresponse.data = obj_tasksummaries;
            obj_taskresponse.success = true;

            return System.Threading.Tasks.Task.FromResult(obj_taskresponse);
        }

        [TestMethod]
        public void GetOpenTaskSummaryUnitTest_FAILURE_BO()
        {
            OpenTaskSummaryUserRequest usertaskpriority = new OpenTaskSummaryUserRequest();
            List<OpenTaskSummaryRequest> userrequest_list = new List<OpenTaskSummaryRequest>();
            OpenTaskSummaryRequest userrequest = new OpenTaskSummaryRequest();
             userrequest_list.Add(userrequest);
            usertaskpriority.TaskSummaryRequest = userrequest_list;
            var mockRepo = new Mock<IOpenTaskSummaryRepo>();
            mockRepo.Setup(x => x.getOpenTaskSummary(usertaskpriority)).Returns(GetTasksInValiddata);

            OpenTaskSummaryBO userBO = new OpenTaskSummaryBO(mockRepo.Object);
            Task<OpenTaskSummaryResponse> result = userBO.getOpenTaskSummary(usertaskpriority);

            Assert.IsTrue(result.IsCompletedSuccessfully);
            Assert.AreEqual(result.Result.success, false);
        }

        private Task<OpenTaskSummaryResponse> GetTasksInValiddata()
        {
            OpenTaskSummaryResponse obj_taskresponse = new OpenTaskSummaryResponse();
            OpenTaskSummaryDetails obj_tasksummaries = new OpenTaskSummaryDetails();
            List<OpenTaskSummaryDetail> objlist = new List<OpenTaskSummaryDetail>();

            OpenTaskSummaryforUI output = new OpenTaskSummaryforUI();
            OpenTaskSummaryDetail obj_tasksummary = new OpenTaskSummaryDetail();
            TaskSumaryByStatus obj_tasksummarybystatus = new TaskSumaryByStatus();
            ListofStatus obj_listofStatus = new ListofStatus();
            Status obj_status = new Status();

            obj_tasksummarybystatus.UserId = output.UserID;
            obj_tasksummarybystatus.RoleId = output.RoleID;
            obj_status.StatusName = output.Status;
            obj_status.StatusValue = output.Count;
            obj_listofStatus.Status = obj_status;
            obj_tasksummarybystatus.StatusList = obj_listofStatus;
            obj_tasksummary.TaskSummaryByStatus = obj_tasksummarybystatus;
            objlist.Add(obj_tasksummary);

            obj_tasksummaries.TaskSummariesByStatus = objlist;
            obj_taskresponse.data = obj_tasksummaries;
            obj_taskresponse.success = false;

            return System.Threading.Tasks.Task.FromResult(obj_taskresponse);
        }

 

        [TestMethod]
        public void GetOpenTaskUnitTest_SUCCESS_Controller()
        {
            OpenTaskSummaryUserRequest usertaskpriority = new OpenTaskSummaryUserRequest();
            List<OpenTaskSummaryRequest> userrequest_list = new List<OpenTaskSummaryRequest>();
            OpenTaskSummaryRequest userrequest = new OpenTaskSummaryRequest();
            userrequest.UserID = 1;
            userrequest.RoleID = 1;
            userrequest_list.Add(userrequest);
            usertaskpriority.TaskSummaryRequest = userrequest_list;

            var mockLogger = new Mock<ILogger<OpenTaskSummaryController>>();
            ILogger<OpenTaskSummaryController> logger = mockLogger.Object;

            var mocktask = new Mock<IOpenTaskSummaryBO>();
            OpenTaskSummaryController taskControllerobj = new OpenTaskSummaryController(logger, mocktask.Object);
            mocktask.Setup(x => x.getOpenTaskSummary(usertaskpriority)).Returns(GetTasksValiddata);
            Task<IActionResult> result = taskControllerobj.GetOpenTaskSummary(usertaskpriority);
            ObjectResult obj = (ObjectResult)result.Result;
            Assert.IsTrue(result.IsCompletedSuccessfully);
            Assert.AreEqual(obj.StatusCode, 200);
        }

        /// <summary>
        /// Check User Open Task Controller class if exists member ID
        /// </summary>
        [TestMethod]
        public void GetOpenTaskSummaryUnitTest_FAILURE_Controller()
        {
            OpenTaskSummaryUserRequest usertaskpriority = new OpenTaskSummaryUserRequest();
            List<OpenTaskSummaryRequest> userrequest_list = new List<OpenTaskSummaryRequest>();
            OpenTaskSummaryRequest userrequest = new OpenTaskSummaryRequest();
            userrequest_list.Add(userrequest);
            usertaskpriority.TaskSummaryRequest = userrequest_list;

            var mockLogger = new Mock<ILogger<OpenTaskSummaryController>>();
            ILogger<OpenTaskSummaryController> logger = mockLogger.Object;

            var mocktask = new Mock<IOpenTaskSummaryBO>();
            OpenTaskSummaryController taskControllerobj = new OpenTaskSummaryController(logger,mocktask.Object);
            mocktask.Setup(x => x.getOpenTaskSummary(usertaskpriority)).Returns(GetTasksInValiddata);
            Task<IActionResult> result = taskControllerobj.GetOpenTaskSummary(usertaskpriority);
            ObjectResult obj = (ObjectResult)result.Result;
            Assert.IsTrue(result.IsCompletedSuccessfully);
            Assert.AreEqual(obj.StatusCode, 400);
        }

    }
}
