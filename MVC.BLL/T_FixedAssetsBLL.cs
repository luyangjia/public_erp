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
    public partial class T_FixedAssetsBLL : BaseBLL<T_FixedAssets>, IT_FixedAssetsBLL
    {
        /// <summary>
        /// 实现这个对象，把类型传给基类
        /// </summary>
        /// <returns></returns>
        public override BaseDAL<T_FixedAssets> GetDAL()
        {
            return new T_FixedAssetsDAL();
        }
        public int AddData(T_FixedAssetsModel model)
        {
            int i = 0;
            for (int k = 1; k <= model.CreateNum;k++ )
            {
                i = this.Add(model.ToModel());
            }
           return i;
        } 
        public int EditData(T_FixedAssetsModel model)
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
            var newdata = (T_FixedAssets)Helper.Method.CopyModel(model,data);
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
        public int DeleteData(T_FixedAssetsModel model)
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
        public DataGrid<T_FixedAssetsModel> Search(T_FixedAssetsModel model, Dictionary<string, string> Orders = null, int PageSize = 15, int PageIndex = 100)
        {
            Expression<Func<T_FixedAssets, bool>> where = null; //最终查询条件
            var lambdaList = new List<Expression<Func<T_FixedAssets, bool>>>(); //lambda查询条件集合
            int total = 0; //总行数  
            if (model.AssetsNo!=null)
                lambdaList.Add(c => c.AssetsNo.Contains(model.AssetsNo));
            if (model.Name!=null)
                lambdaList.Add(c => c.Name.Contains(model.Name));
            if (model.CompanyId.HasValue)
                lambdaList.Add(c => c.CompanyId == (int)model.CompanyId);
            if (model.Category != null && model.Category != "　")
                lambdaList.Add(c => c.Category==model.Category);
            if (model.BeginTime.HasValue)
                lambdaList.Add(c => c.DatePurchase >= (DateTime)model.BeginTime);
            if (model.EndTime.HasValue)
                lambdaList.Add(c => c.DatePurchase <= (DateTime)model.EndTime);
            if (model.StatusList.Count()>0)
                lambdaList.Add(c => model.StatusList.Any(a=>c.Status==a));
            //将集合表达式树转换成Expression表达式树
            MyVisitor<T_FixedAssets, T_FixedAssets> visitor = new MyVisitor<T_FixedAssets, T_FixedAssets>();
            where = visitor.Modify(lambdaList);
            var list = dal.Search(out total, where, Orders, PageSize, PageIndex).DTOList().ToList();
            var result = new DataGrid<T_FixedAssetsModel>()
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
        public List<T_FixedAssetsModel> Filter(Expression<Func<T_FixedAssetsModel, bool>> LambdaWhere = null, Dictionary<string, string> Orders = null)
        {
            List<T_FixedAssetsModel> result = new List<T_FixedAssetsModel>();
            MyVisitor<T_FixedAssetsModel, T_FixedAssets> visitor = new MyVisitor<T_FixedAssetsModel, T_FixedAssets>();
            var where = visitor.Modify(LambdaWhere);
            result = dal.Filter(where, Orders).DTOList().ToList();
            return result;
        }
    }

}
