using Referral_Codes_Hub.Application.DTOS;
using Referral_Codes_Hub.Application.RoleManagement.Commands;
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
        Task<ApiResponse<List<Role>>> GetRolesAsync();

        Task<ApiResponse<List<string>>> GetUserRolesAsync(string emailAddress);

        Task<ApiResponse<bool>> CreateNewRoleAsync(string[] roles);

        Task<ApiResponse<bool>> AddUserRolesAsync(AssignUserNewRole request);

    }
}
