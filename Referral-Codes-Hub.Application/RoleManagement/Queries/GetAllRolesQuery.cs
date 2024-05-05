using MediatR;
using Referral_Codes_Hub.Application.DTOS;
using Referral_Codes_Hub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Referral_Codes_Hub.Application.RoleManagement.Queries
{
    public class GetAllRolesQuery : IRequest<ApiResponse<List<Role>>>
    {
    }
    public class GetUserRolesQuery : IRequest<ApiResponse<List<string>>>
    {
        public string emailAddress { get; set; }
    }
}
