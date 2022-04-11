using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SollisHealth.Task.Model.UserCases
{
    public class UserOpenCases
    {
        [Key]
        public string UserName { get; set; }
        public string Title { get; set; }       
        public int OpenCases { get; set; }

    }
}
