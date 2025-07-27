using D_Domain_Layer.Entities;
using D_Persistence_Layer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_Persistence_Layer.Repositories.Interface
{

 
    public interface IUserRepository
    {
        Task<BaseResponseModel> Login(LoginModel model);
        Task<BaseResponseModel> Register(RegisterModel model);
    }
}
