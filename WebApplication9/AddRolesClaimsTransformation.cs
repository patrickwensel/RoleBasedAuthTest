using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplication9.Models;

namespace WebApplication9
{
    public class AddRolesClaimsTransformation : IClaimsTransformation
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AddRolesClaimsTransformation(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            // Clone current identity
            var clone = principal.Clone();
            var newIdentity = (ClaimsIdentity)clone.Identity;

            // Support AD and local accounts
            var nameId = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier ||
                                                              c.Type == ClaimTypes.Name);
            if (nameId == null)
            {
                return principal;
            }

            // Get user from database
            var user = await _userManager.FindByIdAsync(nameId.Value);
            if (user == null)
            {
                return principal;
            }

            var roles = await _userManager.GetRolesAsync(user);
            // Add role claims to cloned identity
            foreach (var role in roles)
            {
                var claim = new Claim(newIdentity.RoleClaimType, role);
                newIdentity.AddClaim(claim);
                var claim2 = new Claim("ContactId", "123");
                newIdentity.AddClaim(claim2);
            }

            return clone;
        }
    }
}
