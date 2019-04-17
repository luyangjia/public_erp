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
    public static class T_LeaveApplyDTO
    {
        public static T_LeaveApplyModel DTO(this T_LeaveApply node)
        {
            if (node == null)
                return null;
            var model = new T_LeaveApplyModel()
            {
                Id = node.Id,
                UserId = node.UserId,
                UserName=node.UserName, 
                FromDate = node.FromDate,
                FromType = node.FromType,
                EndDate = node.EndDate,
                EndType = node.EndType,
                Days = node.Days,
                CreateDate = node.CreateDate,
                CreateUser = node.CreateUser,
                CreateUserId = node.CreateUserId,
                Reaon = node.Reaon,
                SetingId = node.SetingId,
                SetingName = node.SetingName,
                Status = node.Status,
                AppyId = node.AppyId,
                ApprovalId = node.ApprovalId,
                ApprovalName = node.ApprovalName,
                ApprovalReaon = node.ApprovalReaon,
                PayrollNo = node.PayrollNo,
                Undo = node.Undo, 
                IsLock=node.IsLock,
            };
            return model;
        }

        public static IList<T_LeaveApplyModel> DTOList(this IQueryable<T_LeaveApply> nodes)
        {
            if (nodes == null)
                return null;
            var result = nodes.ToList().Select(node => node.DTO()).ToList();
            return result;
        }
        /// <summary>
        /// 会全部增加修改
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static T_LeaveApply ToModel(this T_LeaveApplyModel node)
        {
            return new T_LeaveApply()
            {
                Id = node.Id,
                UserId = node.UserId,
                UserName = node.UserName, 
                FromDate = node.FromDate,
                FromType = node.FromType,
                EndDate = node.EndDate,
                EndType = node.EndType,
                Days = node.Days,
                CreateDate = node.CreateDate == null ? DateTime.Now : node.CreateDate,
                CreateUser = node.CreateUser,
                CreateUserId = node.CreateUserId,
                Reaon = node.Reaon,
                SetingId = node.SetingId,
                SetingName = node.SetingName,
                Status = node.Status,
                AppyId = node.AppyId,
                ApprovalId = node.ApprovalId,
                ApprovalName = node.ApprovalName,
                ApprovalReaon = node.ApprovalReaon,
                //PayrollNo = node.PayrollNo,
                Undo = node.Undo,
                IsLock = node.IsLock,
            };
        }
    }
}
