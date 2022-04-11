using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SollisHealth.Task.Model.GetAllTasks
{
    public class TaskOutput
    {

        [DefaultValue("")]
        public string UserName { get; set; } = " ";
          [Key]
        public int Task_ID { get; set; }

        
        public DateTime? Task_Open_Date { get; set; }

        [DefaultValue("")]
        public string Request_Type_Name { get; set; } 

        [DefaultValue("")]
        public string Member_ID { get; set; }

        [DefaultValue("")]
        public string Task_Priority_Name { get; set; } 

        [DefaultValue("")]
        public string SLA_Close_Unit { get; set; } 

        [DefaultValue(0)]
        public int SLA_CLOSE_VAL { get; set; }

        [DefaultValue(0)]
        public int Task_Status_ID { get; set; }

        [DefaultValue("")]
        public string Assigned_User { get; set; }

        [DefaultValue("")]
        public string Task_Description { get; set; }

        [DefaultValue("")]
        public string Task_Status_Name { get; set; }

        
        public DateTime? Task_Close_Date { get; set; }

    }


 
}
