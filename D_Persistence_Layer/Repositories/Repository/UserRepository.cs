using D_Domain_Layer.Entities;
using D_Infrastructure_Layer.Extensions;
using D_Infrastructure_Layer.Models;
using D_Persistence_Layer.AppDbContext;
using D_Persistence_Layer.Model;
using D_Persistence_Layer.Repositories.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace D_Persistence_Layer.Repositories.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly string SecretKey;
        public UserRepository(ApplicationDbContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration) : base(context)
        {
            SecretKey = configuration["JWTSettings:SecretKey"];
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public async Task<BaseResponseModel> Login(LoginModel model)
        {
            bool isItTrue = await IsAnyItem(x => x.Email == model.Email);
            if (isItTrue)
            {
                User user = await _userManager.FindByNameAsync(model.Email);
                bool isValid = await _userManager.CheckPasswordAsync(user, model.Password);
                if (isValid)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    TokenModel token = await HandleTokenValidator.HandleToken(roles, user, SecretKey);
                    return new BaseResponseModel
                    {
                        Success = true,
                        Message = "Login successful.",
                        Result = token
                    };
                }
                else
                {
                    return new BaseResponseModel
                    {
                        Success = false,
                        Message = "Invalid password."
                    };

                }
            }
            return new BaseResponseModel
            {
                Success = false,
                Message = "Invalid UserInfo."
            };
        }
        public async Task<BaseResponseModel> Register(RegisterModel model)
        {
            bool isAnyUser = await IsAnyItem(x => x.Email.ToLower() == model.Email.ToLower());
            if (isAnyUser)
            {
                return new BaseResponseModel
                {
                    Success = false,
                    Message = "User already exists with this email."
                };
            }
            var user = new User
            {
                Email = model.Email,
                UserName = model.Email,
                Name = model.Name,

            };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var isItTrue = await _roleManager.RoleExistsAsync("Admin");
                if (!isItTrue)
                {
                    await _roleManager.CreateAsync(new IdentityRole("Admin"));
                    await _roleManager.CreateAsync(new IdentityRole("SuperVisor"));
                    await _roleManager.CreateAsync(new IdentityRole("Customer"));
                    await _userManager.AddToRoleAsync(user, "Admin");
                    await _userManager.AddToRoleAsync(user, "SuperVisor");
                    await _userManager.AddToRoleAsync(user, "Customer");
                }
                else
                {
                    await _userManager.AddToRoleAsync(user, "Customer");

                }
                return new BaseResponseModel
                {
                    Success = true,
                    Message = "User registered successfully."
                };

            }
            else
            {
                return new BaseResponseModel
                {
                    Success = false,
                    Message = result.Errors.Select(e => e.Description).ToList()
                };
            }
        }

    }
}
