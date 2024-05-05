using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Referral_Codes_Hub.Application.Abstractions;
using Referral_Codes_Hub.Application.DTOS;
using Referral_Codes_Hub.Application.RoleManagement.Commands;
using Referral_Codes_Hub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Referral_Codes_Hub.Infrastructure.Repositories
{
    public class RolesRepository : IRoleRepository
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public RolesRepository(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        
        public async Task<ApiResponse<List<Role>>> GetRolesAsync() {

            List<Role> allRoles = await _roleManager.Roles.Select(x => new Role { Id = Guid.Parse(x.Id), Name = x.Name }).ToListAsync();      
            return CreateAPIResponse<List<Role>>.GenerateResponse(true, "All Roles Retrieved Successfully.", allRoles);
        }  
                
        public async Task<ApiResponse<List<string>>> GetUserRolesAsync(string emailAddress)
        {
            IList<string> roles = [];
            var user = await _userManager.FindByEmailAsync(emailAddress);
            if (user != null) {
                roles = await _userManager.GetRolesAsync(user);
            }
            return CreateAPIResponse<List<string>>.GenerateResponse(true, "User Roles Retrieved Successfully.", roles.ToList());
        }
        public async Task<ApiResponse<bool>> CreateNewRoleAsync(string[] roles)
        {
            var roleList = new List<string>();
            foreach (var role in roles)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                    roleList.Add(role);
                }
            }
            return CreateAPIResponse<bool>.GenerateResponse(true, "New Role(s) Created.", true);

        }

        public async Task<ApiResponse<bool>> AddUserRolesAsync(AssignUserNewRole request)
        {
            var user = await _userManager.FindByEmailAsync(request.emailAddress);
            if (user != null) {

                foreach (var role in request.roles)
                {
                    var existingRole= await _userManager.IsInRoleAsync(user, role);

                    if (!existingRole) {
                        await _roleManager.CreateAsync(new IdentityRole(role));
                        return CreateAPIResponse<bool>.GenerateResponse(true, "User Added to Role(s) Successfully.", true);
                    }
                }
            }
            return CreateAPIResponse<bool>.GenerateResponse(false, "Failed at Assigning User to a role.", false);

        }     
    }
}
