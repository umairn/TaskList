using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskList.Web.Model
{
    public class TaskResponseViewModel
    {
        /// </summary>

        public string TaskId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TaskName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TaskDescription { get; set; }
        /// <summary>
        /// E.g. created by
        /// </summary>
        public string Owner { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string IsComplete { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Create_At { get; set; }
    }
}
