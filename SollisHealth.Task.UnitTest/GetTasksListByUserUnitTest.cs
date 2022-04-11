using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SollisHealth.Task.Controllers.v1;
using SollisHealth.Task.Helper;
using SollisHealth.Task.Interface;
using SollisHealth.Task.Model;
using SollisHealth.Task.Model.GetTasksByUser;
using SollisHealth.Task.Repository;
using SollisHealth.Task.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SollisHealth.Task.UnitTest
{
    [TestClass]
    public class GetTasksListByUserUnitTest
    {
        [TestMethod]
        public void GetTasksListByUserUnitTest_Repository_SUCCESS()
        {
            var options = new DbContextOptionsBuilder<TaskDbContext>()
                        .UseInMemoryDatabase(databaseName: "TaskListDataBase")
                        .Options;

            using (var context = new TaskDbContext(options))
            {
               context.vm_task_details.Add(new TaskByUserOutput
               {
                   Task_ID= 2,
                   Task_Open_Date= System.DateTime.Now,
                   Request_Type_Name="aa",
                   Request_Type_ID=1,
                   Member_ID ="",
                   SLA_Priority_Name = "aa",
                   SLA_Close_Unit="",
                   SLA_Risk_VAL = 1,
                   SLA_Exceed_VAL=1,
                   SLA_Priority_ID=1,
                   Task_Role_ID=1,
                   role_id=1,
                   Member_Info="",
                   Member_Details="",
                   Assigned_User_id=1,
                   Assigned_User_name="",
                   Task_Status_ID =2, 
                   Resolution = "ww",
                   Task_Close_Date= System.DateTime.Now

    });

            context.SaveChanges();

                TaskByUserRepo repoObject = new TaskByUserRepo(context);
                TaskByUserRequest userrequest = new TaskByUserRequest();
                userrequest.RoleId = 1;
                userrequest.AssignedUserId = 1;
                Task<TaskByUserResponse> result = repoObject.gettaskbyuser(userrequest);

                Assert.AreEqual(result.Result.success, true);
                Assert.IsTrue(result.IsCompletedSuccessfully);

            }

        }

        [TestMethod]
        public void GetTasksListByUserUnitTest_Repository_FAILURE()
        {
            var options = new DbContextOptionsBuilder<TaskDbContext>()
                        .UseInMemoryDatabase(databaseName: "TaskListDataBase")
                        .Options;

            using (var context = new TaskDbContext(options))
            {
                TaskByUserRepo repoObject = new TaskByUserRepo(context);
                TaskByUserRequest userrequest = new TaskByUserRequest();
                userrequest.RoleId = 11;
                userrequest.AssignedUserId = 11;

                Task<TaskByUserResponse> result = repoObject.gettaskbyuser(userrequest);

                Assert.AreEqual(result.Result.success,false);                
                Assert.IsTrue(result.IsCompletedSuccessfully);
            }
        }


        [TestMethod]
        public void GetTasksListByUserUnitTest_SUCCESS_BO()
        {
            TaskByUserRequest userrequest = new TaskByUserRequest();
            userrequest.RoleId = 1;
            userrequest.AssignedUserId = 1;

            var mockRepo = new Mock<ITaskByUserRepo>();
            mockRepo.Setup(x => x.gettaskbyuser(userrequest)).Returns(GetTasksValiddata);

            TaskByUserBO userBO = new TaskByUserBO(mockRepo.Object);
            Task<TaskByUserResponse> result = userBO.gettaskbyuser(userrequest);

            Assert.IsTrue(result.IsCompletedSuccessfully);
            Assert.AreEqual(result.Result.success, true);
        }

        private Task<TaskByUserResponse> GetTasksValiddata()
        {
            TaskByUserResponse obj_userresponse = new TaskByUserResponse();
            TasksByUser obj_taskDetails = new TasksByUser();
            List<TaskByUser> obj_taskDetail = new List<TaskByUser>();

            TaskByUserDetailsforUI output = new TaskByUserDetailsforUI();
            output.TaskID = 2;
            output.TaskOpenDate = System.DateTime.Now;
            output.RequestTypeName = "aa";
            output.RequestTypeID = 1;
            output.MemberID = "";
            output.SLAPriorityName = "aa";
            output.SLACloseUnit = "";
            output.SLARiskVAL = 1;
            output.SLAExceedVAL = 1;
            output.SLAPriorityID = 1;
            output.TaskRoleID = 1;
            output.RoleId = 1;
            output.MemberInfo = "";
            output.MemberDetails = "";
            output.AssignedUserId = 1;
            output.AssignedUserName = "";
            output.TaskStatusID = 2;
            output.Resolution = "ww";
            output.TaskCloseDate = System.DateTime.Now;

            obj_taskDetail.Add(new TaskByUser { UserTask = output });
            obj_taskDetails.UserTasks = obj_taskDetail;
            obj_userresponse.data = obj_taskDetails;
            obj_userresponse.success = true;

            return System.Threading.Tasks.Task.FromResult(obj_userresponse);
        }

        [TestMethod]
        public void GetTasksListByUserUnitTest_FAILURE_BO()
        {
            TaskByUserRequest userrequest = new TaskByUserRequest();
            userrequest.RoleId = 11;
            userrequest.AssignedUserId = 11;

            var mockRepo = new Mock<ITaskByUserRepo>();
            mockRepo.Setup(x => x.gettaskbyuser(userrequest)).Returns(GetTasksInValiddata);

            TaskByUserBO userBO = new TaskByUserBO(mockRepo.Object);
            Task<TaskByUserResponse> result = userBO.gettaskbyuser(userrequest);

            Assert.IsTrue(result.IsCompletedSuccessfully);
            Assert.AreEqual(result.Result.success, false);
        }

        private Task<TaskByUserResponse> GetTasksInValiddata()
        {
            TaskByUserResponse obj_userresponse = new TaskByUserResponse();
            TasksByUser obj_taskDetails = new TasksByUser();
            List<TaskByUser> obj_taskDetail = new List<TaskByUser>();

            TaskByUserDetailsforUI output = new TaskByUserDetailsforUI();
            obj_taskDetail.Add(new TaskByUser { UserTask = output });
            obj_taskDetails.UserTasks = obj_taskDetail;
            obj_userresponse.data = obj_taskDetails;
            obj_userresponse.success = false;

            return System.Threading.Tasks.Task.FromResult(obj_userresponse);
        }

 

        [TestMethod]
        public void GetTasksListByUserUnitTest_SUCCESS_Controller()
        {
            TaskByUserRequest userrequest = new TaskByUserRequest();
            userrequest.RoleId = 1;
            userrequest.AssignedUserId = 1;

            var mockLogger = new Mock<ILogger<TasksByUserController>>();
            ILogger<TasksByUserController> logger = mockLogger.Object;

            var mocktask = new Mock<ITaskByUserBO>();
            TasksByUserController taskControllerobj = new TasksByUserController(logger, mocktask.Object);
            mocktask.Setup(x => x.gettaskbyuser(userrequest)).Returns(GetTasksValiddata);
            Task<IActionResult> result = taskControllerobj.GetTaskListByUser(userrequest);
            ObjectResult obj = (ObjectResult)result.Result;
            Assert.IsTrue(result.IsCompletedSuccessfully);
            Assert.AreEqual(obj.StatusCode, 200);
        }

        /// <summary>
        /// Check User TaskByUser Controller class if exists member ID
        /// </summary>
        [TestMethod]
        public void GetTasksListByUserUnitTest_FAILURE_Controller()
        {
            TaskByUserRequest userrequest = new TaskByUserRequest();
            //userrequest.RoleId = 11;
           // userrequest.AssignedUserId = 1;

            var mockLogger = new Mock<ILogger<TasksByUserController>>();
            ILogger<TasksByUserController> logger = mockLogger.Object;

            var mocktask = new Mock<ITaskByUserBO>();
            TasksByUserController taskControllerobj = new TasksByUserController(logger,mocktask.Object);
            mocktask.Setup(x => x.gettaskbyuser(userrequest)).Returns(GetTasksInValiddata);
            Task<IActionResult> result = taskControllerobj.GetTaskListByUser(userrequest);
            ObjectResult obj = (ObjectResult)result.Result;
            Assert.IsTrue(result.IsCompletedSuccessfully);
            Assert.AreEqual(obj.StatusCode, 400);
        }

    }
}
