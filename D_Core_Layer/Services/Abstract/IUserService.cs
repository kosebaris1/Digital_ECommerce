using D_Persistence_Layer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_Core_Layer.Services.Abstract
{
    public interface IUserService {
        Task<BaseResponseModel> Register(RegisterModel model);
        Task<BaseResponseModel> Login(LoginModel model);
     
    }
}
