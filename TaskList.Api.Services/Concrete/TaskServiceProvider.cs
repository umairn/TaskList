using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskList.Api.Common;
using TaskList.DataAccess;

namespace TaskList.Api.Services
{
    public class TaskServiceProvider : ITaskServiceProvider
    {

        /// <summary>
        /// 
        /// </summary>
        ITaskItemService TaskItemService { get; set; }
        /// <summary>
        /// 
        /// </summary>
        ITasksService TasksService { get; set; }
        /// <summary>
        /// 
        /// </summary>
        IAddTaskService AddTaskService { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskItemService"></param>
        /// <param name="tasksService"></param>
        /// <param name="addTaskService"></param>


        public TaskServiceProvider(ITaskItemService taskItemService, 
                                    ITasksService tasksService,
                                    IAddTaskService addTaskService)
        {

            this.TaskItemService = taskItemService;
            this.TasksService = tasksService;
            this.AddTaskService = addTaskService;
        }

        public async Task<IActionResult> GetTaskItem(Guid id,string name, ITaskRepository taskRepository, ILogger logger)
        {
            return await this.TaskItemService.GetTaskItem(id, name, taskRepository, logger);
        }

        public async Task<IActionResult> GetTasks(ITaskRepository taskRepository, ILogger logger)
        {
            return await this.TasksService.GetTasks(taskRepository, logger);
        }

        public async Task<IActionResult> AddTask(TaskItem task, ITaskRepository taskRepository, ILogger logger)
        {
            return await this.AddTaskService.SaveTask(task, taskRepository, logger);
        }
    }
}
