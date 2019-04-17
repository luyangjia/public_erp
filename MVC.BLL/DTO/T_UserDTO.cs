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
    public static class T_UserDTO
    {
        public static T_UserModel DTO(this T_User node)
        {
            if (node == null)
                return null;
            var model = new T_UserModel()
            {
                Id = node.Id,
                LoginId = node.LoginId,
                Password = Encrypt.Decrypto(node.Password),
                StaffName = node.StaffName,
                Alias = node.Alias,
                Sex = node.Sex,
                RoleId = node.RoleId,
                BirthDate = node.BirthDate,
                Blk = node.Blk,
                BuildingName = node.BuildingName,
                CompanyId = node.CompanyId,
                Dateoined = node.Dateoined,
                DateResignation=node.DateResignation,
                Email = node.Email,
                Fax = node.Fax,
                GroupId = node.GroupId,
                Marital = node.Marital,
                Mobile = node.Mobile,
                Nationality = node.Nationality,
                Phone = node.Phone,
                Position = node.Position,
                PostalCode = node.PostalCode,
                StreetName = node.StreetName,
                Unit = node.Unit,
                Enable = node.Enable,
                AcctCode = node.AcctCode,
                CompanyName = node.Company != null ? node.Company.Company : null,
                RoleName = node.Role != null ? node.Role.Name : null,
                AppointmentAllowance = node.AppointmentAllowance,
                 BankName = node.BankName,
                BankNumber = node.BankNumber,
                Commission = node.Commission,
                EmployeeCpf = node.EmployeeCpf,
                EmployerCpf = node.EmployerCpf,
                FixedAllowance = node.FixedAllowance,
                Salary = node.Salary,
            };
            return model;
        }

        public static IList<T_UserModel> DTOList(this IQueryable<T_User> nodes)
        {
            if (nodes == null)
                return null;
            var result = nodes.ToList().Select(node => node.DTO()).ToList();
            return result;
        }

        public static T_User ToModel(this  T_UserModel node)
        {
            return new T_User()
            {
                Id = node.Id,
                LoginId = node.LoginId,
              //  Password = Encrypt.Encrypto(node.Password),
                Password = node.Password,
                StaffName = node.StaffName,
                Alias = node.Alias,
                Sex = node.Sex,
                RoleId = node.RoleId,
                Enable = node.Enable,
                BirthDate = node.BirthDate,
                Blk = node.Blk,
                BuildingName = node.BuildingName,
                CompanyId = node.CompanyId,
                Dateoined = node.Dateoined,
                DateResignation = node.DateResignation,
                Email = node.Email,
                Fax = node.Fax,
                GroupId = node.GroupId,
                Marital = node.Marital,
                Mobile = node.Mobile,
                Nationality = node.Nationality,
                Phone = node.Phone,
                Position = node.Position,
                PostalCode = node.PostalCode,
                StreetName = node.StreetName,
                AcctCode = node.AcctCode,
                Unit = node.Unit,

            };
        }
    }
}

