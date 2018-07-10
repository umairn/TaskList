using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaskList.Api.DataAccess;
using TaskList.DataAccess;

namespace TaskList.Api.Services
{
    public class TaskItemService : ITaskItemService
    {
        public async Task<IActionResult> GetTaskItem(Guid id, string name, ITaskRepository taskRepository, ILogger logger)
        {
            try
            {

                if (name != null)
                {
                    var result = taskRepository.GetTaskByName(name);
                    return await new TasksMapHelper().GetTasksResponse(result.Result[0]);

                }
                else
                {

                   var result = taskRepository.GetTaskById(id); ;
                   return await new TasksMapHelper().GetTasksResponse(result.Result[0]);

                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);

            }

            return null;
        }
    }
}
