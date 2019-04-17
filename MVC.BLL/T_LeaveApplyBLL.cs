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
    public partial class T_LeaveApplyBLL : BaseBLL<T_LeaveApply>, IT_LeaveApplyBLL
    {
        /// <summary>
        /// 实现这个对象，把类型传给基类
        /// </summary>
        /// <returns></returns>
        public override BaseDAL<T_LeaveApply> GetDAL()
        {
            return new T_LeaveApplyDAL();
        }
        public int AddData(T_LeaveApplyModel model)
        {

            return this.Add(model.ToModel());
        }
         
        public int EditData(T_LeaveApplyModel model)
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
            T_LeaveApply newdata = (T_LeaveApply)Helper.Method.CopyModel(model, data);
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
        public int DeleteData(T_LeaveApplyModel model)
        {
            return this.Delete(model.Id);
        }
        /// <summary>
        /// 审批
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int ApprovalData(T_LeaveApplyModel model)
        {
            int i = 0;
            T_LeaveApply data = this.GetById(model.Id);
            if (data != null && data.IsLock == model.IsLock)
            {
                if(data.Status==3)
                { 
                    var oldstatus = 10;
                    //变更申请 
                    //如果同意
                    if (model.Status == 2)
                    {
                        //拒绝 ,变回1
                        oldstatus = 1; 
                    }
                    
                        //获得4的数据
                        T_LeaveApply olddata = this.GetById((int)data.AppyId);
                        olddata.Status = oldstatus;
                        this.Edit(olddata); 
                } 
                data.Status = model.Status; 
                data.ApprovalId = model.ApprovalId;
                data.ApprovalName = model.ApprovalName;
                data.ApprovalReaon = model.ApprovalReaon;
                i = this.Edit(data);
            }

            return i;
        }
        public int UndoApply(T_LeaveApplyModel model)
        {
            int i = 0;
            T_LeaveApply data = this.GetById(model.Id);
            if (data != null && data.IsLock==model.IsLock && model.StatusList.Contains(data.Status))
            {
                 if(data.Status==1)
                 {
                     data.Status=5;
                 } 
                i=this.Edit(data);
            }
                 
            return i;
        }
        public int DeleteApply(T_LeaveApplyModel model)
        {
            int i = 0;
           // Expression<Func<T_LeaveApply, bool>> where = w => w.Id == model.Id && w.IsLock == model.IsLock && model.StatusList.Contains(w.Status); 
            var data = dal.Filter(o => o.Id == model.Id && o.IsLock == model.IsLock && model.StatusList.Any(a => o.Status == a)).FirstOrDefault();
            if (data != null)
                i = this.Delete(data.Id);
            return i;
        }
        /// <summary>
        /// 变更申请过的假期
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int ChangeApply(T_LeaveApplyModel model)
        {
            T_LeaveApply newdata=new T_LeaveApply();
            int i = 0;
            // Expression<Func<T_LeaveApply, bool>> where = w => w.Id == model.Id && w.IsLock == model.IsLock && model.StatusList.Contains(w.Status); 
            //变更前先检查还剩下几天
            List<int> statusList=new List<int>(){1, 4, 5};
            decimal totalday=0;
            decimal days=GetDays(model.UserId,model.SetingId,statusList,out totalday);
            //获得旧的数据
             
            var data = dal.Filter(o => o.Id == model.Id && o.IsLock == model.IsLock && model.StatusList.Any(a => o.Status == a)).FirstOrDefault();
            if (data != null)
            {
                if((days+data.Days-model.Days)>0)
                {
                      newdata.UserId = data.UserId;
                      newdata.UserName = data.UserName;
                      newdata.FromDate = model.FromDate;
                      newdata.FromType = model.FromType;
                      newdata.EndDate = model.EndDate;
                      newdata.EndType = model.EndType;
                      newdata.Days = model.Days;
                      newdata.CreateDate = DateTime.Now;
                      newdata.CreateUser = model.CreateUser;
                      newdata.CreateUserId = model.CreateUserId;
                      newdata.AppyId = model.Id;
                      newdata.SetingId = model.SetingId;
                      newdata.SetingName = model.SetingName;
                      newdata.Status = 3;
                      newdata.Reaon = model.Reaon;
                      this.Add(newdata);
                      data.Status = 4;
                      this.Edit(data);
                      i = 1;
                }
                else
                {
                    i = -1;
                    //不够请假天数
                } 
            }
                
            return i;
        }
        /// <summary>
        /// 获得某个用户，某种请假类型，剩余的天数，和总共的天数
        /// </summary>
        /// <param name="UserId">用户</param>
        /// <param name="LeaveId"></param>
        /// <param name="statusids">哪些状态的假期要计算</param>
        /// <param name="Total">今年总的天数，-1表示不设置</param>
        /// <returns>返回还有多少天可以用，-1表示不限制</returns>
        public decimal GetDays(int UserId, int LeaveId, List<int> statusids, out decimal Total)
        {
            Total=0;
            decimal days0 = 0; //当年的假期
            decimal days1 = 0; //用掉的假期
            decimal days2 = 0; //去年留下来的假期
            decimal days = 0; //最后剩下的，如果是-1表示不受限
            int year = DateTime.Now.Year;
            T_UserBLL t_UserBLL = new T_UserBLL();
            T_LeaveCarryOverBLL  t_LeaveCarryOverBLL = new T_LeaveCarryOverBLL();
            T_LeaveSettingBLL t_LeaveSettingBLL = new T_LeaveSettingBLL();
            var userdata = t_UserBLL.Filter(c => c.Id == UserId).FirstOrDefault();
            DateTime workdate = DateTime.Parse(userdata.Dateoined.ToString());
            //获得今年已经用掉的天数，包括在申请的 变更前和变更后审核的多算，防止漏洞。 
            //先看下假期受限制没有
            var data = t_LeaveSettingBLL.GetById(LeaveId);
            if (data.IsLimit == true)
            {  
                var useLeave = dal.Filter(c => c.UserId == UserId && c.SetingId == LeaveId && c.FromDate.Year == year && statusids.Any(a => c.Status == a)).ToList();
                //看下今年有哪些是去年留下来的假期
                var carryOver = t_LeaveCarryOverBLL.Filter(c => c.UserId == UserId && c.SetingId == LeaveId && c.Year == year).FirstOrDefault();
                  
                days1 = useLeave.Count() > 0 ? useLeave.Sum(s => s.Days) : 0;
                days2 = carryOver == null ? 0 : carryOver.Days;
                days0 = data.Days;
                if ((data.Months > 0 && workdate.AddMonths(data.Months) <= DateTime.Now) || data.Months <= 0)
                {
                    //如果需要大于几个月后才有的假期，判断 
                    days = (days0 + days2) - days1;
                    Total=days0 + days2;
                }
                else
                {
                    days = 0;
                }
            }
            else
            {
                days = -1;
                Total = -1;
            } 
            return days;

        }
        /// <summary>
        /// 复杂查询
        /// </summary>
        /// <param name="model">查询对象</param>
        /// <param name="Orders">排序字典key:排序的字段,value:asc升序/desc降序</param> 
        /// <param name="PageSize">每页行数，默认15</param>
        /// <param name="PageIndex">当前页码，默认100</param> 
        /// <returns></returns>
        public DataGrid<T_LeaveApplyModel> Search(T_LeaveApplyModel model, Dictionary<string, string> Orders = null, int PageSize = 15, int PageIndex = 100)
        { 
            Expression<Func<T_LeaveApply, bool>> where = null; //最终查询条件
            var lambdaList = new List<Expression<Func<T_LeaveApply, bool>>>(); //lambda查询条件集合
            int total = 0; //总行数  
            if (model.UserId!=0 ) //这里要注意尽量用！= 0表示全部，-1表示有问题不让他查
                lambdaList.Add(c => c.UserId==model.UserId);
            if (model.UserName != null)
                lambdaList.Add(c => c.UserName.Contains(model.UserName));
            if (model.SetingId != null && model.SetingId > 0)
                lambdaList.Add(c => c.SetingId == model.SetingId);
            if(model.StatusList!=null && model.StatusList.Count()>0)
                lambdaList.Add(c => model.StatusList.Any(a=>c.Status==a));
            if (model.FromDate != null && model.FromDate.Year>1900 )
                lambdaList.Add(c => c.FromDate>=model.FromDate);
            if (model.EndDate != null && model.EndDate.Year > 1900)
                lambdaList.Add(c => c.FromDate <= model.EndDate);
            //将集合表达式树转换成Expression表达式树
            MyVisitor<T_LeaveApply, T_LeaveApply> visitor = new MyVisitor<T_LeaveApply, T_LeaveApply>();
            where = visitor.Modify(lambdaList);
            var list = dal.Search(out total, where, Orders, PageSize, PageIndex).DTOList().ToList();
            var result = new DataGrid<T_LeaveApplyModel>()
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
        public List<T_LeaveApplyModel> Filter(Expression<Func<T_LeaveApplyModel, bool>> LambdaWhere = null,  Dictionary<string, string> Orders = null)
        { 
            List<T_LeaveApplyModel> result = new List<T_LeaveApplyModel>(); 
            MyVisitor<T_LeaveApplyModel, T_LeaveApply> visitor = new MyVisitor<T_LeaveApplyModel, T_LeaveApply>();
            var where = visitor.Modify(LambdaWhere);
            result = dal.Filter(where, Orders).DTOList().ToList(); 
            return result;
        }


 
    }
     
}
