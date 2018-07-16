using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using TaskList.Api.Common;

namespace TaskList.Web.Services
{
    public interface ITaskListServiceClient
    {
        TaskResponse GetTask(Guid id, [Optional]string name);
        List<TaskResponse> GetTasks();
        Task<TaskResponse> AddTask(TaskItem task);
    }
}
