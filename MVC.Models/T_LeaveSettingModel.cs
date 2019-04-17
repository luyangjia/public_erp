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
    public class T_LeaveSettingModel
    {
        public string Action { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsLimit { get; set; }
        public bool IsCarryOver { get; set; }
        public decimal Days { get; set; }
        public int Months { get; set; }
        public bool IsUnpaid { get; set; }
        public bool Enable { get; set; }
        
    }
    /// <summary>
    /// 查询对象
    /// </summary>
    public class LeaveSettingModel : Page
    {
        public DateTime? BeginTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
    /// <summary>
    /// 员工的假期
    /// </summary>
    public class T_LeaveForUser
    {  
        /// <summary>
        /// 员工公司名称
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// 员工姓名
        /// </summary>
        public string StaffName { get; set; }
       /// <summary>
       /// 员工开始工作时间
       /// </summary>
        public DateTime? Dateoined { get; set; }
        /// <summary>
        /// 预定1-30个 也就是最多只能30个假期类型，多了这里继续定义
        /// </summary> 
        public string SettingValue0 { get; set; }
        public string SettingValue1 { get; set; }
        public string SettingValue2 { get; set; }
        public string SettingValue3 { get; set; }
        public string SettingValue4 { get; set; }
        public string SettingValue5 { get; set; }
        public string SettingValue6 { get; set; }
        public string SettingValue7 { get; set; }
        public string SettingValue8 { get; set; }
        public string SettingValue9 { get; set; }
        public string SettingValue10 { get; set; }
        public string SettingValue11 { get; set; }
        public string SettingValue12 { get; set; }
        public string SettingValue13 { get; set; }
        public string SettingValue14 { get; set; }
        public string SettingValue15 { get; set; }
        public string SettingValue16 { get; set; }
        public string SettingValue17 { get; set; }
        public string SettingValue18 { get; set; }
        public string SettingValue19 { get; set; }
        public string SettingValue20 { get; set; }
        public string SettingValue21 { get; set; }
        public string SettingValue22 { get; set; }
        public string SettingValue23 { get; set; }
        public string SettingValue24 { get; set; }
        public string SettingValue25 { get; set; }
        public string SettingValue26 { get; set; }
        public string SettingValue27 { get; set; }
        public string SettingValue28 { get; set; }
        public string SettingValue29 { get; set; } 

    }
}
