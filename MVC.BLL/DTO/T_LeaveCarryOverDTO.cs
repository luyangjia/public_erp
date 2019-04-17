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
    public static class T_LeaveCarryOverDTO
    {
        public static T_LeaveCarryOverModel DTO(this T_LeaveCarryOver node)
        {
            if (node == null)
                return null;
            var model = new T_LeaveCarryOverModel()
            {
                Id = node.Id,
                UserId = node.UserId,
                Days = node.Days,
                SetingId = node.SetingId,
                SetingName = node.SetingName,
                Year = node.Year,
            };
            return model;
        }

        public static IList<T_LeaveCarryOverModel> DTOList(this IQueryable<T_LeaveCarryOver> nodes)
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
        public static T_LeaveCarryOver ToModel(this T_LeaveCarryOverModel node)
        {
            return new T_LeaveCarryOver()
            {
                Id = node.Id,
                UserId = node.UserId,
                Days = node.Days,
                SetingId = node.SetingId,
                SetingName = node.SetingName,
                Year = node.Year,
            };
        }
    }
}
