using System;

namespace TaskList.Api.Common
{
    public class TaskItem {
        /// <summary>
        /// 
        /// </summary>
        public string TaskName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TaskDescription { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsComplete { get; set; }
        /// <summary>
        /// E.g. Supplier Code
        /// </summary>
        public string Owner { get; set; }
    }
}
