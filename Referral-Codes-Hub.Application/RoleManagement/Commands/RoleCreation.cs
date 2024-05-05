using MediatR;
using Referral_Codes_Hub.Application.DTOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Referral_Codes_Hub.Application.RoleManagement.Commands
{
    public class CreateNewRoleQuery : IRequest<ApiResponse<bool>>
    {
        public string[]  roles { get; set; }
    }
    public class AssignUserNewRole : IRequest<ApiResponse<bool>>
    {
        public string[] roles { get; set; }
        public string emailAddress { get; set; }
    }
}
