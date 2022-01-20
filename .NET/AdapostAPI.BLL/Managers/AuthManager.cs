using AdapostAPI.BLL.Interfaces;
using AdapostAPI.DAL.Entities;
using AdapostAPI.DAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapostAPI.BLL.Managers
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenHelper _tokenHelper;
        
        public AuthManager(UserManager<User> userManager,
            SignInManager<User> signInManager,
            ITokenHelper tokenHelper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHelper = tokenHelper;
        }
        public async Task<LoginResult> Login(LoginModel loginModel)
        {
            var user = await _userManager.FindByEmailAsync(loginModel.Email);
            
            var role = await _userManager.GetRolesAsync(user);

            if (user == null)
            {
                return new LoginResult
                {
                    Success = false
                };
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginModel.Password, false);
        
            if (result.Succeeded)
            {
                var token = await _tokenHelper.CreateAccesToken(user);
                var refreshToken = _tokenHelper.CreateRefreshToken();

                user.RefreshToken = refreshToken;
                await _userManager.UpdateAsync(user);

                return new LoginResult
                {
                    Success = true,
                    AccesToken = token,
                    RefreshToken = refreshToken,
                    Role = role.FirstOrDefault()
                };
            }
            else
            {
                return new LoginResult
                {
                    Success = false
                };
            }
        }

        public async Task<string> Refresh(RefreshModel refreshModel)
        {
            var principal = _tokenHelper.GetPrincipalFromExpiredToken(refreshModel.AccesToken);
            var username = principal.Identity.Name;

            var user = await _userManager.FindByEmailAsync(username);

            if (user.RefreshToken != refreshModel.RefreshToken)
                return "Bad Refresh";

            var newJwtToken = await _tokenHelper.CreateAccesToken(user);

            return newJwtToken;
        }

        public async Task<bool> Register(RegisterModel registerModel)
        {
            var user = new User
            {
                Email = registerModel.Email,
                UserName = registerModel.Email
            };

            var result = await _userManager.CreateAsync(user, registerModel.Password);
            
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, registerModel.Role);

                return true;
            }

            return false;
        }
    }
}
