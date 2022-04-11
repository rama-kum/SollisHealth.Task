using Microsoft.EntityFrameworkCore;
using SollisHealth.Task.Model;
using SollisHealth.Task.Model.GetAllTasks;
using SollisHealth.Task.Model.GetTaskServicelevelSummary;
using SollisHealth.Task.Model.GetTaskActivitySummary;

using SollisHealth.Task.Model.UserCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SollisHealth.Task.Model.GetOpenTaskSummary;
using SollisHealth.Task.Model.GetTasksByUser;

namespace SollisHealth.Task.Helper
{
    /// <summary>
    /// TaskDbContext class is used as a database context to connect to database for to perform database operations
    /// </summary>
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {

        }
        public DbSet<TaskOutput> vm_task_details_old { get; set; }
        public DbSet<UserOpenCases> vm_task_sla_old { get; set; }
        public DbSet<TaskByUserOutput> vm_task_details { get; set; }
        public DbSet<TaskServicelevelSummaryOutput> vm_sla_wise_summary { get; set; }
        public DbSet<TaskActivitySummaryOutput> vm_priority_wise_summary { get; set; }
        public DbSet<OpenTaskSummaryOutput> vm_status_wise_summary { get; set; }

    }

}
