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
    public static class T_AgreeListDTO
    {
        public static T_AgreeListModel DTO(this T_AgreeList node)
        {
            if (node == null)
                return null;
            var model = new T_AgreeListModel()
            {
                Id = node.Id,
                AgreeId = node.AgreeId,
                CategoryId = node.CategoryId,
                Category = node.Category, 
                Cost = node.Cost,
                CostId = node.CostId,
                Description = node.Description,
                Price = node.Price,
                ProjectId = node.ProjectId,
                Qty = node.Qty,
                Uom = node.Uom,
                Profit = node.Profit,
                 
            };
            if (model.Price > 0)
            {
                model.CostMarkup =Math.Round((decimal)((model.Price - model.Cost) / model.Price) * 100, 2);
            }
            else
            {
                model.CostMarkup = 0;
            }
            model.TotalPrice = Math.Round((decimal)(model.Qty*model.Price) , 2);
            model.TotalCost = Math.Round((decimal)(model.Qty * model.Cost), 2);
            return model;
        }

        public static IList<T_AgreeListModel> DTOList(this IQueryable<T_AgreeList> nodes)
        {
            if (nodes == null)
                return null;
            var result = nodes.ToList().Select(node => node.DTO()).ToList();
            return result;
        }

        public static T_AgreeList ToModel(this  T_AgreeListModel node)
        {
            return new T_AgreeList()
            {
                Id = node.Id,
                AgreeId = node.AgreeId,
                CategoryId = node.CategoryId,
                Category = node.Category, 
                Cost = node.Cost,
                CostId = node.CostId,
                Description = node.Description,
                Price = node.Price,
                ProjectId = node.ProjectId,
                Qty = node.Qty,
                Uom = node.Uom,
                Profit=node.Profit,
            };
        }
    }
}

