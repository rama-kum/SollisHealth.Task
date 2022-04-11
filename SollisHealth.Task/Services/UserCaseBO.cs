using SollisHealth.Task.Interface;
using SollisHealth.Task.Model;
using SollisHealth.Task.Model.UserCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SollisHealth.Task.Services
{
    public class UserCaseBO: IUserBO
    {
        private readonly IUserRepo _userRepo;
        public UserCaseBO(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }
        public async Task<UserCasesResponse> getusercases()
        {
            UserCasesResponse UserResponse = await _userRepo.getusercases();
            return UserResponse;

        }
    }
}
