using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskList.DataAccess;

namespace TaskList.Api.Services
{
    public interface ITasksService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskRepository"></param>
        /// <param name="logger"></param>
        /// <returns></returns>
        Task<IActionResult> GetTasks(ITaskRepository taskRepository, ILogger logger);
    }
}
