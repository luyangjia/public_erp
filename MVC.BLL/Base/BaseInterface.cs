using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.Models;
using System.Linq.Expressions;
namespace MVC.BLL
{ 
    /// <summary>
    /// 泛型接口基础操作，增，删，改，查
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface BaseInterface<T> where T : class,new()
    {
        /// <summary>
        /// 增加数据
        /// </summary>
        /// <returns></returns>
        int AddData(T model);
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int EditData(T model);
        /// <summary>
        /// 根据对象属性修改,满足只修改其中几个字段
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int EditData(int id, object model);
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int DeleteData(T model);
        /// <summary>
        /// 删除Id数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int DeleteData(int id);
        /// <summary>
        /// 复杂查询
        /// </summary>
        /// <param name="model">查询对象</param>
        /// <param name="Orders">排序字典key:排序的字段,value:asc升序/desc降序</param> 
        /// <param name="PageSize">每页行数，默认15</param>
        /// <param name="PageIndex">当前页码，默认100</param> 
        /// <returns></returns>
        DataGrid<T> Search(T model, Dictionary<string, string> Orders = null, int PageSize = 15, int PageIndex = 100); 
        /// <summary>
        /// Lambda查询
        /// </summary>
        /// <param name="LambdaWhere">查询条件，Lambda表达式</param>
        /// <param name="Orders">排序字典key:排序的字段,value:asc升序/desc降序</param> 
        /// <returns></returns>
        List<T> Filter(Expression<Func<T, bool>> LambdaWhere = null, Dictionary<string, string> Orders = null);
         
    }
}
