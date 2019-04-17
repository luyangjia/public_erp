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
    public partial class T_SysListBLL : BaseBLL<T_SysList>, IT_SysListBLL
    {
        /// <summary>
        /// 实现这个对象，把类型传给基类
        /// </summary>
        /// <returns></returns>
        public override BaseDAL<T_SysList> GetDAL()
        {
            return new T_SysListDAL();
        }
        public int AddData(T_SysListModel model)
        {  
            return this.Add(model.ToModel());
        }

        public int EditData(T_SysListModel model)
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
            T_SysList newdata = (T_SysList)Helper.Method.CopyModel(model, data);
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
        public int DeleteData(T_SysListModel model)
        { 
            return this.Delete(model.Id);
        } 
      
        /// <summary>
        /// Lambda查询
        /// </summary>
        /// <param name="LambdaWhere">查询条件，Lambda表达式</param>
        /// <param name="Orders">排序字典key:排序的字段,value:asc升序/desc降序</param> 
        /// <returns></returns>
        public List<T_SysListModel> Filter(Expression<Func<T_SysListModel, bool>> LambdaWhere = null, Dictionary<string, string> Orders = null)
        {
            List<T_SysListModel> result = new List<T_SysListModel>();
            MyVisitor<T_SysListModel, T_SysList> visitor = new MyVisitor<T_SysListModel, T_SysList>();
            var where = visitor.Modify(LambdaWhere);
            result = dal.Filter(where, Orders).DTOList().ToList();
            return result;
        }
        public List<T_TreeSysListModel> Tree(int SysId, string Type="id")
        {
            List<T_TreeSysListModel> result = new List<T_TreeSysListModel>();
            T_TreeSysListModel data = new T_TreeSysListModel();
            List<T_SysListModel> list = new List<T_SysListModel>(); 
            list = dal.Filter(o => o.SysId == SysId).DTOList().ToList();
            int rank=1;
            var parent = list.Where(w => w.ParentId == null).OrderBy(b => b.Listorder).ToList();
            foreach (var item in parent)
            {
                data = new T_TreeSysListModel();
                data.Id = item.Id;
                data.text = item.Name;
                data.Remark = item.Remark;

                data.id =Type=="text" ? item.Name: item.Id.ToString();
                data.Name = item.Name;   
                data.Listorder = item.Listorder;
                data.Rank = rank;
                if (list.Count(w => w.ParentId == item.Id) > 0)
                    data.children = TreeChildren(list, item.Id, rank, Type);

                result.Add(data);

            }


            return result;
        }

        public List<T_TreeSysListModel> TreeChildren(List<T_SysListModel> node, int parentId, int rank, string Type)
        {
            List<T_TreeSysListModel> newnode = new List<T_TreeSysListModel>();

            var parent = node.Where(w => w.ParentId == parentId).OrderBy(b => b.Listorder).ToList();
            if (parent.Count() > 0)
            {
                foreach (var item in parent)
                {
                    T_TreeSysListModel data = new T_TreeSysListModel();
                    data.Id = item.Id;
                    data.Name = item.Name;
                    data.id = Type == "text" ? item.Name : item.Id.ToString();
                    data.text = item.Name;
                    data.Remark = item.Remark;
                    data.ParentId = item.ParentId;
                    data.Listorder = item.Listorder;
                    data.Rank = rank + 1;
                    if (node.Count(w => w.ParentId == item.Id) > 0)
                        data.children = TreeChildren(node, item.Id, rank + 1, Type);

                    newnode.Add(data);
                }
            }

            return newnode;

        }
        public List<T_TreeSysListModel> TreeCombox(int SysId)
        {
            List<T_TreeSysListModel> result = new List<T_TreeSysListModel>();
            T_TreeSysListModel data = new T_TreeSysListModel()
            { 
                id = "",
                text = "",
                children = null,
            };
            result.Add(data); 
            List<T_TreeSysListModel> list = new List<T_TreeSysListModel>();
            list = Tree(SysId); 
            foreach (var item in list)
            {
                data = new T_TreeSysListModel();
                data.id = item.id;
                data.text = item.Name;
                data.children = item.children;  
                result.Add(data);
            } 
            return result;
        }
        public List<T_ParentSysListModel> ParentList(int Id)
        {
            List<T_ParentSysListModel> result = new List<T_ParentSysListModel>();
            T_ParentSysListModel data = new T_ParentSysListModel();

            List<T_SysListModel> list = new List<T_SysListModel>();
            var SysId = dal.Filter(o => o.Id == Id).FirstOrDefault().SysId;
            list = dal.Filter(o => o.SysId == SysId).OrderBy(b => b.Listorder).DTOList().ToList(); 

            foreach (var item in list.Where(w=>w.Id==Id))
            {
                data = new T_ParentSysListModel();
                data.Id = item.Id;
                data.Name = item.Name;
                data.ParentId = item.ParentId;
                  if (item.ParentId!=null && list.Count(w => w.Id == item.ParentId) > 0)
                     data.Parent = ParentNode(list, item.ParentId);
                result.Add(data);
            }
            return result;
        }

        public List<T_ParentSysListModel> ParentNode(List<T_SysListModel> node, int? parentId)
        {
            List<T_ParentSysListModel> newnode = new List<T_ParentSysListModel>();

            var parent = node.Where(w => w.Id == parentId).OrderBy(b => b.Listorder).ToList();
            if (parent.Count() > 0)
            {
                foreach (var item in parent)
                {
                    T_ParentSysListModel data = new T_ParentSysListModel();
                    data.Id = item.Id;
                    data.Name = item.Name;
                    data.ParentId = item.ParentId;
                    if (item.ParentId!=null && node.Count(w => w.Id == item.ParentId) > 0)
                        data.Parent = ParentNode(node, item.ParentId);

                    newnode.Add(data);
                }
            }

            return newnode;

        }

        /// <summary>
        /// 获得该节点下所有子节点
        /// </summary>
        /// <param name="SysId">模块ID</param>
        ///  <param name="Id"></param>
        /// <returns></returns>
        public List<int> GetChildren(int SysId,int Id)
        {
            
            List<T_SysListModel> list = new List<T_SysListModel>(); 
            List<int> node=new List<int>();
            node.Add(Id); 
            list = dal.Filter(o => o.SysId == SysId).DTOList().ToList();
             
            var parent = list.Where(w => w.ParentId == Id).OrderBy(b => b.Listorder).ToList();
            foreach (var item in parent)
            {
                node.Add(item.Id);
                if (list.Count(w => w.ParentId == item.Id) > 0)
                    GetChildren(list, item.Id, node);  
            } 
                return node; 
        }
        public void GetChildren(List<T_SysListModel> node, int parentId,List<int> resultList)
        { 
            var parent = node.Where(w => w.ParentId == parentId).OrderBy(b => b.Listorder).ToList();
            if (parent.Count() > 0)
            {
                foreach (var item in parent)
                {
                    resultList.Add(item.Id);
                    if (node.Count(w => w.ParentId == item.Id) > 0)
                       GetChildren(node, item.Id, resultList);
                     
                }
            } 
        }




        public DataGrid<T_SysListModel> Search(T_SysListModel model, Dictionary<string, string> Orders = null, int PageSize = 15, int PageIndex = 100)
        {
            throw new NotImplementedException();
        } 
         
    }
 
}
