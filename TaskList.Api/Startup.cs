using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TaskList.Api.Services;
using TaskList.DataAccess;

namespace TaskList.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddTransient<ITaskServiceProvider>((s) =>
                    new TaskServiceProvider(
                    new TaskItemService(),
                    new TasksService(),
                    new AddTaskService()));

            services.AddTransient<ITaskRepository, TaskRepository>();

            services.AddSingleton<IConfiguration>(Configuration);

            services.AddDbContext<TasksContext>(opt =>opt.UseInMemoryDatabase("TaskList"));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<DbContext, TasksContext>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="loggerFactory"></param>
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddLog4Net();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseMvc();
        }
    }
}
