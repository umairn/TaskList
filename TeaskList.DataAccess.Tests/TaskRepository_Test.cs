using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeaskList.DataAccess;

namespace TeaskList.DataAccess.Tests
{
    [TestClass]
    public class TaskRepository_Test
    {
        [TestMethod]
        public void Should_Return_All_Tasks_When_Call_GetAllTasks()
        {
            // Arrange  
            var templateRepository = new Mock<ITasksRepository>();
        }
    }
}
