using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SollisHealth.Task.Model.GetOpenTaskSummary
{
   
    public class OpenTaskSummaryRequest
    {
        public int UserID { get; set; }
        public int RoleID { get; set; }

    }

}
