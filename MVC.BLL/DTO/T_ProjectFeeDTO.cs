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
    public static class T_ProjectFeeDTO
    {
        public static T_ProjectFeeModel DTO(this T_ProjectFee node)
        {
            if (node == null)
                return null;
            var model = new T_ProjectFeeModel()
            {
                Id = node.Id,
                ProjectId = node.ProjectId,
                Status = node.Status,
                PayDate = node.PayDate,
                PayNo = node.PayNo,
                PlanPayDate = node.PlanPayDate,
                PlayFee = node.PlayFee,
                Remark = node.Remark,

            };
            return model;
        }

        public static IList<T_ProjectFeeModel> DTOList(this IQueryable<T_ProjectFee> nodes)
        {
            if (nodes == null)
                return null;
            var result = nodes.ToList().Select(node => node.DTO()).ToList();
            return result;
        }




        public static T_ProjectFee ToModel(this  T_ProjectFeeModel node)
        {
            return new T_ProjectFee()
            {
                Id = node.Id,
                ProjectId = node.ProjectId,
                Status = node.Status,
                PayDate = node.PayDate,
                PayNo = node.PayNo,
                PlanPayDate = node.PlanPayDate,
                PlayFee = node.PlayFee,
                Remark = node.Remark,

            };
        }

    }
}

