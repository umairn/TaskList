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
    public  class AddTaskService_Test
    {
        [TestMethod]
        public void Should_Return_Response_Object_With_New_Task_If_Call_AddTask()
        {
            // Arrange
            var taskItem = new TaskItem()
            {

                TaskName = "Task 1",
                IsComplete=true,
                Owner="Current"
            };

            var taskComplitionDemo = new TaskCompletionSource<List<TasksDB>>();
            taskComplitionDemo.SetResult(new List<TasksDB>()
            {
                new TasksDB()
                {

                      TaskId = new Guid("75A55861-4442-4FD1-A150-725CE51186E4"),
                      TaskName = "Task 1",
                      IsComplete=true
                }

            });

            var taskComplition = new TaskCompletionSource<IActionResult>();

            taskComplition.SetResult(new ObjectResult(new Dictionary<string, string>())
            {
                StatusCode = 200,
                Value = "Pass"


            });
            var moqTaskRepositor = new Mock<ITaskRepository>();
            moqTaskRepositor.Setup(x => x.GetTaskByName(It.IsAny<string>())).Returns(taskComplitionDemo.Task);
            var moqLogger = new Mock<ILogger>();

            var expectedName = "Task 1";

            // Assert
            var addTaskService = new AddTaskService();

            var AddTask = (ObjectResult)addTaskService.SaveTask(taskItem, moqTaskRepositor.Object, moqLogger.Object).Result;

            var response = (TaskResponse)AddTask.Value;

            Assert.AreEqual(expectedName, response.TaskName);

        }
    }
}
