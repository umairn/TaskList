using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaskList.Api.DataAccess;
using TaskList.DataAccess;

namespace TaskList.Api.Services
{
    public class TasksService : ITasksService
    {
        public async Task<IActionResult> GetTasks(ITaskRepository taskRepository, ILogger logger)
        {
            try
            {

                    var result = taskRepository.GetAllTasks(); 
                    return await new TasksMapHelper().GetTasksResponseList(result.Result);

            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);

            }

            return null;
        }
    }
}
