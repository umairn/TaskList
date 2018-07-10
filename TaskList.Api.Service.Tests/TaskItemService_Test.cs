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

namespace TaskList.Api.Service.Tests
{
    [TestClass]
    public class TaskItemService_Test
    {
        [TestMethod]
        public void Should_Return_TaskResponse_If_call_TaskByItem_and_No_TaskName_First_Document()
        {
            var moqDocumentRepositor = new Mock<ITaskRepository>();
            var taskId = new Guid("75A55861-4442-4FD1-A150-725CE51186E4");
            var Listdata = new List<TasksDB>();
            var taskComplition = new TaskCompletionSource<List<TasksDB>>();
            taskComplition.SetResult(new List<TasksDB>()
            {
                new TasksDB()
                {

                      TaskId = new Guid("75A55861-4442-4FD1-A150-725CE51186E4"),
                      TaskName = "Task 1"
                }

            });


            moqDocumentRepositor.Setup(x => x.GetTaskById(taskId)).Returns(taskComplition.Task);
            var moqLogger = new Mock<ILogger>();

            string name = null;
            var expected = new Guid("75A55861-4442-4FD1-A150-725CE51186E4");
            var TaskItemService = new TaskItemService();
            // Act
            var actual = (ObjectResult)TaskItemService.GetTaskItem(taskId, name, moqDocumentRepositor.Object, moqLogger.Object).Result;

            var response = (TaskResponse)actual.Value;
            // Assert
            Assert.AreEqual(expected, response.TaskId);
        }
    }
}
