using Referral_Codes_Hub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Referral_Codes_Hub.Application.Abstractions
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetRolesAsync();

        Task<List<string>> GetUserRolesAsync(string emailAddress);

        Task<List<string>> AddUserRolesAsync(string[] roles);

        Task<bool> AddUserRolesAsync(string emailAddress,string[] roles);

    }
}
