using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaskList.DataAccess;

namespace TaskList.Api.Services
{
   public  interface ITaskItemService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="version"></param>
        /// <param name="documentRepository"></param>
        /// <param name="logger"></param>
        /// <returns></returns>
       Task<IActionResult> GetTaskItem(Guid id, string name, ITaskRepository taskRepository, ILogger logger);
    }
}
