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
    public static class T_FixedAssetsDTO
    {
        public static T_FixedAssetsModel DTO(this T_FixedAssets node)
        {
            if (node == null)
                return null;
            var model = new T_FixedAssetsModel()
            {
                Id = node.Id,
                Address = node.Address,
                AssetsNo = node.AssetsNo,
                BuyPrice = node.BuyPrice,
                Category = node.Category,
                CompanyId = node.CompanyId,
                CreateDate = node.CreateDate,
                CreateUserId = node.CreateUserId,
                CreateUserName = node.CreateUserName,
                DateProduction = node.DateProduction,
                DatePurchase = node.DatePurchase,
                GroupId = node.GroupId,
                Manufacturers = node.Manufacturers,
                Name = node.Name,
                NowPrice = node.NowPrice,
                Status = node.Status,
                TypeSpecification = node.TypeSpecification,
                UseUserId = node.UseUserId,
                UseUserName = node.UseUserName,
                ValidYear = node.ValidYear,
            };
            return model;
        }

        public static IList<T_FixedAssetsModel> DTOList(this IQueryable<T_FixedAssets> nodes)
        {
            if (nodes == null)
                return null;
            var result = nodes.ToList().Select(node => node.DTO()).ToList();
            return result;
        }

        public static T_FixedAssets ToModel(this T_FixedAssetsModel node)
        {
            return new T_FixedAssets()
            {
                Id = node.Id,
                Address = node.Address,
                AssetsNo = node.AssetsNo,
                BuyPrice = node.BuyPrice,
                Category = node.Category,
                CompanyId = node.CompanyId,
                CreateDate = node.CreateDate,
                CreateUserId = node.CreateUserId,
                CreateUserName = node.CreateUserName,
                DateProduction = node.DateProduction,
                DatePurchase = node.DatePurchase,
                GroupId = node.GroupId,
                Manufacturers = node.Manufacturers,
                Name = node.Name,
                NowPrice = node.NowPrice,
                Status = node.Status,
                TypeSpecification = node.TypeSpecification,
                UseUserId = node.UseUserId,
                UseUserName = node.UseUserName,
                ValidYear = node.ValidYear,
            };
        }
    }
}
