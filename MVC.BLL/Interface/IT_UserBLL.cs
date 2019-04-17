using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.Models;
using System.Linq.Expressions;
namespace MVC.BLL
{
    public interface IT_UserBLL : BaseInterface<T_UserModel>
    {  
        /// <summary>
       /// 登录查询
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
       LoginModel LoginUser(LoginModel model); 
      
    }
}
