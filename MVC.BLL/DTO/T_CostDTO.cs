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

    public static class T_CostDTO
    {
        public static T_CostModel DTO(this T_Cost node)
        {
            if (node == null)
                return null;
            var model = new T_CostModel()
            {
                Id = node.Id,
                CategoryId = node.CategoryId,
                SupplierId = node.SupplierId,
                Group = node.Group,
                Cost = node.Cost,
                Description = node.Description,
                Level = node.Level,
                Profit = node.Profit,
                Remark = node.Remark,
                Uom = node.Uom,
                Enable = node.Enable,
                Category=node.Category.DTO(),
                CategoryName=node.Category!=null ? node.Category.Name:null, 
                Supplier = node.Supplier.DTO(),
                Qty=1,
                Price = node.Profit,
                   
            };
            if(model.Profit>0)
            {
                model.CostMarkup = Math.Round(((model.Profit - model.Cost) / model.Profit) * 100, 2);
            }
            else
            {
                model.CostMarkup = 0;
            }

            if(model.Category!=null)
            {
                //默认只到6级 
                #region 循环
                var firstname = "";
                List<string> fromname=new List<string>(); 
                var item=model.Category;
                    firstname=item.Name;
                   fromname.Add(item.Name);
                //第2
                   if (item.ParSysList != null)
                   {
                       var item2 = item.ParSysList; 
                       firstname = item2.Name;
                       fromname.Add(item2.Name);
                       //第2
                       if (item2.ParSysList != null)
                       {
                           var item3 = item2.ParSysList;
                           firstname = item3.Name;
                           fromname.Add(item3.Name);
                           //第3
                           if (item3.ParSysList != null)
                           {
                               var item4 = item3.ParSysList;
                               firstname = item4.Name;
                               fromname.Add(item4.Name);
                               //第4
                               if (item4.ParSysList != null)
                               {
                                   var item5 = item4.ParSysList;
                                   firstname = item5.Name;
                                   fromname.Add(item5.Name);
                                   //第5
                                   if (item5.ParSysList != null)
                                   {
                                       var item6 = item5.ParSysList;
                                       firstname = item6.Name;
                                       fromname.Add(item6.Name);
                                       //第6
                                       if (item6.ParSysList != null)
                                       {
                                           var item7 = item6.ParSysList;
                                           firstname = item7.Name;
                                           fromname.Add(item7.Name); 
                                           //第7
                                           if (item7.ParSysList != null)
                                           {
                                               var item8 = item7.ParSysList;
                                               firstname = item8.Name;
                                               fromname.Add(item8.Name); 

                                           }

                                       }


                                   }


                               }


                           }


                       }
                   }

                #endregion
                   model.CategoryLoopName = firstname;
                   model.CategoryFromName = string.Join(",", fromname.ToArray());
            }  

            return model;
        }

        public static IList<T_CostModel> DTOList(this IQueryable<T_Cost> nodes)
        {
            if (nodes == null)
                return null;
            var result = nodes.ToList().Select(node => node.DTO()).ToList();
            return result;
        }

        public static T_Cost ToModel(this  T_CostModel node)
        {
            return new T_Cost()
            {
                Id = node.Id,
                CategoryId = node.CategoryId,
                SupplierId = node.SupplierId,
                Group = node.Group,
                Cost = node.Cost,
                Description = node.Description,
                Level = node.Level,
                Profit = node.Profit,
                Remark = node.Remark,
                Uom = node.Uom,
                Enable = node.Enable,
            };
        }
    }
}
