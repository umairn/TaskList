using System;
using System.Collections.Generic;
using System.Text;
using TaskList.Api.Common;
using TaskList.DataAccess;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TaskList.Api.DataAccess
{
    public class TasksMapHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name = "task" ></ param >
        /// < returns ></ returns >
        public Task<IActionResult> GetTasksResponse(TasksDB task)
        {
            //Adding this code to handle Empty Document
            if (task == null)
                return Task.FromResult<IActionResult>(new NotFoundResult());

            return Task.FromResult<IActionResult>(new ObjectResult(new TaskResponse()
            {
                TaskId = task.TaskId,
                TaskName = task.TaskName,
                IsComplete = task.IsComplete,
                Create_At = task.Created_at,
                Owner = task.Owner
            }));

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tasklist"></param>
        /// <returns></returns>
        public Task<IActionResult> GetTasksResponseList(List<TasksDB> tasklist)
        {
            var responselist = new List<TaskResponse>();

            foreach (var task in tasklist)
            {

                var response = new TaskResponse()
                {
                    TaskId = task.TaskId,
                    TaskName = task.TaskName,
                    IsComplete = task.IsComplete,
                    Create_At = task.Created_at,
                    Owner = task.Owner
                };

                responselist.Add(response);
            }

            return Task.FromResult<IActionResult>(new ObjectResult(responselist));
        }

        public TasksDB SetNewTaskObj(TaskItem taskObj)
        {
            TasksDB task = new TasksDB();
            task.TaskName = taskObj.TaskName;
            task.Owner = taskObj.Owner;
            task.IsComplete = taskObj.IsComplete;
            task.Created_at = DateTime.Now;
            task.Created_by = taskObj.Owner;
            task.Updated_at = DateTime.Now;
            task.Updated_by = taskObj.Owner;
            task.TaskId = Guid.NewGuid();
            return task;
        }
        public TasksDB SetExisingtDocumentObj(TasksDB taskDBOriginal, TaskItem taskObjNew)
        {
            TasksDB task = new TasksDB();
            task.TaskName = taskObjNew.TaskName;
            task.Owner = taskObjNew.Owner;
            task.IsComplete = taskObjNew.IsComplete;
            task.Created_at = taskDBOriginal.Created_at;
            task.Created_by = taskDBOriginal.Created_by;
            task.Updated_at = DateTime.Now;
            task.Updated_by = taskObjNew.Owner;
            task.TaskId = taskDBOriginal.TaskId;
            return task;
        }
    }
}
