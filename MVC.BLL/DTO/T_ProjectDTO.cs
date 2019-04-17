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
    public static class T_ProjectDTO
    {
        public static T_ProjectModel DTO(this T_Project node)
        {
            if (node == null)
                return null;
            var model = new T_ProjectModel()
            {
                Id = node.Id,
                ProjectName = node.ProjectName,
                BeginDate = node.BeginDate,
                EndDate = node.EndDate,
                CompanyId = node.CompanyId,
                CreateDate = node.CreateDate,
                CreateUserId = node.CreateUserId,
                CreateUserName = node.CreateUserName,
                ProjectNo = node.ProjectNo,
                ProjectType = node.ProjectType,
                Property = node.Property,
                Remark = node.Remark,
                Status = node.Status,
                Towi = node.Towi,
                VisitDate = node.VisitDate,
                Blk = node.Blk,
                BuildingName = node.BuildingName,
                PostalCode = node.PostalCode,
                StreetName = node.StreetName,
                Unit = node.Unit,
                ClientId = node.ClientId,
                ClientName = node.Client != null ? node.Client.Name : null,
                Client = node.Client.DTO(),
                CompanyName = node.Company != null ? node.Company.Company : null,
                Company = node.Company.DTO(),
               Leader = node.ProjectUsers.Count() > 0 ? (node.ProjectUsers.FirstOrDefault(f => f.Role == "Manager") != null ? (node.ProjectUsers.FirstOrDefault(f => f.Role == "Manager").UserName) : null) : null,
               ProjectUsers = node.ProjectUsers.Count() > 0 ? node.ProjectUsers.ToList().Select(s => s.DTO()).ToList() : null,
               ProjectPlans = node.ProjectPlans.Count() > 0 ? node.ProjectPlans.ToList().Select(s => s.DTO()).ToList() : null,
               
                 
            };
            return model;
        }

        public static IList<T_ProjectModel> DTOList(this IQueryable<T_Project> nodes)
        {
            if (nodes == null)
                return null;
            var result = nodes.ToList().Select(node => node.DTO()).ToList();
            return result;
        }




        public static T_Project ToModel(this  T_ProjectModel node)
        {
            return new T_Project()
            {
                Id = node.Id,
                ProjectName = node.ProjectName,
                BeginDate = node.BeginDate,
                EndDate = node.EndDate,
                CompanyId = node.CompanyId,
                ClientId = node.ClientId,
                CreateDate = DateTime.Now,
                CreateUserId = node.CreateUserId, //用户ID
                CreateUserName = node.CreateUserName, //用户名 
                ProjectType = node.ProjectType,
                Property = node.Property,
                Remark = node.Remark,
                Towi = node.Towi,
                VisitDate = node.VisitDate,
                Blk = node.Blk,
                BuildingName = node.BuildingName,
                PostalCode = node.PostalCode,
                StreetName = node.StreetName,
                Unit = node.Unit,
            };
        }

    }
}

