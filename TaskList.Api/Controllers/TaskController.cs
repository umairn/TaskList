using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using TaskList.DataAccess;
using TaskList.Api.Services;
using TaskList.Api.Common;
using System.Runtime.InteropServices;

namespace TaskList.Api.Controllers
{
    [Route("api/v1/Task")]
    public class TaskController : Controller
    {

        private ITaskRepository TaskRepository { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private readonly ILogger _logger;
        /// <summary>
        /// 
        /// </summary>
        private readonly IHostingEnvironment Environment;
        /// <summary>
        /// 
        /// </summary>
        private IConfiguration IConfiguration { get; set; }
        /// <summary>
        /// 
        /// </summary>
        private ITaskServiceProvider TaskerviceProvider { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskServiceProvider"></param>
        /// <param name="iconfiguration"></param>
        /// <param name="environment"></param>
        /// <param name="logger"></param>
        /// <param name="taskRepository"></param>
        public TaskController(
             ITaskServiceProvider taskServiceProvider,
             IConfiguration iconfiguration,
             IHostingEnvironment environment,
             ILogger<TaskController> logger,
             ITaskRepository taskRepository


            )
        {
            this.TaskerviceProvider = taskServiceProvider;
            this.IConfiguration = iconfiguration;
            this.Environment = environment;
            this._logger = logger;
            this.TaskRepository = taskRepository;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        [HttpPost("AddTask/")]
        public async Task<IActionResult> AddTask([FromBody] TaskItem task)
        {
            try
            {
                return await TaskerviceProvider.AddTask(task, TaskRepository, _logger);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">The unique identifier of the task</param>
        /// <param name="name">If not provided, will use id</param>
        /// <returns></returns>
        [HttpGet("GetTask/{id}")]
        public async Task<IActionResult> GetTaskItem(Guid id,[Optional]string name)
        {
            try
            {
                return await TaskerviceProvider.GetTaskItem(id, name, TaskRepository, _logger);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

            }

            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetTasks/")]
        public async Task<IActionResult> GetAllTasks()
        {
            try
            {
                return await TaskerviceProvider.GetTasks(TaskRepository, _logger);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

            }

            return null;
        }

    }
}
