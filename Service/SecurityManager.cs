using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using StoreManagement.Models;

namespace StoreManagement.Service
{
    public class SecurityManager
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtConfig _jwtConfig;
        public SecurityManager(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            JwtConfig jwtConfig
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtConfig = jwtConfig;
        }
        public async Task<UserAuth> AuthenticateUser(User user)
        {
            IdentityUser appUser = null;
            UserAuth userAuth = new UserAuth();
            List<UserClaim> list = new List<UserClaim>();
            var result = await _signInManager.PasswordSignInAsync(user.UserName, user.Password, false, false);

            if (!result.Succeeded)
                return userAuth;

            appUser = _userManager.Users.SingleOrDefault(r => r.UserName == user.UserName);
            if (appUser == null)
                return userAuth;

            userAuth.UserName = user.UserName;
            userAuth.IsAuthenticated = true;
            userAuth.Claims = await GetUserClaimsAsync(appUser);// await _userManager.GetClaimsAsync(appUser);
            userAuth.BearerToken = GenerateJwtToken(appUser);

            return userAuth;
        }
        // Retrieve Claims
        protected async Task<List<UserClaim>> GetUserClaimsAsync(IdentityUser user)
        {
            List<UserClaim> list = new List<UserClaim>();
            var claims = new List<Claim>(await _userManager.GetClaimsAsync(user));
            foreach (var claim in claims)
            {
                list.Add(new UserClaim() { ClaimValue = claim.Value, ClaimType = claim.Type });
            }
            return list;
        }

        // Create Token 
        private string GenerateJwtToken(IdentityUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddMinutes(Convert.ToDouble(_jwtConfig.MinutesToExpiration));

            var token = new JwtSecurityToken(
                issuer: _jwtConfig.Issuer,
                audience: _jwtConfig.Audience,
                claims: claims,
                notBefore: DateTime.Now,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}