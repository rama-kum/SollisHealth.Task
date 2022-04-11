using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SollisHealth.Task.Model.GetTaskServicelevelSummary
{
    public class TaskServicelevelSummaryOutput
    {
        [Key]
        public int User_ID { get; set; }
        public int RoleID { get; set; }
        public string Status { get; set; }
        public Int64 Count { get; set; }



    }

}
