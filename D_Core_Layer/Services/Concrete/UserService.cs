using D_Core_Layer.Services.Abstract;
using D_Domain_Layer.Entities;
using D_Persistence_Layer.Model;
using D_Persistence_Layer.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_Core_Layer.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<BaseResponseModel> Login(LoginModel model)
        {
            var result = await _userRepository.Login(model);
            return result;
        }

        public async Task<BaseResponseModel> Register(RegisterModel model)
        {
            var result= await _userRepository.Register(model);
            return result;
        }
    }
}
