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
    public static class T_FixedAssetsUseDTO
    {
        public static T_FixedAssetsUseModel DTO(this T_FixedAssetsUse node)
        {
            if (node == null)
                return null;
            var model = new T_FixedAssetsUseModel()
            {
                Id = node.Id,
                Address = node.Address,
                AssetsId = node.AssetsId,
                CompanyId = node.CompanyId,
                CreateDate = node.CreateDate,
                CreateUserId = node.CreateUserId,
                CreateUserName = node.CreateUserName,
                FromDate = node.FromDate,
                EndDate = node.EndDate,
                GroupId = node.GroupId,
                Remark = node.Remark,
                Status = node.Status,
                UseUserId = node.UseUserId,
                UseUserName = node.UseUserName,
            };
            return model;
        }

        public static IList<T_FixedAssetsUseModel> DTOList(this IQueryable<T_FixedAssetsUse> nodes)
        {
            if (nodes == null)
                return null;
            var result = nodes.ToList().Select(node => node.DTO()).ToList();
            return result;
        }

        public static T_FixedAssetsUse ToModel(this T_FixedAssetsUseModel node)
        {
            return new T_FixedAssetsUse()
            {
                Id = node.Id,
                Address = node.Address,
                AssetsId = node.AssetsId,
                CompanyId = node.CompanyId,
                CreateDate = node.CreateDate,
                CreateUserId = node.CreateUserId,
                CreateUserName = node.CreateUserName,
                FromDate = node.FromDate,
                EndDate = node.EndDate,
                GroupId = node.GroupId,
                Remark = node.Remark,
                Status = node.Status,
                UseUserId = node.UseUserId,
                UseUserName = node.UseUserName,
            };
        }
    }
}
