using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace TaskList.DataAccess
{
    public class TaskRepository : GenericRepository<TasksDB>, ITaskRepository
    {/// <summary>
     /// 
     /// </summary>
     /// <param name="unitOfWork"></param>
         public TaskRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
           {
            _unitOfWork = unitOfWork;

        }
        private IUnitOfWork _unitOfWork;

        /// <summary>
        /// 
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public async Task<List<TasksDB>> GetAllTasks()
        {
            var context = _unitOfWork.Get<TasksContext>();
            var taskContext = context.Tasks;
            var taskLists = taskContext.Where<TasksDB>(x => x.TaskName != null);

            return await Task.FromResult<List<TasksDB>>(taskLists.ToList());
        }
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        public async Task<List<TasksDB>> GetTaskById(Guid id)
        {
            var context = _unitOfWork.Get<TasksContext>();
            var taskContext = context.Tasks;

            var taskLists = taskContext.Where<TasksDB>(x => x.TaskId == id);

            return await Task.FromResult<List<TasksDB>>(taskLists.ToList());
        }

        public async Task<List<TasksDB>> GetTaskByName(string name)
        {
            var context = _unitOfWork.Get<TasksContext>();
            var taskContext = context.Tasks;

            var taskLists = taskContext.Where<TasksDB>(x => x.TaskName == name);

            return await Task.FromResult<List<TasksDB>>(taskLists.ToList());
        }
    }
}
