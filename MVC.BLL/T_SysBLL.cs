using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.DAL;
using MVC.Models;
using System.Linq.Expressions;

namespace MVC.BLL
{

    public partial class T_SysBLL : BaseBLL<T_Sys>, IT_SysBLL
    {
        /// <summary>
        /// 实现这个对象，把类型传给基类
        /// </summary>
        /// <returns></returns>
        public override BaseDAL<T_Sys> GetDAL()
        { 
            return new T_SysDAL();
        }
        
        /// <summary>
        /// Lambda查询
        /// </summary>
        /// <param name="LambdaWhere">查询条件，Lambda表达式</param>
        /// <param name="Orders">排序字典key:排序的字段,value:asc升序/desc降序</param> 
        /// <returns></returns>
        public List<T_SysModel> Filter(Expression<Func<T_SysModel, bool>> LambdaWhere = null, Dictionary<string, string> Orders = null)
        {
            List<T_SysModel> result = new List<T_SysModel>();
            MyVisitor<T_SysModel, T_Sys> visitor = new MyVisitor<T_SysModel, T_Sys>();
            var where = visitor.Modify(LambdaWhere);
            result = dal.Filter(where, Orders).Select(s => new T_SysModel
            {
                Id = s.Id,
                Name=s.Name, 
                Remark=s.Remark,
                Listorder=s.Listorder,
            }).ToList();
            return result;
        }
    }
 
}
