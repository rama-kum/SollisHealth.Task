using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SollisHealth.Common.Helpers;
using SollisHealth.Common.Helpers.Security;
using SollisHealth.Task.Helper;
using SollisHealth.Task.Interface;
using SollisHealth.Task.Repository;
using SollisHealth.Task.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SollisHealth.Task
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

            //Encrypted string from appsettings.json file is taken and decrypted for connecting to database
            services = new StartupCommon(Configuration).ConfigureServices(services);
            AesCryptoUtil _AesCryptoUtil = new AesCryptoUtil();
            var connectionstring = Configuration.GetConnectionString("TaskConnection");
           //   var deconnectionstring1 = _AesCryptoUtil.Encrypt(connectionstring);
           // var deconnectionstring = _AesCryptoUtil.Decrypt(deconnectionstring1);
            var deconnectionstring = _AesCryptoUtil.Decrypt(connectionstring);
            deconnectionstring = deconnectionstring.Replace("\v", "");
            services.AddDbContextPool<TaskDbContext>(options => options.UseMySQL(deconnectionstring));
           //  services.AddDbContextPool<TaskDbContext>(options => options.UseMySQL(connectionstring));
            services.AddScoped<ITaskBO, TaskBO>();
            services.AddScoped<ITaskRepo, TaskRepo>();

            services.AddScoped<ITaskByUserBO, TaskByUserBO>();
            services.AddScoped<ITaskByUserRepo, TaskByUserRepo>();

            services.AddScoped<IUserBO, UserCaseBO>();
            services.AddScoped<IUserRepo, UserCasesRepo>();

            services.AddScoped<IOpenTaskSummaryBO, OpenTaskSummaryBO>();
            services.AddScoped<IOpenTaskSummaryRepo, OpenTaskSummaryRepo>();

            services.AddScoped<ITaskActivitySummaryBO, TaskActivitySummaryBO>();
            services.AddScoped<ITaskActivitySummaryRepo, TaskActivitySummaryRepo>();

            services.AddScoped<ITaskServicelevelSummaryBO, TaskServicelevelSummaryBO>();
            services.AddScoped<ITaskServicelevelSummaryRepo, TaskServicelevelSummaryRepo>();
            // services.AddScoped<MysqlHelper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            //HTTP request pipeline configuration is done from SollisHealth.common.Helper common package 
            app = new StartupCommon(Configuration).Configure(app, env, provider);

        }
    }
}
