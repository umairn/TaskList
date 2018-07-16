using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskList.Api.Common;
using TaskList.Web.Services;
using TaskList.Web.Model;
using Newtonsoft.Json;

namespace TaskList.Web.Controllers
{
    public class TaskTodoController : Controller
    {
        private ITaskListServiceClient _taskListServiceClient;

        public TaskTodoController(ITaskListServiceClient taskListServiceClient)
        {
            _taskListServiceClient = taskListServiceClient;
        }

        [HttpGet, ActionName("Index")]
        public IActionResult Index()
        {

            return View(new List<TaskResponse>());
        }
        [HttpPost]
        public JsonResult GetTasks(DataTableAjaxPostModel model)
        {

            var res = _taskListServiceClient.GetTasks();
            var result = new List<TaskResponseViewModel>(res.Count);

            foreach (var s in res)
            {

                result.Add(new TaskResponseViewModel
                {
                    TaskId = s.TaskId.ToString(),
                    TaskName = s.TaskName,
                    TaskDescription = s.TaskDescription,
                    IsComplete = s.IsComplete.ToString(),
                    Owner = s.Owner,
                    Create_At = s.Create_At.ToString()
                });

            };

            return Json(new
            {
                // this is what datatables wants sending back
                draw = model.draw,
                recordsTotal = result.Count,
                recordsFiltered = result.Count,
                data = result
            });
        }
    }
}