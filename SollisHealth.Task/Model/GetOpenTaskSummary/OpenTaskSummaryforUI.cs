using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SollisHealth.Task.Model.GetOpenTaskSummary
{
    public class OpenTaskSummaryforUI
    {
        [Key]
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public string UserName { get; set; }
        public string Status { get; set; }
        public Int64 Count { get; set; }
    }

}
