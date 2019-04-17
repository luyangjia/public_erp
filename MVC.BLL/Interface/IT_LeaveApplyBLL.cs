using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.Models;
using MVC.DAL;
using System.Linq.Expressions;
namespace MVC.BLL
{
    public interface IT_LeaveApplyBLL : BaseInterface<T_LeaveApplyModel>
    {
        /// <summary>
        /// 根据情况删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int DeleteApply(T_LeaveApplyModel model);
        /// <summary>
        /// 撤销申请
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int UndoApply(T_LeaveApplyModel model);
        /// <summary>
        /// 变更
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int ChangeApply(T_LeaveApplyModel model);
        /// <summary>
        ////审批
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int ApprovalData(T_LeaveApplyModel model);
        /// <summary>
        /// 获得某个用户，某种请假类型，剩余的天数，和总共的天数
        /// </summary>
        /// <param name="UserId">用户</param>
        /// <param name="LeaveId"></param>
        /// <param name="statusids">哪些状态的假期要计算</param>
        /// <param name="Total">今年总的天数，-1表示不设置</param>
        /// <returns>返回还有多少天可以用，-1表示不限制</returns>
        decimal GetDays(int UserId, int LeaveId, List<int> statusids, out decimal Total);
    }
}
