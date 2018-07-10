using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TaskList.DataAccess
{
   public interface ITaskRepository : IGenericRepository<TasksDB>
    {
        Task<List<TasksDB>> GetAllTasks();
        Task<List<TasksDB>> GetTaskById(Guid id);
        Task<List<TasksDB>> GetTaskByName(string name);
    }
}
