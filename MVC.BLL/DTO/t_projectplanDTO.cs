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
    public static class T_ProjectPlanDTO
    {
        public static T_ProjectPlanModel DTO(this T_ProjectPlan node)
        {
            if (node == null)
                return null;
            var model = new T_ProjectPlanModel()
            {
                Id = node.Id,
                ProjectId = node.ProjectId,
                UserId = node.UserId,
                UserName = node.UserName,
                BeginTime = node.BeginTime,
                EndTime = node.EndTime,
                Description = node.Description,
                Status = node.Status,

            };
            return model;
        }

        public static IList<T_ProjectPlanModel> DTOList(this IQueryable<T_ProjectPlan> nodes)
        {
            if (nodes == null)
                return null;
            var result = nodes.ToList().Select(node => node.DTO()).ToList();
            return result;
        }




        public static T_ProjectPlan ToModel(this  T_ProjectPlanModel node)
        {
            return new T_ProjectPlan()
            {
                Id = node.Id,
                ProjectId = node.ProjectId,
                UserId = node.UserId,
                UserName = node.UserName,
                BeginTime = node.BeginTime,
                EndTime = node.EndTime,
                Description = node.Description,
                Status = node.Status,
               
            };
        }

    }
}

