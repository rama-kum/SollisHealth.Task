using SollisHealth.Task.Model;
using SollisHealth.Task.Model.UserCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SollisHealth.Task.Interface
{
    public interface IUserBO
    {
        Task<UserCasesResponse> getusercases();
    }
}
