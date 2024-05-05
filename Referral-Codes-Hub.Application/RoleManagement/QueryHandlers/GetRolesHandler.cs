using MediatR;
using Referral_Codes_Hub.Application.Abstractions;
using Referral_Codes_Hub.Application.DTOS;
using Referral_Codes_Hub.Application.RoleManagement.Queries;
using Referral_Codes_Hub.Domain.Entities;


namespace Referral_Codes_Hub.Application.RoleManagement.QueryHandlers
{
    public class GetRolesHandler : IRequestHandler<GetAllRolesQuery, ApiResponse<List<Role>>>
    {
        private readonly IRoleRepository _roleRepository;
        public GetRolesHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<ApiResponse<List<Role>>> Handle(GetAllRolesQuery getAllRolesQuery, CancellationToken cancellationToken)
        {
            return await _roleRepository.GetRolesAsync();
        }

    }

    public class GetUserRolesHandler : IRequestHandler<GetUserRolesQuery, ApiResponse<List<string>>>
    {
        private readonly IRoleRepository _roleRepository;
        public GetUserRolesHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<ApiResponse<List<string>>> Handle(GetUserRolesQuery getUserRolesQuery, CancellationToken cancellationToken)
        {
            return await _roleRepository.GetUserRolesAsync(getUserRolesQuery.emailAddress);
        }

    }
}
