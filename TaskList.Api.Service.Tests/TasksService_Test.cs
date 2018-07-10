using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskList.Api.Common;
using TaskList.Api.Services;
using TaskList.DataAccess;
using System.Linq;

namespace TaskList.Api.Service.Tests
{
    [TestClass]
    public class TasksService_Test
    {
        [TestMethod]
        public void Should_Return_TaskResponse_If_call_GetAllTasks()
        {
            var moqDocumentRepositor = new Mock<ITaskRepository>();
            var Listdata = new List<TasksDB>();
            var taskComplition = new TaskCompletionSource<List<TasksDB>>();
            taskComplition.SetResult(new List<TasksDB>()
            {
                new TasksDB()
                {

                      TaskId = new Guid("75A55861-4442-4FD1-A150-725CE51186E4"),
                      TaskName = "Task 1"

                },
                 new TasksDB()
                {

                      TaskId = new Guid("0F8FAD5B-D9CB-469F-A165-70867728950E"),
                      TaskName = "Task 2"

                }

            });
            moqDocumentRepositor.Setup(x => x.GetAllTasks()).Returns(taskComplition.Task);
            var moqLogger = new Mock<ILogger>();

            int? expected_count = 2;
            var TasksService = new TasksService();

            // Act
            var actual = (ObjectResult)TasksService.GetTasks(moqDocumentRepositor.Object, moqLogger.Object).Result;
            var response = (List<TaskResponse>)actual.Value;

            // Assert
            Assert.AreEqual(expected_count, response.Count);
        }


    }
}