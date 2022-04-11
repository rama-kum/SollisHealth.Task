using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SollisHealth.Task.Model.GetTasksByUser
{
    public class TaskByUserOutput
    {
        [Key]
        public int Task_ID { get; set; }

        public DateTime? Task_Open_Date { get; set; }

        [DefaultValue("")]
        public string Request_Type_Name { get; set; }

        [DefaultValue(0)]
        public int Request_Type_ID { get; set; }

        [DefaultValue("")]
        public string SLA_Priority_Name { get; set; }

        [DefaultValue("")]
        public string SLA_Close_Unit { get; set; }

        [DefaultValue(0)]
        public int SLA_Risk_VAL { get; set; }
        [DefaultValue(0)]
        public int SLA_Exceed_VAL { get; set; }
        [DefaultValue(0)]
        public int SLA_Priority_ID { get; set; }

        [DefaultValue(0)]
        public int Task_Role_ID { get; set; }
        [DefaultValue(0)]
        public int role_id { get; set; }
        [DefaultValue("")]
        public string Member_ID { get; set; }

        [DefaultValue(0)]
        public string Member_Info { get; set; }

        [DefaultValue("")]
        public string Member_Details { get; set; }

        [DefaultValue(0)]
        public int Assigned_User_id { get; set; }

        [DefaultValue("")]
        public string Assigned_User_name { get; set; }

        public DateTime? Task_Close_Date { get; set; }

        public TimeSpan? Elapsed_Time { get; set; }

        [DefaultValue("")]
        public string task_status_name { get; set; }

        [DefaultValue(0)]
        public int Task_Status_ID { get; set; }
        [DefaultValue("")]
        public string Resolution { get; set; }
    }

}

