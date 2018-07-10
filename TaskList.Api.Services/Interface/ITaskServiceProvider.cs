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
    public interface ITaskServiceProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="taskRepository"></param>
        /// <param name="logger"></param>
        /// <returns></returns>
        Task<IActionResult> GetTaskItem(Guid id,string name, ITaskRepository taskRepository, ILogger logger);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskRepository"></param>
        /// <param name="logger"></param>
        /// <returns></returns>
        Task<IActionResult> GetTasks(ITaskRepository taskRepository, ILogger logger);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskRepository"></param>
        /// <param name="logger"></param>
        /// <returns></returns>
        Task<IActionResult> AddTask(TaskItem task, ITaskRepository taskRepository, ILogger logger);
    }
}
