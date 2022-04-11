using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SollisHealth.Task.Model.GetAllTasks
{
    public class TaskDetailsforUI
    {
        [DefaultValue("")]
        public string UserName { get; set; } 
        [Key]
        public int TaskID { get; set; }
        
        public DateTime? TaskOpenDate { get; set; }
        [DefaultValue("")]
        public string RequestTypeName { get; set; } 
        [DefaultValue("")]
        public string MemberID { get; set; } 
        [DefaultValue("")]
        public string TaskPriorityName { get; set; } 
        [DefaultValue("")]
        public string SLACloseUnit { get; set; } 
        [DefaultValue(0)]
        public int SLACloseVal { get; set; } 
        [DefaultValue(0)]
        public int TaskStatusID { get; set; } 
        [DefaultValue("")]
        public string AssignedUser { get; set; } 
        [DefaultValue("")]
        public string TaskDescription { get; set; } 
        [DefaultValue("")]
        public string TaskStatusName { get; set; } 
       
        public DateTime? TaskCloseDate { get; set; }
    }

}
