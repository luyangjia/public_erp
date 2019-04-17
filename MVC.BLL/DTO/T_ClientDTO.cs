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
    public static class T_ClientDTO
    {
        public static T_ClientModel DTO(this T_Client node)
        {
            if (node == null)
                return null;
            var model = new T_ClientModel()
            {
                Id = node.Id,
                //LoginId = node.LoginId,
                //Password = Encrypt.Decrypto(node.Password),
                Name = node.Name, 
                Company = node.Company,
                RegDate = node.RegDate,
                Blk = node.Blk,
                BuildingName = node.BuildingName,
                Nric = node.Nric,
                Email = node.Email,  
                Fax = node.Fax,
                Race = node.Race, 
                Mobile = node.Mobile, 
                Phone = node.Phone,
                Sectors=node.Sectors,
                PostalCode = node.PostalCode,
                StreetName = node.StreetName,
                Unit = node.Unit,
                Enable = node.Enable,
                
            };
            return model;
        }

        public static IList<T_ClientModel> DTOList(this IQueryable<T_Client> nodes)
        {
            if (nodes == null)
                return null;
            var result = nodes.ToList().Select(node => node.DTO()).ToList();
            return result;
        }

        public static T_Client ToModel(this  T_ClientModel node)
        {
            return new T_Client()
            {
                Id = node.Id,
                //LoginId = node.LoginId,
                //Password = Encrypt.Encrypto(node.Password),
                Name = node.Name,
                Company = node.Company,
               // RegDate = node.RegDate,
                Blk = node.Blk,
                BuildingName = node.BuildingName,
                Nric = node.Nric,
                Email = node.Email,
                Fax = node.Fax,
                Race = node.Race,
                Mobile = node.Mobile,
                Phone = node.Phone, 
                PostalCode = node.PostalCode,
                StreetName = node.StreetName,
                Unit = node.Unit,
                Enable = node.Enable,
                Sectors = node.Sectors,
            };
        }
    }
}

