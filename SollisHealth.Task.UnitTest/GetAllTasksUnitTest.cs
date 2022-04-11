using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SollisHealth.Task.Controllers.v1;
using SollisHealth.Task.Helper;
using SollisHealth.Task.Interface;
using SollisHealth.Task.Model;
using SollisHealth.Task.Model.GetAllTasks;
using SollisHealth.Task.Repository;
using SollisHealth.Task.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SollisHealth.Task.UnitTest
{
    [TestClass]
    public class GetAllTasksUnitTest
    {
 /*       [TestMethod]
        public void GetAllTasks_Repository_SUCCESS()
        {
            var options = new DbContextOptionsBuilder<TaskDbContext>()
                        .UseInMemoryDatabase(databaseName: "TaskDataBase")
                        .Options;

            using (var context = new TaskDbContext(options))
            {
               context.vm_task_details.Add(new TaskOutput
                {
                   UserName = "Max",
                   Task_ID= 2,
                   Task_Open_Date= System.DateTime.Now,
                   Request_Type_Name="aa",
                   Member_ID="",
                   Task_Priority_Name="aa",
                   SLA_Close_Unit="",
                   SLA_CLOSE_VAL=1,
                   Task_Status_ID=2,
                   Assigned_User="",
                   Task_Description="desc",
                   Task_Status_Name="ww",
                   Task_Close_Date= System.DateTime.Now

               });

            context.SaveChanges();

                TaskRepo repoObject = new TaskRepo(context);
                Task<TaskResponse> result = repoObject.gettaskresponse();

                Assert.AreEqual(result.Result.success, true);
                Assert.IsTrue(result.IsCompletedSuccessfully);

            }

        }

        [TestMethod]
        public void GetAllTasks_Repository_FAILURE()
        {
            var options = new DbContextOptionsBuilder<TaskDbContext>()
                        .UseInMemoryDatabase(databaseName: "TaskDataBase")
                        .Options;

            using (var context = new TaskDbContext(options))
            {        
                TaskRepo repoObject = new TaskRepo(context);
                Task<TaskResponse> result = repoObject.gettaskresponse();

                Assert.AreEqual(result.Result.data.Tasks.Count,0);                
                Assert.IsTrue(result.IsCompletedSuccessfully);
            }
        }


        [TestMethod]
        public void GetAllTasksSUCCESS_BO()
        {
            var mockRepo = new Mock<ITaskRepo>();
            mockRepo.Setup(x => x.gettaskresponse()).Returns(GetTasksValiddata);

            TaskBO userBO = new TaskBO(mockRepo.Object);
            Task<TaskResponse> result = userBO.gettaskresponse();

            Assert.IsTrue(result.IsCompletedSuccessfully);
            Assert.AreEqual(result.Result.success, true);
        }

        private Task<TaskResponse> GetTasksValiddata()
        {
            TaskResponse obj_userresponse = new TaskResponse();
            TasksDetails obj_taskDetails = new TasksDetails();
            List<TaskDetail> obj_taskDetail = new List<TaskDetail>();

            TaskDetailsforUI output = new TaskDetailsforUI();
            output.UserName = "Max";
            output.TaskID = 2;
            output.TaskOpenDate = System.DateTime.Now;
            output.RequestTypeName = "aa";
            output.MemberID = "";
            output.TaskPriorityName = "aa";
            output.SLACloseUnit = "";
            output.SLACloseVal = 1;
            output.TaskStatusID = 2;
            output.AssignedUser = "";
            output.TaskDescription = "desc";
            output.TaskStatusName = "ww";
            output.TaskCloseDate = System.DateTime.Now;

            obj_taskDetail.Add(new TaskDetail { Task = output });
            obj_taskDetails.Tasks = obj_taskDetail;
            obj_userresponse.data = obj_taskDetails;
            obj_userresponse.success = true;

            return System.Threading.Tasks.Task.FromResult(obj_userresponse);
        }

        [TestMethod]
        public void GetAllTasksFAILURE_BO()
        {
            var mockRepo = new Mock<ITaskRepo>();
            mockRepo.Setup(x => x.gettaskresponse()).Returns(GetTasksInValiddata);

            TaskBO userBO = new TaskBO(mockRepo.Object);
            Task<TaskResponse> result = userBO.gettaskresponse();

            Assert.IsTrue(result.IsCompletedSuccessfully);
            Assert.AreEqual(result.Result.success, false);
        }

        private Task<TaskResponse> GetTasksInValiddata()
        {
            TaskResponse obj_userresponse = new TaskResponse();
            TasksDetails obj_taskDetails = new TasksDetails();
            List<TaskDetail> obj_taskDetail = new List<TaskDetail>();

            TaskDetailsforUI output = new TaskDetailsforUI();
            obj_taskDetail.Add(new TaskDetail { Task = output });
            obj_taskDetails.Tasks = obj_taskDetail;
            obj_userresponse.data = obj_taskDetails;
            obj_userresponse.success = false;

            return System.Threading.Tasks.Task.FromResult(obj_userresponse);
        }

 

        [TestMethod]
        public void GetAllTasksSUCCESS_Controller()
        {
            var mockLogger = new Mock<ILogger<TaskController>>();
            ILogger<TaskController> logger = mockLogger.Object;

            var mocktask = new Mock<ITaskBO>();
            var mockUser = new Mock<IUserBO>();

            TaskController taskControllerobj = new TaskController(logger, mocktask.Object, mockUser.Object);
            mocktask.Setup(x => x.gettaskresponse()).Returns(GetTasksValiddata);
            Task<IActionResult> result = taskControllerobj.GetTasksInfo();
            ObjectResult obj = (ObjectResult)result.Result;
            Assert.IsTrue(result.IsCompletedSuccessfully);
            Assert.AreEqual(obj.StatusCode, 200);
        }

        /// <summary>
        /// Check User Navigator Controller class if exists member ID
        /// </summary>
        [TestMethod]
        public void GetAllTasksFAILURE_Controller()
        {
            var mockLogger = new Mock<ILogger<TaskController>>();
            ILogger<TaskController> logger = mockLogger.Object;

            var mocktask = new Mock<ITaskBO>();
            var mockUser = new Mock<IUserBO>();

            TaskController taskControllerobj = new TaskController(logger, mocktask.Object, mockUser.Object);
            mocktask.Setup(x => x.gettaskresponse()).Returns(GetTasksInValiddata);
            Task<IActionResult> result = taskControllerobj.GetTasksInfo();
            ObjectResult obj = (ObjectResult)result.Result;
            Assert.IsTrue(result.IsCompletedSuccessfully);
            Assert.AreEqual(obj.StatusCode, 400);
        }
 */
    }
}
