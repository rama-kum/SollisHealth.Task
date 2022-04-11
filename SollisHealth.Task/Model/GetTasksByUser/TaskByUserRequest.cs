using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SollisHealth.Task.Model.GetTasksByUser
{
    public class TaskByUserRequest
    {
        [Key]
        public int RoleId { get; set; }

        public int AssignedUserId { get; set; }


    }

}
