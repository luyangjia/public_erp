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
    public partial class T_AgreeBLL : BaseBLL<T_Agree>, IT_AgreeBLL
    {
        /// <summary>
        /// 实现这个对象，把类型传给基类
        /// </summary>
        /// <returns></returns>
        public override BaseDAL<T_Agree> GetDAL()
        {
            return new T_AgreeDAL();
        }
        public int AddData(T_AgreeModel model)
        {
            T_Agree node = new T_Agree()
               { 
                AgreeDate = DateTime.Now,
                AgreeName = model.AgreeName,
                ProjectId = model.ProjectId,
                Status =0,
                 AgreeIndex=100,
                Remark = model.Remark, 
            };

            return this.Add(node);
        }

        public int EditData(T_AgreeModel model)
        {
            int i = 0;
            //先获取
            var node = this.GetById(model.Id);
           if(node!=null)
           {
               node.AgreeDate = DateTime.Now;
               node.AgreeName = model.AgreeName;
               node.Remark = model.Remark;
               i = this.Edit(node);
           }

           return i;
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
            T_Agree newdata = (T_Agree)Helper.Method.CopyModel(model, data);
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
        /// <summary>
        /// 根据对象中的主键Id删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int DeleteData(T_AgreeModel model)
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
        public DataGrid<T_AgreeModel> Search(T_AgreeModel model, Dictionary<string, string> Orders = null, int PageSize = 15, int PageIndex = 100)
        {
            Expression<Func<T_Agree, bool>> where = null; //最终查询条件
            var lambdaList = new List<Expression<Func<T_Agree, bool>>>(); //lambda查询条件集合
            int total = 0; //总行数  
            if (model.StatusList!=null && model.StatusList.Count() > 0)
                lambdaList.Add(c => model.StatusList.Any(a => c.Status == a));
            if (model.ProjectId != null && model.ProjectId > 0)
                lambdaList.Add(c => c.ProjectId == model.ProjectId);
            //将集合表达式树转换成Expression表达式树
            MyVisitor<T_Agree, T_Agree> visitor = new MyVisitor<T_Agree, T_Agree>();
            where = visitor.Modify(lambdaList);
            var list = dal.Search(out total, where, Orders, PageSize, PageIndex).DTOList().ToList();
            var result = new DataGrid<T_AgreeModel>()
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
        public List<T_AgreeModel> Filter(Expression<Func<T_AgreeModel, bool>> LambdaWhere = null, Dictionary<string, string> Orders = null)
        {
            List<T_AgreeModel> result = new List<T_AgreeModel>();
            MyVisitor<T_AgreeModel, T_Agree> visitor = new MyVisitor<T_AgreeModel, T_Agree>();
            var where = visitor.Modify(LambdaWhere);
            result = dal.Filter(where, Orders).DTOList().ToList();
            return result;
        }
        /// <summary>
        /// 签署协议,这方法后面需要修改成事务。
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AgreeProject(T_AgreeModel model)
        {
            int i = 0;
            int k = 0;
            //先获取
            var node = this.GetById(model.Id);
            if (node != null)
            {
                node.CostTotal = model.CostTotal;
                node.PriceTotal = model.PriceTotal;
                node.Discount = model.Discount;
                node.Gst = model.Gst;
                node.GstTotal = model.GstTotal;
                node.Status = model.Status;
                node.GrandTotal = model.GrandTotal;
                i = this.Edit(node);
            }
            //T_ProjectBLL project=new T_ProjectBLL();

            //var projectnode = project.GetById(model.ProjectId);
            //if (projectnode != null)
            //{
            //    projectnode.State =1;
            //    k = project.Edit(projectnode);
            //}

            return i;

        } 
        /// <summary>
        ///审批协议,这方法后面需要修改成事务。
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int ApporvalsProject(T_AgreeModel model)
        {
            int i = 0;
            int k = 0;
            //先获取
            var node = this.GetById(model.Id);
             
            if (model.Status == 1)
            {
                //先获得协议号，先看有没有获得过协议号
                // number = number + 55; // 字母A-Z编码在65-90
                int AgreementNo = 0; //合同号
                int index = 0; //项目中的第几个合同
                 T_CompanyBLL companybll = new T_CompanyBLL();
                 T_ProjectBLL projectbll = new T_ProjectBLL();
                
                var projectnode = projectbll.GetById(model.ProjectId);

                T_Agree maxagree = dal.Filter(o => o.ProjectId == model.ProjectId && o.Status == 1).OrderByDescending(b => b.AgreeIndex).FirstOrDefault();
                if(maxagree!=null)
                {
                    AgreementNo = maxagree.AgreeIndex > 0 ? int.Parse(maxagree.AgreeNo.Substring(0, maxagree.AgreeNo.Length - 1)) : int.Parse(maxagree.AgreeNo);
                    index = int.Parse(maxagree.AgreeIndex.ToString()) + 1;
                }
                else
                {
                   T_Company company=companybll.GetById((int)projectnode.CompanyId);
                   AgreementNo = (int)company.AgreementNo; 
                   company.AgreementNo = AgreementNo + 1;
                   k = companybll.Edit(company);
                }  
                if (projectnode != null)
                {
                    projectnode.Status = 1;
                    k = projectbll.Edit(projectnode);
                }

                if (node != null)
                {
                    node.Status = model.Status;
                    node.AgreeDate = DateTime.Now;
                    node.AgreeIndex = index;
                    node.AgreeNo = index == 0 ? AgreementNo.ToString() : AgreementNo.ToString()+Helper.Method.Chr(64 + index);
                    i = this.Edit(node);
                }

            }
            else
            {
                if (node != null)
                {
                    node.Status = model.Status;
                    node.AgreeDate = DateTime.Now;
                    i = this.Edit(node);
                }
            }

             

            return i;

        }
    }

}



