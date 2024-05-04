using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Referral_Codes_Hub.Application.Abstractions;
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
        async Task<List<Role>> IRoleRepository.GetRolesAsync() =>  
            await _roleManager.Roles.Select(x => new Role { Id = Guid.Parse(x.Id), Name = x.Name}).ToListAsync();

           
        async Task<List<string>> IRoleRepository.GetUserRolesAsync(string emailAddress)
        {
            var roles= await _userManager.GetRolesAsync(await _userManager.FindByEmailAsync(emailAddress));
            return roles.ToList();
        }
        async Task<List<string>> IRoleRepository.AddUserRolesAsync(string[] roles)
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
            return roleList;
        }

        async Task<bool> IRoleRepository.AddUserRolesAsync(string emailAddress, string[] roles)
        {
            var user = await _userManager.FindByEmailAsync(emailAddress);
            if (user != null) {

                foreach (var role in roles)
                {
                    var existingRole= await _userManager.IsInRoleAsync(user, role);

                    if (!existingRole) {
                        await _roleManager.CreateAsync(new IdentityRole(role));
                        return true;
                    }
                }
            }
            return false;

        }

       
    }
}
