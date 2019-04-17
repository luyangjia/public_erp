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
    public partial class T_LeaveCarryOverBLL : BaseBLL<T_LeaveCarryOver>, IT_LeaveCarryOverBLL
    {
        /// <summary>
        /// 实现这个对象，把类型传给基类
        /// </summary>
        /// <returns></returns>
        public override BaseDAL<T_LeaveCarryOver> GetDAL()
        {
            return new T_LeaveCarryOverDAL();
        }
        public int AddData(T_LeaveCarryOverModel model)
        {
            return this.Add(model.ToModel());
        }

        public int EditData(T_LeaveCarryOverModel model)
        {
            return this.Edit(model.ToModel());
        }
        /// <summary>
        /// 根据对象属性修改,满足一张表只修改其中几个字段
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int EditData(int id, object model)
        {
            //先查后改
            var data = this.GetById(id); //tObj  
            T_LeaveCarryOver newdata = (T_LeaveCarryOver)Helper.Method.CopyModel(model, data);
            return this.Edit(newdata);
        }
        /// <summary>
        ///  根据主键Id删除  
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int DeleteData(int id)
        {
            return this.Delete(id);
        }
        public int DeleteData(T_LeaveCarryOverModel model)
        {
            return this.Delete(model.Id);
        }
        /// <summary>
        /// 复杂查询
        /// </summary>
        /// <param name="model">查询对象</param>
        /// <param name="Orders">排序字典key:排序的字段,value:asc升序/desc降序</param> 
        /// <param name="PageSize">每页行数，默认15</param>
        /// <param name="PageIndex">当前页码，默认100</param> 
        /// <returns></returns>
        public DataGrid<T_LeaveCarryOverModel> Search(T_LeaveCarryOverModel model, Dictionary<string, string> Orders = null, int PageSize = 15, int PageIndex = 100)
        {
            Expression<Func<T_LeaveCarryOver, bool>> where = null; //最终查询条件
            var lambdaList = new List<Expression<Func<T_LeaveCarryOver, bool>>>(); //lambda查询条件集合
            int total = 0; //总行数  
            #region 查询条件
            #endregion
            //将集合表达式树转换成Expression表达式树
            MyVisitor<T_LeaveCarryOver, T_LeaveCarryOver> visitor = new MyVisitor<T_LeaveCarryOver, T_LeaveCarryOver>();
            where = visitor.Modify(lambdaList);
            var list = dal.Search(out total, where, Orders, PageSize, PageIndex).DTOList().ToList();
            var result = new DataGrid<T_LeaveCarryOverModel>()
            {
                rows = list,
                total = total
            };
            return result;
        }
        /// <summary>
        /// Lambda查询
        /// </summary>
        /// <param name="LambdaWhere">查询条件，Lambda表达式</param>
        /// <param name="Orders">排序字典key:排序的字段,value:asc升序/desc降序</param> 
        /// <returns></returns>
        public List<T_LeaveCarryOverModel> Filter(Expression<Func<T_LeaveCarryOverModel, bool>> LambdaWhere = null, Dictionary<string, string> Orders = null)
        {
            List<T_LeaveCarryOverModel> result = new List<T_LeaveCarryOverModel>();
            MyVisitor<T_LeaveCarryOverModel, T_LeaveCarryOver> visitor = new MyVisitor<T_LeaveCarryOverModel, T_LeaveCarryOver>();
            var where = visitor.Modify(LambdaWhere);
            result = dal.Filter(where, Orders).DTOList().ToList();
            return result;
        }
    }

}
