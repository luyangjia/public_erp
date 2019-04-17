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
   
    public static class T_CompanyDTO
    {
        public static T_CompanyModel DTO(this T_Company node)
        {
            if (node == null)
                return null;
            var model = new T_CompanyModel()
            {
                Id = node.Id,
                Company = node.Company,
                Alias = node.Alias,
                Phone = node.Phone,
                Address = node.Address,
                AgreementNo = node.AgreementNo,
                Email = node.Email,
                Fax = node.Fax,
                GST = node.GST,
                GSTReg = node.GSTReg,
                License = node.License,
                Logo = node.Logo,
                ReceiptNo = node.ReceiptNo,
                Registration = node.Registration,
                Departments = node.Departments.Count() > 0 ? node.Departments.ToList().Select(s => s.DTO()).ToList() : null,
            
            }; 
            return model;
        }

        public static IList<T_CompanyModel> DTOList(this IQueryable<T_Company> nodes)
        {
            if (nodes == null)
                return null;
            var result = nodes.ToList().Select(node => node.DTO()).ToList();
            return result;
        }
      
        public static T_Company ToModel(this  T_CompanyModel node)
        {
            return new T_Company()
            {
                Id = node.Id,
                Company = node.Company,
                Alias = node.Alias,
                Phone = node.Phone,
                Address = node.Address,
                AgreementNo = node.AgreementNo,
                Email = node.Email,
                Fax = node.Fax,
                GST = node.GST,
                GSTReg = node.GSTReg,
                License = node.License,
                Logo = node.Logo,
                ReceiptNo = node.ReceiptNo,
                Registration = node.Registration,

            };
        }
    }
}
