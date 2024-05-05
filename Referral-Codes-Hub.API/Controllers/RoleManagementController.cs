using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Referral_Codes_Hub.Application.DTOS;
using Referral_Codes_Hub.Application.ReferralCode.Queries;
using Referral_Codes_Hub.Application.RoleManagement.Commands;
using Referral_Codes_Hub.Application.RoleManagement.Queries;
using Referral_Codes_Hub.Domain.Entities;
using System.Net.Mail;

namespace Referral_Codes_Hub.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("[controller]")]
    public class RoleManagementController : Controller
    {
        private readonly IMediator mediator;
        public RoleManagementController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [HttpGet("[action]")]
        public async Task<ApiResponse<List<Role>>> GetAllUserRoles() => await this.mediator.Send(new GetAllRolesQuery());
        [HttpGet("[action]/{emailAddress}")]
        public async Task<ApiResponse<List<string>>> GetUserRoles(string emailAddress) => await this.mediator.Send(new GetUserRolesQuery() { emailAddress= emailAddress });
        [HttpPost("[action]")]
        public async Task<ApiResponse<bool>> CreateNewRole([FromBody] string[] roles) => await this.mediator.Send(new CreateNewRoleQuery() { roles= roles});
        [HttpPost("[action]/{emailAddress}")]
        public async Task<ApiResponse<bool>> AssignRoleToUser([FromBody] string[] roles, string emailAddress) => await this.mediator.Send(new AssignUserNewRole() {emailAddress=emailAddress,roles=roles });
    }
}
