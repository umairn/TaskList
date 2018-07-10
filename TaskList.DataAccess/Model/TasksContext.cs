using Microsoft.EntityFrameworkCore;
using System;


namespace TaskList.DataAccess
{
    public class TasksContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        public DbSet<TasksDB> Tasks { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public TasksContext(DbContextOptions<TasksContext> options)
            : base(options)
        { }
    
    }
}
