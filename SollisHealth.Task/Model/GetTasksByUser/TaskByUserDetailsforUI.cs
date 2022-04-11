using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SollisHealth.Task.Model.GetTasksByUser
{
    public class TaskByUserDetailsforUI
    {
        [Key]
        public int TaskID { get; set; }

        public DateTime? TaskOpenDate { get; set; }

        [DefaultValue("")]
        public string RequestTypeName { get; set; }

        [DefaultValue(0)]
        public int RequestTypeID { get; set; }

        [DefaultValue("")]
        public string SLAPriorityName { get; set; }

        [DefaultValue("")]
        public string SLACloseUnit { get; set; }

        [DefaultValue(0)]
        public int SLARiskVAL { get; set; }
        [DefaultValue(0)]
        public int SLAExceedVAL { get; set; }
        [DefaultValue(0)]
        public int SLAPriorityID { get; set; }

        [DefaultValue(0)]
        public int TaskRoleID { get; set; }
        [DefaultValue(0)]
        public int RoleId { get; set; }
        [DefaultValue("")]
        public string MemberID { get; set; }

        [DefaultValue(0)]
        public string MemberInfo { get; set; }

        [DefaultValue("")]
        public string MemberDetails { get; set; }

        [DefaultValue(0)]
        public int AssignedUserId { get; set; }

        [DefaultValue("")]
        public string AssignedUserName { get; set; }

        public DateTime? TaskCloseDate { get; set; }

      //    public TimeSpan? ElapsedTime { get; set; }
        public string ElapsedTime { get; set; }

        [DefaultValue("")]
        public string TaskStatusName { get; set; }

        [DefaultValue(0)]
        public int TaskStatusID { get; set; }
        [DefaultValue("")]
        public string Resolution { get; set; }
    }

}
