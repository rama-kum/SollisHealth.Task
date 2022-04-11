using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SollisHealth.Task.Model.UserCases
{
    public class UserOpenCasesUI
    {
        [Key]
        public string Title { get; set; }
        public string Username { get; set; }
        public int OpenCases { get; set; }

    }
}
