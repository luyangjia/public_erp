using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.BLL;
using MVC.Helper;
using MVC.Helper.Unity;
using MVC.Models;
using System.Linq.Expressions;
namespace MVC.UI.Controllers
{
    /// <summary>
    /// 主要是通用方法
    /// </summary>
    public class BaseController : Controller
    {
        private IT_ClientBLL it_ClientBLL; 
        private IT_CompanyBLL it_CompanyBLL;
        private IT_SupplierBLL it_SupplierBLL;
        private IT_SysListBLL it_SysListBLL; 
        private IT_RoleBLL it_RoleBLL;
        private IT_UserBLL it_UserBLL;
        private IT_DepartmentBLL it_DepartmentBLL;
        private IT_LeaveSettingBLL it_LeaveSettingBLL;
        private IT_LeaveApplyBLL it_LeaveApplyBLL;
        private IT_LeaveCarryOverBLL it_LeaveCarryOverBLL;  
        public BaseController()
        {
            it_ClientBLL = ServiceLocator.Instance.GetService<IT_ClientBLL>(); 
            it_CompanyBLL = ServiceLocator.Instance.GetService<IT_CompanyBLL>();
            it_SupplierBLL = ServiceLocator.Instance.GetService<IT_SupplierBLL>();
            it_SysListBLL = ServiceLocator.Instance.GetService<IT_SysListBLL>(); 
            it_RoleBLL = ServiceLocator.Instance.GetService<IT_RoleBLL>();
            it_UserBLL = ServiceLocator.Instance.GetService<IT_UserBLL>();
            it_DepartmentBLL = ServiceLocator.Instance.GetService<IT_DepartmentBLL>();
            it_LeaveSettingBLL = ServiceLocator.Instance.GetService<IT_LeaveSettingBLL>();
            it_LeaveApplyBLL = ServiceLocator.Instance.GetService<IT_LeaveApplyBLL>();
            it_LeaveCarryOverBLL = ServiceLocator.Instance.GetService<IT_LeaveCarryOverBLL>();
        } 
      
        #region 公共方法
        /// <summary>
        /// 下拉框绑定
        /// </summary>
        /// <param name="parament"></param>
        /// <returns></returns>
        public ActionResult GetCombox()
        {
            List<T_TreeSysListModel> result = new List<T_TreeSysListModel>();
            T_TreeSysListModel data = new T_TreeSysListModel();
            int SysId = Request["SysId"] == null ? 0 : int.Parse(Request["SysId"]);
            string type = Request["type"];
            string first = Request["first"];
            string userId = Request["userId"];
            string bind = Request["bind"] == null ? "id" : Request["bind"]; //绑定类型是 id: id/text
            int year = DateTime.Now.Year;
            if (first == "null")
            {
                result.Add(new T_TreeSysListModel { id = "", text = "　" });
            }
            List<T_CompanyModel> Companys = new List<T_CompanyModel>();
            List<T_DepartmentModel> Departments = new List<T_DepartmentModel>();
            List<T_UserModel> Users = new List<T_UserModel>();
            List<T_RoleModel> Roles = new List<T_RoleModel>();
            List<T_TreeSysListModel> treeList = new List<T_TreeSysListModel>();
            T_TreeSysListModel treeNode = new T_TreeSysListModel();

            //Func<T_CompanyModel, object> ascOrder_Company = b => b.Company;
            //Func<T_UserModel, object> ascOrder_User = b => b.StaffName;
            Dictionary<string, string> orders = new Dictionary<string, string>();
            try
            {
                switch (type)
                {
                    case "User":
                        //用户 
                        orders = new Dictionary<string, string>();
                        orders.Add("StaffName", "asc");
                        Users = it_UserBLL.Filter(null,orders);
                        foreach (var item in Users)
                        {
                            result.Add(new T_TreeSysListModel { id = item.Id.ToString(), text = item.StaffName });
                        }
                        break;
                    case "Company":
                        //公司 
                         orders = new Dictionary<string, string>();
                        orders.Add("Company", "asc");
                        Companys = it_CompanyBLL.Filter(null, orders);
                        foreach (var item in Companys)
                        {
                            result.Add(new T_TreeSysListModel { id = item.Id.ToString(), text = item.Company });
                        }
                        break;
                    case "Role":
                        //角色
                         orders = new Dictionary<string, string>();
                        orders.Add("Name", "asc"); 
                        Roles = it_RoleBLL.Filter(null, orders); 
                        foreach (var item in Roles)
                        {
                            result.Add(new T_TreeSysListModel { id = item.Id.ToString(), text = item.Name });
                        }
                        break; 
                    case "Supplier":
                        //供应商
                         var Supplier = it_SupplierBLL.Filter();  
                        foreach (var item in Supplier)
                        {
                            result.Add(new T_TreeSysListModel { id = item.Id.ToString(), text = item.Company });
                        }
                        break;
                    case "Client":
                        //客户
                        orders = new Dictionary<string, string>();
                        orders.Add("Name", "asc");  
                        var Client = it_ClientBLL.Filter(null, orders);
                        foreach (var item in Client)
                        {
                            result.Add(new T_TreeSysListModel { 
                                id = item.Id.ToString(), 
                                text = item.Name,
                                Blk = item.Blk,
                                BuildingName = item.BuildingName,
                                StreetName = item.StreetName,
                                PostalCode = item.PostalCode,
                                Unit = item.Unit,
                                Mobile = item.Mobile,
                                Phone = item.Phone,
                            });
                        }
                        break;
                    case "Race":
                        //种族
                        Expression<Func<T_SysListModel, bool>> whereRace = w => w.SysId == DictionaryCache.RaceId; 
                        orders = new Dictionary<string, string>();
                        orders.Add("Listorder", "asc"); 
                        var Race = it_SysListBLL.Filter(whereRace, orders); 
                        foreach (var item in Race)
                        {
                            result.Add(new T_TreeSysListModel { id = item.Name, text = item.Name });
                        }
                        break;
                    case "SysList":
                        //字典表
                        var ListData = it_SysListBLL.Tree(SysId, bind);
                        if (first == "node")
                        {
                             treeList = new List<T_TreeSysListModel>();
                             treeNode = new T_TreeSysListModel();
                             treeNode.id = "";
                             treeNode.text = "All Node";
                             treeNode.children = ListData;
                             treeList.Add(treeNode);
                             result.AddRange(treeList);
                        }
                        else
                        {
                              result.AddRange(ListData);
                        } 
                        break;
                    case "Company-Department":
                        //公司-部门
                        orders = new Dictionary<string, string>();
                        orders.Add("Company", "asc"); 
                        Companys = it_CompanyBLL.Filter(null,  orders);
                        orders = new Dictionary<string, string>();
                        orders.Add("Name", "asc"); 
                        Departments = it_DepartmentBLL.Filter(null,  orders); 

                        foreach (var item in Companys)
                        {
                            treeList = new List<T_TreeSysListModel>();
                            treeNode = new T_TreeSysListModel();  
                            treeNode.id = item.Id.ToString();
                            treeNode.text = item.Company;
                            
                             foreach (var list in Departments.Where(w=>w.CompanyId==item.Id).ToList())
                             {
                                 treeList.Add(new T_TreeSysListModel { id = item.Id.ToString() + "-" + list.Id.ToString(), text = list.Name });
                             }
                             treeNode.children = treeList; 
                             result.Add(treeNode);

                            
                        }
                        break;
                    case "Company-User":
                        //公司-员工（树形）
                           orders = new Dictionary<string, string>();
                        orders.Add("Company", "asc"); 
                        Companys = it_CompanyBLL.Filter(null,orders);
                        orders = new Dictionary<string, string>();
                        orders.Add("StaffName", "asc"); 
                         Users = it_UserBLL.Filter(null, orders);
                        foreach (var item in Companys)
                        {
                            treeList = new List<T_TreeSysListModel>();
                            treeNode = new T_TreeSysListModel();   
                            treeNode.id = item.Id.ToString();
                            treeNode.text = item.Company;

                            foreach (var list in Users.Where(w => w.CompanyId == item.Id).ToList())
                            {
                                treeList.Add(new T_TreeSysListModel { id = item.Id.ToString() + "-" + list.Id.ToString(), text = list.StaffName });
                            }
                            treeNode.children = treeList;

                            result.Add(treeNode);


                        }
                        break;
                    case "Company-UserForGroup":
                        //公司-员工（下拉分组）
                        orders = new Dictionary<string, string>();
                        orders.Add("Company", "asc"); 
                        Companys = it_CompanyBLL.Filter(null,  orders);
                        orders = new Dictionary<string, string>();
                        orders.Add("StaffName", "asc"); 
                        Users = it_UserBLL.Filter(null,  orders);
                        foreach (var item in Companys)
                        {  
                            foreach (var list in Users.Where(w => w.CompanyId == item.Id).ToList())
                            {
                                result.Add(new T_TreeSysListModel { id = list.Id.ToString(), text = list.StaffName, group = item.Company });
                            }  
                        }
                      
                        break;
                    case "Leave":
                        //假期 
                        orders = new Dictionary<string, string>();
                        orders.Add("Name", "asc"); 
                        var Leave = it_LeaveSettingBLL.Filter(null, orders);
                        T_TreeSysListModel treemodel = new T_TreeSysListModel();
                        //如果有传userId 那就查出今年还剩下的请假天数
                        if (!string.IsNullOrEmpty(userId))
                        {
                            int userid = int.Parse(userId); 
                            //获得这个用户的工作时长
                            var userdata = it_UserBLL.Filter(c => c.Id == userid).FirstOrDefault();
                            DateTime workdate = DateTime.Parse(userdata.Dateoined.ToString()); 
                            //获得今年已经用掉的天数，包括在申请的 变更前和变更后审核的多算，防止漏洞。
                            List<int> statusids=new List<int>(){0,1,3,5};
                             
                            var useLeave = it_LeaveApplyBLL.Filter(c=>c.UserId==userid && c.FromDate.Year==year && statusids.Any(a=>c.Status==a) ).ToList();
                            //看下今年有哪些是去年留下来的假期
                            var carryOver = it_LeaveCarryOverBLL.Filter(c => c.UserId == userid && c.Year == year).ToList();
                            foreach (var item in Leave)
                            {
                                decimal days=0; //当年的假期
                                decimal days1=0; //用掉的假期
                                decimal days2=0; //去年留下来的假期
                                decimal? days3 = null; //最后剩下的
                                treemodel = new T_TreeSysListModel();
                                 var useleavedata=useLeave.Where(c=>c.SetingId==item.Id).ToList();
                                 var carryoverdata = carryOver.FirstOrDefault(c => c.SetingId == item.Id);
                                 days1 = useleavedata.Count() > 0 ? useleavedata.Sum(s => s.Days) : 0;
                                 days2 = carryoverdata == null ? 0 : carryoverdata.Days;
                                 days = item.Days;
                                 if ((item.Months > 0 && workdate.AddMonths(item.Months)<=DateTime.Now) || item.Months<=0)
                                {
                                    //如果需要大于几个月后才有的假期，判断 
                                    days3=(days+days2)-days1;
                                } 
                                 else
                                 {
                                     days3 = 0;
                                 }

                                treemodel.id = item.Id.ToString();
                                treemodel.text = item.Name;
                                treemodel.UseDays = days1;
                                if(item.IsLimit==true)
                                   treemodel.RemainingDays =days3;

                                result.Add(treemodel);
                            }

                        }
                        else
                        {
                            foreach (var item in Leave)
                            {
                                result.Add(new T_TreeSysListModel { id = item.Id.ToString(), text = item.Name });
                            }
                        }
                        //Expression<Func<T_LeaveApplyModel, bool>> where = w => w.Id > 4;
                        //Func<T_LeaveApplyModel, object> descOrder = b => b.FromDate;
                        //var userData3 = it_LeaveApplyBLL.Filter(where, "desc", descOrder);
                        break;
                    default:
                        break;

                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }

            return Json(result, JsonRequestBehavior.AllowGet);

        }




       



        #endregion


         

    }
}