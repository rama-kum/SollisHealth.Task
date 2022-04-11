using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SollisHealth.Task.Controllers.v1;
using SollisHealth.Task.Helper;
using SollisHealth.Task.Interface;
using SollisHealth.Task.Model;
using SollisHealth.Task.Model.UserCases;
using SollisHealth.Task.Repository;
using SollisHealth.Task.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SollisHealth.Task.UnitTest
{
    [TestClass]
    public class UserSummariesUnitTest
    {
       // [TestMethod]
        /*      public void UserSummaries_Repository_SUCCESS()
              {
                  var options = new DbContextOptionsBuilder<TaskDbContext>()
                              .UseInMemoryDatabase(databaseName: "TaskDataBase")
                              .Options;

                  using (var context = new TaskDbContext(options))
                  {
                     context.vm_task_sla.Add(new UserOpenCases
                     {
                         UserName = "Max",
                         Title="aa",
                         OpenCases = 2
                     });

                  context.SaveChanges();

                      UserCasesRepo repoObject = new UserCasesRepo(context);
                      Task<UserCasesResponse> result = repoObject.getusercases();

                      Assert.AreEqual(result.Result.success, true);
                      Assert.IsTrue(result.IsCompletedSuccessfully);

                  }

              }

              [TestMethod]
              public void UserSummaries_Repository_FAILURE()
              {
                  var options = new DbContextOptionsBuilder<TaskDbContext>()
                              .UseInMemoryDatabase(databaseName: "TaskDataBase")
                              .Options;

                  using (var context = new TaskDbContext(options))
                  {
                      UserCasesRepo repoObject = new UserCasesRepo(context);
                      Task<UserCasesResponse> result = repoObject.getusercases();

                      Assert.AreEqual(result.Result.data.summaries.Count,0);                
                      Assert.IsTrue(result.IsCompletedSuccessfully);
                  }
              }


              [TestMethod]
              public void UserSummariesSUCCESS_BO()
              {
                  var mockRepo = new Mock<IUserRepo>();
                  mockRepo.Setup(x => x.getusercases()).Returns(GetusercasesValiddata);

                  UserCaseBO userBO = new UserCaseBO(mockRepo.Object);
                  Task<UserCasesResponse> result = userBO.getusercases();

                  Assert.IsTrue(result.IsCompletedSuccessfully);
                  Assert.AreEqual(result.Result.success, true);
              }

              private Task<UserCasesResponse> GetusercasesValiddata()
              {
                  UserCasesResponse obj_userresponse = new UserCasesResponse();
                  UserSummaries obj_userDetails = new UserSummaries();
                  List<UserSummary> obj_userDetail = new List<UserSummary>();

                  UserOpenCasesUI output = new UserOpenCasesUI();
                  output.Title = "title ";
                   output.Username = "aa";
                  output.OpenCases = 2;

                  obj_userDetail.Add(new UserSummary { summary = output });
                  obj_userDetails.summaries = obj_userDetail;
                  obj_userresponse.data = obj_userDetails;
                  obj_userresponse.success = true;

                  return System.Threading.Tasks.Task.FromResult(obj_userresponse);
              }

              [TestMethod]
              public void UserSummariesFAILURE_BO()
              {
                  var mockRepo = new Mock<IUserRepo>();
                  mockRepo.Setup(x => x.getusercases()).Returns(GetusercasesInValiddata);

                  UserCaseBO userBO = new UserCaseBO(mockRepo.Object);
                  Task<UserCasesResponse> result = userBO.getusercases();

                  Assert.IsTrue(result.IsCompletedSuccessfully);
                  Assert.AreEqual(result.Result.success, false);
              }

              private Task<UserCasesResponse> GetusercasesInValiddata()
              {
                  UserCasesResponse obj_userresponse = new UserCasesResponse();
                  UserSummaries obj_userDetails = new UserSummaries();
                  List<UserSummary> obj_userDetail = new List<UserSummary>();

                  UserOpenCasesUI output = new UserOpenCasesUI();
                  obj_userDetail.Add(new UserSummary { summary = output });
                  obj_userDetails.summaries = obj_userDetail;
                  obj_userresponse.data = obj_userDetails;
                  obj_userresponse.success = false;

                  return System.Threading.Tasks.Task.FromResult(obj_userresponse);
              }



              [TestMethod]
              public void UserSummariesSUCCESS_Controller()
              {
                  var mockLogger = new Mock<ILogger<TaskController>>();
                  ILogger<TaskController> logger = mockLogger.Object;

                  var mocktask = new Mock<ITaskBO>();
                  var mockUser = new Mock<IUserBO>();

                  TaskController taskControllerobj = new TaskController(logger, mocktask.Object, mockUser.Object);
                  mockUser.Setup(x => x.getusercases()).Returns(GetusercasesValiddata);
                  Task<IActionResult> result = taskControllerobj.GetUserSummary();
                  ObjectResult obj = (ObjectResult)result.Result;
                  Assert.IsTrue(result.IsCompletedSuccessfully);
                  Assert.AreEqual(obj.StatusCode, 200);
              }

              /// <summary>
              /// Check User Navigator Controller class if exists member ID
              /// </summary>
              [TestMethod]
              public void UserSummariesFAILURE_Controller()
              {
                  var mockLogger = new Mock<ILogger<TaskController>>();
                  ILogger<TaskController> logger = mockLogger.Object;

                  var mocktask = new Mock<ITaskBO>();
                  var mockUser = new Mock<IUserBO>();

                  TaskController taskControllerobj = new TaskController(logger, mocktask.Object, mockUser.Object);
                  mockUser.Setup(x => x.getusercases()).Returns(GetusercasesInValiddata);
                  Task<IActionResult> result = taskControllerobj.GetUserSummary();
                  ObjectResult obj = (ObjectResult)result.Result;
                  Assert.IsTrue(result.IsCompletedSuccessfully);
                  Assert.AreEqual(obj.StatusCode, 400);
              }*/

    }
}
