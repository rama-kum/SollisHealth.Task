using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SollisHealth.Task.Controllers.v1;
using SollisHealth.Task.Helper;
using SollisHealth.Task.Interface;
using SollisHealth.Task.Model;
using SollisHealth.Task.Model.GetTaskServicelevelSummary;
using SollisHealth.Task.Repository;
using SollisHealth.Task.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SollisHealth.Task.UnitTest
{
    [TestClass]
    public class GetTaskServicelevelSummaryUnitTest
    {
        [TestMethod]
        public void GetTaskServicelevelSummaryUnitTest_Repository_SUCCESS()
        {
            var options = new DbContextOptionsBuilder<TaskDbContext>()
                        .UseInMemoryDatabase(databaseName: "TaskListDataBase")
                        .Options;

            using (var context = new TaskDbContext(options))
            {
                context.vm_sla_wise_summary.Add(new TaskServicelevelSummaryOutput
                {
                    User_ID = 1,
                    RoleID = 1,
                    Status = "dd",
                    Count = 1
                });
 
 
                context.SaveChanges();

                TaskServicelevelSummaryRepo repoObject = new TaskServicelevelSummaryRepo(context);
                TaskServicelevelSummaryUserRequest usertaskpriority = new TaskServicelevelSummaryUserRequest();
                List<TaskServicelevelSummaryRequest> userrequest_list = new List<TaskServicelevelSummaryRequest>();
                TaskServicelevelSummaryRequest userrequest = new TaskServicelevelSummaryRequest();
                userrequest.UserID = 1;
                userrequest.RoleID = 1;
                userrequest_list.Add(userrequest);
                usertaskpriority.TaskSummaryByServiceLevelRequest = userrequest_list;

                Task<TaskServicelevelSummaryResponse> result = repoObject.gettaskServicelevelSummary(usertaskpriority);

                Assert.AreEqual(result.Result.success, true);
                Assert.IsTrue(result.IsCompletedSuccessfully);
            }

        }

    

        [TestMethod]
        public void GetTaskServicelevelSummaryUnitTest_Repository_FAILURE()
        {
            var options = new DbContextOptionsBuilder<TaskDbContext>()
                        .UseInMemoryDatabase(databaseName: "TaskListDataBase")
                        .Options;

            using (var context = new TaskDbContext(options))
            {

                TaskServicelevelSummaryRepo repoObject = new TaskServicelevelSummaryRepo(context);
                TaskServicelevelSummaryUserRequest usertaskpriority = new TaskServicelevelSummaryUserRequest();
                List<TaskServicelevelSummaryRequest> userrequest_list = new List<TaskServicelevelSummaryRequest>();
                TaskServicelevelSummaryRequest userrequest = new TaskServicelevelSummaryRequest();
                userrequest_list.Add(userrequest);
                usertaskpriority.TaskSummaryByServiceLevelRequest = userrequest_list;
                Task<TaskServicelevelSummaryResponse> result = repoObject.gettaskServicelevelSummary(usertaskpriority);

                Assert.AreEqual(result.Result.success,false);                
                Assert.IsTrue(result.IsCompletedSuccessfully);
            }
        }


        [TestMethod]
        public void GetTaskActivitySummaryUnitTest_SUCCESS_BO()
        {
            TaskServicelevelSummaryUserRequest usertaskpriority = new TaskServicelevelSummaryUserRequest();
            List<TaskServicelevelSummaryRequest> userrequest_list = new List<TaskServicelevelSummaryRequest>();
            TaskServicelevelSummaryRequest userrequest = new TaskServicelevelSummaryRequest();
            userrequest.UserID = 1;
            userrequest.RoleID = 1;
            userrequest_list.Add(userrequest);
            usertaskpriority.TaskSummaryByServiceLevelRequest = userrequest_list;

            var mockRepo = new Mock<ITaskServicelevelSummaryRepo>();
            mockRepo.Setup(x => x.gettaskServicelevelSummary(usertaskpriority)).Returns(GetTasksValiddata);

            TaskServicelevelSummaryBO userBO = new TaskServicelevelSummaryBO(mockRepo.Object);
            Task<TaskServicelevelSummaryResponse> result = userBO.gettaskServicelevelSummary(usertaskpriority);

            Assert.IsTrue(result.IsCompletedSuccessfully);
            Assert.AreEqual(result.Result.success, true);
        }

        private Task<TaskServicelevelSummaryResponse> GetTasksValiddata()
        {
            TaskServicelevelSummaryResponse obj_taskresponse = new TaskServicelevelSummaryResponse();
            TaskServicelevelSummaryDetails obj_tasksummaries = new TaskServicelevelSummaryDetails();
            List<TaskServicelevelSummaryDetail> objlist = new List<TaskServicelevelSummaryDetail>();

            TaskServicelevelSummaryforUI output = new TaskServicelevelSummaryforUI();
            output.RoleID = 1;
            output.UserID = 1;
            output.ServiceLevelName="ppp";
            output.SummaryValue = 1;

            TaskServicelevelSumaryByStatus obj_tasksummarybystatus = new TaskServicelevelSumaryByStatus();
            TaskServicelevelSummaryDetail obj_tasksummary = new TaskServicelevelSummaryDetail();
            ListofService obj_listofStatus = new ListofService();
            ServiceLevel obj_status = new ServiceLevel();

            obj_tasksummarybystatus.UserId = output.UserID;
            obj_tasksummarybystatus.RoleId = output.RoleID;
            obj_status.ServiceLevelName = output.ServiceLevelName;
            obj_status.SummaryValue = output.SummaryValue;
            obj_listofStatus.ServiceLevel = obj_status;
            obj_tasksummarybystatus.ServiceLevelList = obj_listofStatus;
            obj_tasksummary.ServiceLevelSummary = obj_tasksummarybystatus;
            objlist.Add(obj_tasksummary);  

            obj_tasksummaries.ServiceLevelSummaries = objlist;
            obj_taskresponse.data = obj_tasksummaries;
            obj_taskresponse.success = true;

            return System.Threading.Tasks.Task.FromResult(obj_taskresponse);
        }

        [TestMethod]
        public void GetTaskServicelevelSummaryUnitTest_FAILURE_BO()
        {
            TaskServicelevelSummaryUserRequest usertaskpriority = new TaskServicelevelSummaryUserRequest();
            List<TaskServicelevelSummaryRequest> userrequest_list = new List<TaskServicelevelSummaryRequest>();
            TaskServicelevelSummaryRequest userrequest = new TaskServicelevelSummaryRequest();
             userrequest_list.Add(userrequest);
            usertaskpriority.TaskSummaryByServiceLevelRequest = userrequest_list;
            var mockRepo = new Mock<ITaskServicelevelSummaryRepo>();
            mockRepo.Setup(x => x.gettaskServicelevelSummary(usertaskpriority)).Returns(GetTasksInValiddata);

            TaskServicelevelSummaryBO userBO = new TaskServicelevelSummaryBO(mockRepo.Object);
            Task<TaskServicelevelSummaryResponse> result = userBO.gettaskServicelevelSummary(usertaskpriority);

            Assert.IsTrue(result.IsCompletedSuccessfully);
            Assert.AreEqual(result.Result.success, false);
        }

        private Task<TaskServicelevelSummaryResponse> GetTasksInValiddata()
        {
            TaskServicelevelSummaryResponse obj_taskresponse = new TaskServicelevelSummaryResponse();
            TaskServicelevelSummaryDetails obj_tasksummaries = new TaskServicelevelSummaryDetails();
            List<TaskServicelevelSummaryDetail> objlist = new List<TaskServicelevelSummaryDetail>();

            TaskServicelevelSummaryforUI output = new TaskServicelevelSummaryforUI();
            TaskServicelevelSumaryByStatus obj_tasksummarybystatus = new TaskServicelevelSumaryByStatus();
            TaskServicelevelSummaryDetail obj_tasksummary = new TaskServicelevelSummaryDetail();
            ListofService obj_listofStatus = new ListofService();
            ServiceLevel obj_status = new ServiceLevel();

            obj_tasksummarybystatus.UserId = output.UserID;
            obj_tasksummarybystatus.RoleId = output.RoleID;
            obj_status.ServiceLevelName = output.ServiceLevelName;
            obj_status.SummaryValue = output.SummaryValue;
            obj_listofStatus.ServiceLevel = obj_status;
            obj_tasksummarybystatus.ServiceLevelList = obj_listofStatus;
            obj_tasksummary.ServiceLevelSummary = obj_tasksummarybystatus;
            objlist.Add(obj_tasksummary);

            obj_tasksummaries.ServiceLevelSummaries = objlist;
            obj_taskresponse.data = obj_tasksummaries;
            obj_taskresponse.success = false;

            return System.Threading.Tasks.Task.FromResult(obj_taskresponse);
        }

 

        [TestMethod]
        public void GetTasksListByUserUnitTest_SUCCESS_Controller()
        {
            TaskServicelevelSummaryUserRequest usertaskpriority = new TaskServicelevelSummaryUserRequest();
            List<TaskServicelevelSummaryRequest> userrequest_list = new List<TaskServicelevelSummaryRequest>();
            TaskServicelevelSummaryRequest userrequest = new TaskServicelevelSummaryRequest();
            userrequest.UserID = 1;
            userrequest.RoleID = 1;
            userrequest_list.Add(userrequest);
            usertaskpriority.TaskSummaryByServiceLevelRequest = userrequest_list;

            var mockLogger = new Mock<ILogger<TaskServicelevelSummaryController>>();
            ILogger<TaskServicelevelSummaryController> logger = mockLogger.Object;

            var mocktask = new Mock<ITaskServicelevelSummaryBO>();
            TaskServicelevelSummaryController taskControllerobj = new TaskServicelevelSummaryController(logger, mocktask.Object);
            mocktask.Setup(x => x.gettaskServicelevelSummary(usertaskpriority)).Returns(GetTasksValiddata);
            Task<IActionResult> result = taskControllerobj.GetTaskwiseServiceLevelSummary(usertaskpriority);
            ObjectResult obj = (ObjectResult)result.Result;
            Assert.IsTrue(result.IsCompletedSuccessfully);
            Assert.AreEqual(obj.StatusCode, 200);
        }

        /// <summary>
        /// Check User TaskServicelevel Controller class if exists member ID
        /// </summary>
        [TestMethod]
        public void GetTaskActivitySummaryUnitTest_FAILURE_Controller()
        {
            TaskServicelevelSummaryUserRequest usertaskpriority = new TaskServicelevelSummaryUserRequest();
            List<TaskServicelevelSummaryRequest> userrequest_list = new List<TaskServicelevelSummaryRequest>();
            TaskServicelevelSummaryRequest userrequest = new TaskServicelevelSummaryRequest();
            userrequest_list.Add(userrequest);
            usertaskpriority.TaskSummaryByServiceLevelRequest= userrequest_list;

            var mockLogger = new Mock<ILogger<TaskServicelevelSummaryController>>();
            ILogger<TaskServicelevelSummaryController> logger = mockLogger.Object;

            var mocktask = new Mock<ITaskServicelevelSummaryBO>();
            TaskServicelevelSummaryController taskControllerobj = new TaskServicelevelSummaryController(logger,mocktask.Object);
            mocktask.Setup(x => x.gettaskServicelevelSummary(usertaskpriority)).Returns(GetTasksInValiddata);
            Task<IActionResult> result = taskControllerobj.GetTaskwiseServiceLevelSummary(usertaskpriority);
            ObjectResult obj = (ObjectResult)result.Result;
            Assert.IsTrue(result.IsCompletedSuccessfully);
            Assert.AreEqual(obj.StatusCode, 400);
        }

    }
}
