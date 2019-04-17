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
    public partial class T_RoleBLL : BaseBLL<T_Role>, IT_RoleBLL
    {
        /// <summary>
        /// 实现这个对象，把类型传给基类
        /// </summary>
        /// <returns></returns>
        public override BaseDAL<T_Role> GetDAL()
        {
            return new T_RoleDAL();
        }
        public int AddData(T_RoleModel model)
        {
            return this.Add(model.ToModel());
        }

        public int EditData(T_RoleModel model)
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
            T_Role newdata = (T_Role)Helper.Method.CopyModel(model, data);
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
        public int DeleteData(T_RoleModel model)
        {
            return this.Delete(model.Id);
        } 
        /// <summary>
        /// Lambda查询
        /// </summary>
        /// <param name="LambdaWhere">查询条件，Lambda表达式</param>
        /// <param name="Orders">排序字典key:排序的字段,value:asc升序/desc降序</param> 
        /// <returns></returns>
        public List<T_RoleModel> Filter(Expression<Func<T_RoleModel, bool>> LambdaWhere = null, Dictionary<string, string> Orders = null)
        {
            List<T_RoleModel> result = new List<T_RoleModel>(); 
            MyVisitor<T_RoleModel, T_Role> visitor = new MyVisitor<T_RoleModel, T_Role>();
           var where = visitor.Modify(LambdaWhere); 
            result = dal.Filter(where, Orders).DTOList().ToList();
            return result;
        } 
        public DataGrid<T_RoleModel> Search(T_RoleModel model, Dictionary<string, string> Orders = null, int PageSize = 15, int PageIndex = 100)
        {
            throw new NotImplementedException();
        }
         
    }
    
}
