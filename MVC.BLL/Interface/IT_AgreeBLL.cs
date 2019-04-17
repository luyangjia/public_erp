using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.Models;
using System.Linq.Expressions;
namespace MVC.BLL
{
    public interface IT_AgreeBLL:BaseInterface<T_AgreeModel>
    { 
        /// <summary>
        /// 协议签署
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int AgreeProject(T_AgreeModel model);
        /// <summary>
        /// 审批协议
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int ApporvalsProject(T_AgreeModel model);
    }
}
