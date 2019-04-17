using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Models
{
    /// <summary>
    /// DTO对象
    /// </summary>
   public  class T_UserModel
    {
       public string Action { get; set; }
       public int Id { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public string StaffName { get; set; }
        public string Alias { get; set; }
       public string Sex { get; set; }
       public DateTime? BirthDate { get; set; }
       public DateTime? Dateoined { get; set; }
       public DateTime? DateResignation { get; set; }
       public int CompanyId { get; set; }
       public int? GroupId { get; set; }
       public string Position { get; set; }
       public int RoleId { get; set; }
       public string Nationality { get; set; }
       public string Marital { get; set; }
      public string Phone { get; set; }
      public string Mobile { get; set; }
      public string Email { get; set; }
      public string Fax { get; set; }
      public string Blk { get; set; }
      public string StreetName { get; set; }
      public string BuildingName { get; set; }
      public string Unit { get; set; }
      public string PostalCode { get; set; }
      public bool Enable { get; set; }
      public string CompanyName { get; set; }
      public string RoleName { get; set; }
      public string AcctCode { get; set; }
      public decimal? Salary { get; set; }
      public decimal? AppointmentAllowance { get; set; }
      public decimal? FixedAllowance { get; set; }
      public decimal? EmployerCpf { get; set; }
      public decimal? EmployeeCpf { get; set; }
       public string BankName { get; set; }
      public string BankNumber { get; set; }
      public decimal? Commission { get; set; }
      public List<T_LeaveSettingModel> Holidays{get;set;}
        
    }
   /// <summary>
   /// 查询对象
   /// </summary>
    public class UserModel : Page
   {
       public int CompanyId { get; set; }
       public string StaffName { get; set; }
   }
   public class LoginModel
   {
       /// <summary>
       /// 登录用户的ID
       /// </summary>
       public int Id { get; set; }
       /// <summary>
       /// 用户登录帐号
       /// </summary>
       public string LoginId { get; set; }
       /// <summary>
       /// 用户名称
       /// </summary>
       public string UserName { get; set; }
       /// <summary>
       /// 登录密码
       /// </summary>
       public string Password { get; set; }
       /// <summary>
       /// 所属公司
       /// </summary>
       public int CompanyId { get; set; } 
       /// <summary>
       /// 角色ID（选用）
       /// </summary>
       public int? RoleId { get; set; }
       /// <summary>
       /// 角色的权限字符串
       /// </summary>
       public string[] Roles { get; set; }
     

   }

    /// <summary>
    /// 存储的数据
    /// </summary>
   public class UserData
   {
       /// <summary>
       /// 登录用户的ID
       /// </summary>
       public int UserId { get; set; }
       /// <summary>
       /// 用户名称
       /// </summary>
       public string UserName { get; set; }
       /// <summary>
       /// 所属公司
       /// </summary>
       public int CompanyId { get; set; }
       public string CompanyName { get; set; }
       /// <summary>
       /// 角色ID（选用）
       /// </summary>
       public int? RoleId { get; set; }
       /// <summary>
       /// 角色的权限字符串
       /// </summary>
       public string[] Roles { get; set; }


   }

    /// <summary>
    /// 员工工资对象
    /// </summary>
   public class T_UserSalaryModel
   {
       public string Action { get; set; }
       public int Id { get; set; } 
       public decimal? Salary { get; set; }
       public decimal? AppointmentAllowance { get; set; }
       public decimal? FixedAllowance { get; set; }
       public decimal? EmployerCpf { get; set; }
       public decimal? EmployeeCpf { get; set; }
       public string BankName { get; set; }
       public string BankNumber { get; set; }
       public decimal? Commission { get; set; }

   }
    /// <summary>
    /// 员工信息修改
    /// </summary>
   public class T_UserStaffModel
   {
       public string Action { get; set; }
       public int Id { get; set; }
       public string LoginId { get; set; }
       public string Password { get; set; }
       public string StaffName { get; set; }
       public string Alias { get; set; }
       public string Sex { get; set; }
       public DateTime? BirthDate { get; set; }
       public DateTime? Dateoined { get; set; }
       public DateTime? DateResignation { get; set; }
       public int CompanyId { get; set; }
       public int? GroupId { get; set; }
       public string Position { get; set; }
       public int RoleId { get; set; }
       public string Nationality { get; set; }
       public string Marital { get; set; }
       public string Phone { get; set; }
       public string Mobile { get; set; }
       public string Email { get; set; }
       public string Fax { get; set; }
       public string Blk { get; set; }
       public string StreetName { get; set; }
       public string BuildingName { get; set; }
       public string Unit { get; set; }
       public string PostalCode { get; set; }
       public bool Enable { get; set; }
       public string CompanyName { get; set; }
       public string RoleName { get; set; }
       public string AcctCode { get; set; }
    

   }


}
