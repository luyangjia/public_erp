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
    public partial class T_AgreeListBLL : BaseBLL<T_AgreeList>, IT_AgreeListBLL
    {
        /// <summary>
        /// 实现这个对象，把类型传给基类
        /// </summary>
        /// <returns></returns>
        public override BaseDAL<T_AgreeList> GetDAL()
        {
            return new T_AgreeListDAL();
        }
        public int AddData(T_AgreeListModel model)
        {
            return this.Add(model.ToModel());
        }

        public int EditData(T_AgreeListModel model)
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
            T_AgreeList newdata = (T_AgreeList)Helper.Method.CopyModel(model, data);
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
        public int DeleteData(T_AgreeListModel model)
        {
            return this.Delete(model.Id);
             
        }
        public int AddDataList(List<T_AgreeListModel> model)
        {
            int i=0;
           foreach(T_AgreeListModel m in model)
           {
               i=i+this.Add(m.ToModel());
           }
            return i;
        }

        public int EditDataList(List<T_AgreeListModel> model)
        {
            int i = 0;
            foreach (T_AgreeListModel m in model)
            {
                i = i + this.Edit(m.ToModel());
            }
            return i; 
        }

        public int DeleteDataList(List<T_AgreeListModel> model)
        {
            int i = 0;
            foreach (T_AgreeListModel m in model)
            {
                i = i + this.Delete(m.Id);
            }
            return i; 
        }
     
        /// <summary>
        /// 复杂查询
        /// </summary>
        /// <param name="model">查询对象</param>
        /// <param name="Orders">排序字典key:排序的字段,value:asc升序/desc降序</param> 
        /// <param name="PageSize">每页行数，默认15</param>
        /// <param name="PageIndex">当前页码，默认100</param> 
        /// <returns></returns>
        public DataGrid<T_AgreeListModel> Search(T_AgreeListModel model, Dictionary<string, string> Orders = null, int PageSize = 15, int PageIndex = 100)
        {
            Expression<Func<T_AgreeList, bool>> where = null; //最终查询条件
            var lambdaList = new List<Expression<Func<T_AgreeList, bool>>>(); //lambda查询条件集合
            int total = 0; //总行数  
            if (model.ProjectId != null && model.ProjectId > 0)
                lambdaList.Add(c => c.ProjectId == model.ProjectId);
            if (model.AgreeId != null && model.AgreeId > 0)
                lambdaList.Add(c => c.AgreeId == model.AgreeId);
            if (model.CategoryId != null && model.CategoryId > 0)
            {
                T_SysListBLL syslist = new T_SysListBLL();
                List<int> childer = syslist.GetChildren(1, (int)model.CategoryId);
                lambdaList.Add(c => childer.Contains((int)c.CategoryId)); 
            }
            //将集合表达式树转换成Expression表达式树
            MyVisitor<T_AgreeList, T_AgreeList> visitor = new MyVisitor<T_AgreeList, T_AgreeList>();
            where = visitor.Modify(lambdaList);
            var list = dal.Search(out total, where, Orders, PageSize, PageIndex).DTOList().ToList();
            var result = new DataGrid<T_AgreeListModel>()
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
        public List<T_AgreeListModel> Filter(Expression<Func<T_AgreeListModel, bool>> LambdaWhere = null, Dictionary<string, string> Orders = null)
        {
            List<T_AgreeListModel> result = new List<T_AgreeListModel>();
            MyVisitor<T_AgreeListModel, T_AgreeList> visitor = new MyVisitor<T_AgreeListModel, T_AgreeList>();
            var where = visitor.Modify(LambdaWhere);
            result = dal.Filter(where, Orders).DTOList().ToList();
            return result;
        }
    }

}



