using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.DAL;
using MVC.Models;
using MVC.Helper;
using System.Linq.Expressions;
namespace MVC.BLL
{
    public static class T_AgreeDTO
    {
        public static T_AgreeModel DTO(this T_Agree node)
        {
            if (node == null)
                return null;
            var model = new T_AgreeModel()
            {
                Id = node.Id,
                AgreeDate = node.AgreeDate,
                AgreeName = node.AgreeName,
                AgreeNo = node.AgreeNo,
                AgreeUserId = node.AgreeUserId,
                AgreeUserName = node.AgreeUserName,
                ApprovalUserId = node.ApprovalUserId,
                ApprovalUserIds = node.ApprovalUserIds,
                ApprovalUserName = node.ApprovalUserName,
                ApprovalUserNames = node.ApprovalUserNames,
                CostTotal = node.CostTotal,
                Discount = node.Discount,
                GrandTotal = node.GrandTotal,
                Gst = node.Gst,
                 GstTotal=node.GstTotal,
                PriceTotal = node.PriceTotal,
                ProjectId = node.ProjectId,
                Status = node.Status,
                Remark = node.Remark,
                AgreeIndex = node.AgreeIndex,
                Project = node.Project!=null? node.Project.DTO() : null,
                AgreeList = node.AgreeList.Count() > 0 ? node.AgreeList.OrderBy(b=>b.Category).Select(s => s.DTO()).ToList() : null, 

            };
            return model;
        }

        public static IList<T_AgreeModel> DTOList(this IQueryable<T_Agree> nodes)
        {
            if (nodes == null)
                return null;
            var result = nodes.ToList().Select(node => node.DTO()).ToList();
            return result;
        }

        public static T_Agree ToModel(this  T_AgreeModel node)
        {
            return new T_Agree()
            {
                Id = node.Id,
                AgreeDate = DateTime.Now,
                AgreeName = node.AgreeName,
                AgreeNo = node.AgreeNo,
                AgreeUserId = node.AgreeUserId,
                AgreeUserName = node.AgreeUserName,
                ApprovalUserId = node.ApprovalUserId,
                ApprovalUserIds = node.ApprovalUserIds,
                ApprovalUserName = node.ApprovalUserName,
                ApprovalUserNames = node.ApprovalUserNames,
                CostTotal = node.CostTotal,
                Discount = node.Discount,
                GrandTotal = node.GrandTotal,
                Gst = node.Gst,
                PriceTotal = node.PriceTotal,
                ProjectId = node.ProjectId,
                Status = node.Status,
                Remark = node.Remark,
               AgreeIndex=node.AgreeIndex,
            };
        }
    }
}

