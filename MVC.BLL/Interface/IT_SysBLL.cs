using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.Models;
using System.Linq.Expressions;
namespace MVC.BLL
{
    public interface IT_SysBLL
    {
        /// <summary>
        /// Lambda查询
        /// </summary>
        /// <param name="LambdaWhere">查询条件，Lambda表达式</param>
        /// <param name="Orders">排序字典key:排序的字段,value:asc升序/desc降序</param> 
        /// <returns></returns>
        List<T_SysModel> Filter(Expression<Func<T_SysModel, bool>> LambdaWhere = null, Dictionary<string, string> Orders = null);
        
    }
}
