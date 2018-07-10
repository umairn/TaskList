using System;
using System.Collections.Generic;
using System.Text;

namespace TaskList.Api.Common
{
    public class TaskResponse
    {
        /// <summary>
        /// /
        /// </summary>

        public Guid TaskId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TaskName { get; set; }
           /// <summary>
        /// E.g. created by
        /// </summary>
        public string Owner { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsComplete { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Create_At { get; set; }
    }
}
