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
    public partial class T_SupplierBLL : BaseBLL<T_Supplier>, IT_SupplierBLL
    {
        /// <summary>
        /// 实现这个对象，把类型传给基类
        /// </summary>
        /// <returns></returns>
        public override BaseDAL<T_Supplier> GetDAL()
        {
            return new T_SupplierDAL();
        }
        public int AddData(T_SupplierModel model)
        {
            return this.Add(model.ToModel());
        }

        public int EditData(T_SupplierModel model)
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
            T_Supplier newdata = (T_Supplier)Helper.Method.CopyModel(model, data);
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
        public int DeleteData(T_SupplierModel model)
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
        public DataGrid<T_SupplierModel> Search(T_SupplierModel model, Dictionary<string, string> Orders = null, int PageSize = 15, int PageIndex = 100)
        {
            Expression<Func<T_Supplier, bool>> where = null; //最终查询条件
            var lambdaList = new List<Expression<Func<T_Supplier, bool>>>(); //lambda查询条件集合
            int total = 0; //总行数  
            if (model.COGS != null)
                lambdaList.Add(c => c.COGS.Contains(model.COGS) || c.COGS2.Contains(model.COGS));
            if (model.Company != null)
                lambdaList.Add(c => c.Company.Contains(model.Company));
            if (model.CategoryId != null && model.CategoryId > 0)
                lambdaList.Add(c => c.CategoryId == model.CategoryId || (c.Category != null && c.Category.ParentId == model.CategoryId));
            //将集合表达式树转换成Expression表达式树
            MyVisitor<T_Supplier, T_Supplier> visitor = new MyVisitor<T_Supplier, T_Supplier>();
            where = visitor.Modify(lambdaList);
            var list = dal.Search(out total, where, Orders, PageSize, PageIndex).DTOList().ToList();
            var result = new DataGrid<T_SupplierModel>()
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
        public List<T_SupplierModel> Filter(Expression<Func<T_SupplierModel, bool>> LambdaWhere = null, Dictionary<string, string> Orders = null)
        {
            List<T_SupplierModel> result = new List<T_SupplierModel>();
            MyVisitor<T_SupplierModel, T_Supplier> visitor = new MyVisitor<T_SupplierModel, T_Supplier>();
            var where = visitor.Modify(LambdaWhere);
            result = dal.Filter(where, Orders).DTOList().ToList();
            return result;
        }


    }

}
