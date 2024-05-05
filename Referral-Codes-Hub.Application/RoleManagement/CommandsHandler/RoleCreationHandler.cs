using MediatR;
using Referral_Codes_Hub.Application.Abstractions;
using Referral_Codes_Hub.Application.DTOS;
using Referral_Codes_Hub.Application.RoleManagement.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Referral_Codes_Hub.Application.RoleManagement.CommandsHandler
{
    public class CreateRoleHandler : IRequestHandler<CreateNewRoleQuery,ApiResponse<bool>>
    {
        private readonly IRoleRepository _roleRepository;
        public CreateRoleHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<ApiResponse<bool>> Handle(CreateNewRoleQuery request, CancellationToken cancellationToken)
        {
            return await _roleRepository.CreateNewRoleAsync(request.roles);

        }
    }

    public class AssignUserNewRoleHandler : IRequestHandler<AssignUserNewRole, ApiResponse<bool>>
    {
        private readonly IRoleRepository _roleRepository;
        public AssignUserNewRoleHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<ApiResponse<bool>> Handle(AssignUserNewRole request, CancellationToken cancellationToken)
        {
            return await _roleRepository.AddUserRolesAsync(request);

        }
    }

}
