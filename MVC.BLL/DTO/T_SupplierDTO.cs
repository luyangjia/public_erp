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
    public static class T_SupplierDTO
    {
        public static T_SupplierModel DTO(this T_Supplier node)
        {
            if (node == null)
                return null;
            var model = new T_SupplierModel()
            {
                Id = node.Id,
                COGS = node.COGS,
                COGS2 = node.COGS2,
                CategoryId = node.CategoryId,
                Company = node.Company,
                Rebates = node.Rebates,
                Cycle = node.Cycle,
                Contact = node.Contact,
                Hp = node.Hp,
                Tel = node.Tel,
                Tel2 = node.Tel2,
                Fax = node.Fax,
                Fax2 = node.Fax2,
                Email = node.Email,
                Remark = node.Remark,
                BankName = node.BankName,
                BankCode = node.BankCode,
                BankNumber = node.BankNumber,
                Collect = node.Collect,
                Category=node.Category!=null ? node.Category.Name:null,
                Parent_CategoryId = node.Category != null ? (node.Category.ParSysList != null ? node.Category.ParSysList.Id : 0) : 0,
                Parent_Category = node.Category != null ? (node.Category.ParSysList != null ? node.Category.ParSysList.Name : null) : null,

            };

             
            



            return model;
        }

        public static IList<T_SupplierModel> DTOList(this IQueryable<T_Supplier> nodes)
        {
            if (nodes == null)
                return null;
            var result = nodes.ToList().Select(node => node.DTO()).ToList();
            return result;
        }

        public static T_Supplier ToModel(this T_SupplierModel node)
        {
            return new T_Supplier()
            {
                Id = node.Id,
                COGS = node.COGS,
                COGS2 = node.COGS2,
                CategoryId = node.CategoryId,
                Company = node.Company,
                Rebates = node.Rebates,
                Cycle = node.Cycle,
                Contact = node.Contact,
                Hp = node.Hp,
                Tel = node.Tel,
                Tel2 = node.Tel2,
                Fax = node.Fax,
                Fax2 = node.Fax2,
                Email = node.Email,
                Remark = node.Remark,
                BankName = node.BankName,
                BankCode = node.BankCode,
                BankNumber = node.BankNumber,
                Collect = node.Collect, 
            };
        }
    }
}
