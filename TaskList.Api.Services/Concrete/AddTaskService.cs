using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskList.Api.Common;
using TaskList.Api.DataAccess;
using TaskList.DataAccess;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace TaskList.Api.Services
{
    public class AddTaskService : IAddTaskService
    {
        public async Task<IActionResult> SaveTask(TaskItem task, ITaskRepository taskRepository, ILogger logger)
        {
            try
            {
                var Mapper = new TasksMapHelper();

                var tsk = Mapper.SetNewTaskObj(task);
                await taskRepository.Add(tsk);
                taskRepository.Save();
                var taskNew = taskRepository.GetTaskByName(task.TaskName);
                return await Mapper.GetTasksResponse(taskNew.Result[0]);
            }

            catch (Exception ex)
            {
                logger.LogError(ex.Message);

            }

            return null;
        }
    }
}
