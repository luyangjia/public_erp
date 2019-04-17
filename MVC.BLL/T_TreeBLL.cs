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

    public partial class T_TreeBLL : BaseBLL<T_Tree>, IT_TreeBLL
    {
        /// <summary>
        /// 实现这个对象，把类型传给基类
        /// </summary>
        /// <returns></returns>
        public override BaseDAL<T_Tree> GetDAL()
        {
            return new T_TreeDAL();
        }
        public int AddData(T_TreeModel model)
        {
            return this.Add(model.ToModel());
        }

        public int EditData(T_TreeModel model)
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
            T_Tree newdata = (T_Tree)Helper.Method.CopyModel(model, data);
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
        public int DeleteData(T_TreeModel model)
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
        public DataGrid<T_TreeModel> Search(T_TreeModel model, Dictionary<string, string> Orders = null, int PageSize = 15, int PageIndex = 100)
        { 
            throw new NotImplementedException();
        } 
        /// <summary>
        /// Lambda查询
        /// </summary>
        /// <param name="LambdaWhere">查询条件，Lambda表达式</param>
        /// <param name="Orders">排序字典key:排序的字段,value:asc升序/desc降序</param> 
        /// <returns></returns>
        public List<T_TreeModel> Filter(Expression<Func<T_TreeModel, bool>> LambdaWhere = null, Dictionary<string, string> Orders = null)
        {
            List<T_TreeModel> result = new List<T_TreeModel>();
            MyVisitor<T_TreeModel, T_Tree> visitor = new MyVisitor<T_TreeModel, T_Tree>();
            var where = visitor.Modify(LambdaWhere);
            result = dal.Filter(where, Orders).DTOList().ToList();
            return result;
        }
        public List<T_TreeMenuModel> Tree(Dictionary<string, object> dictionary = null)
        {
            List<T_TreeMenuModel> result = new List<T_TreeMenuModel>();
            T_TreeMenuModel data = new T_TreeMenuModel();
            List<T_TreeModel> list = new List<T_TreeModel>();  
            Expression<Func<T_Tree, bool>> lambdaWhere =null;
             foreach (var dic in dictionary)
            {
                switch (dic.Key)
                {
                    case "Enable":
                        lambdaWhere = f => f.Enable == true;
                         break;  
                    default:
                        break;
                }
            }


             list = dal.Filter(lambdaWhere).DTOList().ToList();

            var parent = list.Where(w => w.ParentId == null).OrderBy(b=>b.Listorder).ToList();
            foreach (var item in parent)
             {
                data = new T_TreeMenuModel();
                data.Id=item.Id;
                data.Name=item.Name;
                data.ChineseName = item.ChineseName;
                data.Keys = item.Keys;
                data.Listorder = item.Listorder;
                data.iconCls = item.Icon;
                data.Icon = item.Icon;
                data.Enable = item.Enable;
                data.Url = item.Url;
                if (list.Count(w => w.ParentId == item.Id) > 0)
                    data.children = TreeChildren(list, item.Id);

                result.Add(data);

             }


            return result;
        }

        public List<T_TreeMenuModel> TreeChildren(List<T_TreeModel> node, int parentId)
        {
            List<T_TreeMenuModel> newnode = new List<T_TreeMenuModel>();

            var parent = node.Where(w => w.ParentId == parentId).OrderBy(b => b.Listorder).ToList();
            if (parent.Count()>0)
            {
                foreach (var item in parent)
                {
                    T_TreeMenuModel data = new T_TreeMenuModel();
                    data.Id = item.Id;
                    data.Name = item.Name;
                    data.ChineseName = item.ChineseName;
                    data.Keys = item.Keys;
                    data.Listorder = item.Listorder;
                    data.iconCls = item.Icon;
                    data.Icon = item.Icon;
                    data.Enable = item.Enable;
                    data.Url = item.Url;
                    data.ParentId = item.ParentId;
                    if (node.Count(w => w.ParentId == item.Id) > 0)
                        data.children = TreeChildren(node, item.Id);

                    newnode.Add(data);
                }
            }

            return newnode;
             
        }
         
        public List<T_TreeCombo> TreeParent()
        {
            List<T_TreeCombo> result = new List<T_TreeCombo>();
            T_TreeCombo data = new T_TreeCombo()
                {
                     id=0,
                     text="",
                     children=null,
                };
            result.Add(data); 
            List<T_TreeModel> list = new List<T_TreeModel>();
            list = dal.Filter(o => o.Enable).DTOList().ToList();

            var parent = list.Where(w => w.ParentId == null).OrderBy(b => b.Listorder).ToList();
            foreach (var item in parent)
            {
                 data = new T_TreeCombo();
                data.id = item.Id;
                data.text = item.Name;
                var node = list.Where(w => w.ParentId == item.Id).OrderBy(b => b.Listorder).ToList();
                if (node.Count() > 0)
                {
                    List<T_TreeCombo> children = new List<T_TreeCombo>();
                    foreach (var item2 in node)
                    {
                        T_TreeCombo data2 = new T_TreeCombo();
                        data2.id = item2.Id;
                        data2.text = item2.Name;
                        children.Add(data2);
                    }
                    data.children = children;
                }  
                result.Add(data); 
            }


            return result;
        }
        
    }
}
