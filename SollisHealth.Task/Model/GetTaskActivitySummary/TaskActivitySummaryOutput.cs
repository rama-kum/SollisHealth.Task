using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SollisHealth.Task.Model.GetTaskActivitySummary
{
    public class TaskActivitySummaryOutput
    {
        [Key]
        public int User_ID { get; set; }        
        public int RoleID { get; set; }
        public string Priority_Name { get; set; }
        public int No_Of_Priority { get; set; }


    }

 
}
