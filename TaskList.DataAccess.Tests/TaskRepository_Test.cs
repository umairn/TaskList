using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TaskList.DataAccess.Tests
{
    [TestClass]
    public class TaskRepository_Test
    {
        [TestMethod]
        public void Should_Return_All_Tasks_When_Call_GetAllTasks()
        {
            // Arrange  
            var templateRepository = new Mock<ITaskRepository>();

            var taskComplition = new TaskCompletionSource<List<TasksDB>>();
            taskComplition.SetResult(new List<TasksDB>()
            {
                new TasksDB()
                {

                      TaskId = new Guid("75A55861-4442-4FD1-A150-725CE51186E4"),
                      TaskName = "Task 1",
                      IsComplete=true

                }

            });

            templateRepository.Setup(x => x.GetAllTasks()).Returns(taskComplition.Task);

            var expected_Count = 1;
            var expected_TaskID = new Guid("75A55861-4442-4FD1-A150-725CE51186E4");


            //   // Act
            var actual = templateRepository.Object.GetAllTasks().Result;

            // Assert
            Assert.AreEqual(expected_Count, actual.Count);
            Assert.AreEqual(expected_TaskID, actual[0].TaskId);
        }
        [TestMethod]
        public void Should_Return_All_Document_When_Call_TaskById()
        {
            // Arrange  
            var templateRepository = new Mock<ITaskRepository>();

            var taskComplition = new TaskCompletionSource<List<TasksDB>>();
            taskComplition.SetResult(new List<TasksDB>()
            {
                new TasksDB()
                {

                      TaskId = new Guid("75A55861-4442-4FD1-A150-725CE51186E4"),
                      TaskName = "Task 1",
                      IsComplete=true

                }

            });

            templateRepository.Setup(x => x.GetTaskById(It.IsAny<Guid>())).Returns(taskComplition.Task);

            var expected_Count = 1;
            var expected_TaskID = new Guid("75A55861-4442-4FD1-A150-725CE51186E4");



            //   // Act
            var actual = templateRepository.Object.GetTaskById(It.IsAny<Guid>()).Result;

            // Assert
            Assert.AreEqual(expected_Count, actual.Count);
            Assert.AreEqual(expected_TaskID, actual[0].TaskId);


        }
    }
}
