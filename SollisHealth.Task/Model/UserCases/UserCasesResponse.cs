using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SollisHealth.Task.Model.UserCases
{
    public class UserCasesResponse
    {
        public bool success { get; set; }
        public string Message { get; set; }
        public UserSummaries data { get; set; }
    }
    public class UserSummary
    {
        public UserOpenCasesUI summary { get; set; }

    }

    public class UserSummaries
    {
        public List<UserSummary> summaries { get; set; }
    }


}
