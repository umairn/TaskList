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
    public interface IAddTaskService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="task"></param>
        /// <param name="taskRepository"></param>
        /// <param name="_logger"></param>
        /// <returns></returns>
        Task<IActionResult> SaveTask(TaskItem task, ITaskRepository taskRepository, ILogger logger);
    }
}
