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
    public static class T_LeaveSettingDTO
    {
        public static T_LeaveSettingModel DTO(this T_LeaveSetting node)
        {
            if (node == null)
                return null;
            var model = new T_LeaveSettingModel()
            {
                Id = node.Id,
                Name = node.Name,
                Days = node.Days,
                IsCarryOver = node.IsCarryOver,
                IsLimit = node.IsLimit,
                IsUnpaid = node.IsUnpaid,
                Months = node.Months,
                 Enable=node.Enable,
                 
            };
            return model;
        }

        public static IList<T_LeaveSettingModel> DTOList(this IQueryable<T_LeaveSetting> nodes)
        {
            if (nodes == null)
                return null;
            var result = nodes.ToList().Select(node => node.DTO()).ToList();
            return result;
        }

        public static T_LeaveSetting ToModel(this T_LeaveSettingModel node)
        {
            return new T_LeaveSetting()
            {
                Id = node.Id,
                Name=node.Name,
                Days = node.Days,
                IsCarryOver = node.IsCarryOver,
                IsLimit = node.IsLimit,
                IsUnpaid = node.IsUnpaid,
                Months = node.Months,
                Enable = node.Enable,
              
            };
        }
    }
}
