using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineVindorel.Models
{
    public class dbInıt
    {
        private VindorelDbContext _ctx;
        private UserManager<Account> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public dbInıt(VindorelDbContext ctx, UserManager<Account> userManager,
            RoleManager<IdentityRole> rm)
        {
            _ctx = ctx;
            _userManager = userManager;
            _roleManager = rm;
        }
        public async Task InitializeDataAsync()
        {
            await CreateRolesAsync();
            await CreateUsersAsync();
        }
        private async Task CreateRolesAsync()
        {
            var roles = new[] { "Admin", "Player"};
            foreach (var role in roles)
            {
                var _role = await _roleManager.FindByNameAsync(role);
                if (_role == null)
                {
                    _role = new IdentityRole { Name = role };
                    await _roleManager.CreateAsync(_role);
                }
            }
        }
        private async Task CreateUsersAsync()
        {
            var email = "gurcaglarogulcan@gmail.com";
            var password = "5111@@can";
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                user = new Account { UserName = "AdminDef", Email = email};
                await _userManager.CreateAsync(user,"5111@@can");
            }
            if (!await _userManager.IsInRoleAsync(user, "Admin"))
            {
                await _userManager.AddToRoleAsync(user, "Admin");
            }

        }
    }

}
