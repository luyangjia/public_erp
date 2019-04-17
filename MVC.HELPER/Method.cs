using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Web.Script.Serialization;

namespace MVC.Helper
{
    public class Method
    {
   /// <summary>
   /// 获得36位的key
   /// </summary>
   /// <returns></returns>
         public static string GetKey()
          {
            string last = "";
            string checkCode = "";
            int number = 0;
            Random random=new Random();
            for (int i = 0; i <= 31; i++)
            {
                number = random.Next();
                number = number % 36;
                if(number<10)
                {
                    number = number + 48; //'数字0-9编码在48-57  
                }
                else
                {
                    number = number + 55; // 字母A-Z编码在65-90
                }
                checkCode = checkCode + Chr(number); 
            }
            last = checkCode.Substring(0, 8) + "-" + checkCode.Substring(8,4) + "-" + checkCode.Substring(12, 4) + "-" + checkCode.Substring(16, 4) + "-" + checkCode.Substring(20);
            return last;
        }
         

        /// <summary>
        /// 根据字符转换ASSCII的数字
        /// </summary>
        /// <param name="character">字符</param>
        /// <returns></returns>
        public static int Asc(string character)
        {
            if (character.Length == 1)
            {
                System.Text.ASCIIEncoding asciiEncoding = new System.Text.ASCIIEncoding();
                int intAsciiCode = (int)asciiEncoding.GetBytes(character)[0];
                return (intAsciiCode);
            }
            else
            {
                throw new Exception("Character is not valid.");
            }

        }


        /// <summary>
        /// 根据数字转换ASSCII的字符
        /// </summary>
        /// <param name="asciiCode">数字</param>
        /// <returns></returns>
        public static string Chr(int asciiCode)
         {
            if (asciiCode >= 0 && asciiCode <= 255)
            {
                System.Text.ASCIIEncoding asciiEncoding = new System.Text.ASCIIEncoding();
                byte[] byteArray = new byte[] { (byte)asciiCode };
                string strCharacter = asciiEncoding.GetString(byteArray);
                return (strCharacter);
            }
            else
            {
                throw new Exception("ASCII Code is not valid.");
            }
        }
         

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">传入值</param>
        /// <param name="repvalue">空时的替换值</param>
        /// <returns></returns>
        public string NVL(object value, string repvalue)
        {
            string last = "";
            if (RuntimeHelpers.GetObjectValue(value) is DBNull)
            {
                 if(!string.IsNullOrEmpty((string)RuntimeHelpers.GetObjectValue(value)))
                {
                    last =(string)RuntimeHelpers.GetObjectValue(value);
                }
                 else
                {
                    last = repvalue;
                }
            }
            else
            {
                last = repvalue;
            }
            return last;

        }
         

        /// <summary>
        /// 判断是否是正整数
        /// </summary>
        /// <param name="value"></param>
        /// <returns>True为正整数</returns>
        public static bool isNumeric(string value)
        { 
            return Regex.IsMatch(value, @"^[0-9]*[1-9][0-9]*$");
        }

        /// <summary>
        /// 判断是否是数字类型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool CheckNum(string value)
        {
            return Regex.IsMatch(value, @"^[-]?\d*[.]?\d*$");
        }

        /// <summary>是否日期</summary>
        /// <param name="strInput">输入字符串</param>
        /// <returns>true/false</returns>
        public static bool isDate(string strInput)
        {
            string datestr = strInput;
            string year, month, day;
            string[] c = { "/", "-", "." };
            string cs = "";
            for (int i = 0; i < c.Length; i++)
            {
                if (datestr.IndexOf(c[i]) > 0)
                {
                    cs = c[i];
                    break;
                }
            };
            if (cs != "")
            {
                year = datestr.Substring(0, datestr.IndexOf(cs));
                if (year.Length != 4) { return false; };
                datestr = datestr.Substring(datestr.IndexOf(cs) + 1);
                month = datestr.Substring(0, datestr.IndexOf(cs));
                if ((month.Length != 2) || (Convert.ToInt16(month) > 12))
                { return false; };
                datestr = datestr.Substring(datestr.IndexOf(cs) + 1);
                day = datestr;
                if ((day.Length != 2) || (Convert.ToInt16(day) > 31))
                { return false; };
                return checkDatePart(year, month, day);
            }
            else
            {
                return false;
            }
        }
        private static bool checkDatePart(string year, string month, string day)
        {
            int iyear = Convert.ToInt16(year);
            int imonth = Convert.ToInt16(month);
            int iday = Convert.ToInt16(day);
            if (iyear > 2099 || iyear < 1900) { return false; }
            if (imonth > 12 || imonth < 1) { return false; } 
            return true;
        }
          

        /// <summary>
        /// 转全角的函数(SBC case)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToSBC(string value)
        {
            //半角转全角：
            char[] c = value.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 32)
                {
                    c[i] = (char)12288;
                    continue;
                }
                if (c[i] < 127)
                    c[i] = (char)(c[i] + 65248);
            }
            return new string(c);
        }

        /// <summary>
        ///  转半角的函数(SBC case)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToDBC(string value)
        {
            char[] c = value.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new string(c);
        }

        /// <summary>
        /// 根据月份返回英文的月份
        /// </summary>
        /// <param name="months">月份，数字或前面带0</param>
        /// <param name="type">月份类型1返回简写的月份，否则全写的月份</param>
        /// <returns></returns>
        public static string MonthsTOEn(string months,int type)
        {
            string months_en = "";
            string short_en = "";
            switch (months)
            {
                case "1":
                case "01":
                    months_en = "January";
                    short_en = "Jan";
                    break;
                case "2":
                case "02":
                    months_en = "February";
                    short_en = "Feb";
                    break;
                case "3":
                case "03":
                    months_en = "March";
                    short_en = "Mar";
                    break;
                case "4":
                case "04":
                    months_en = " April";
                    short_en = "Apr";
                    break;
                case "5":
                case "05":
                    months_en = "May";
                    short_en = "May";
                    break;
                case "6":
                case "06":
                    months_en = "June";
                    short_en = "June";
                    break;
                case "7":
                case "07":
                    months_en = "July";
                    short_en = "July";
                    break;
                case "8":
                case "08":
                    months_en = "Aguest";
                    short_en = "Aug";
                    break;
                case "9":
                case "09":
                    months_en = "September";
                    short_en = "Sept";
                    break;
                case "10": 
                    months_en = "October";
                    short_en = "Oct";
                    break;
                case "11": 
                    months_en = "November";
                    short_en = "Nov";
                    break;
                case "12":
                    months_en = "December";
                    short_en = "Dec";
                    break;
            }
            if (type == 1)
            {
                return short_en;
            }
            else
            {
                return months_en;
            }
            
        }
        

        #region webconfig操作
        /// <summary>
        /// 得到AppSettings中的配置字符串信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConfigString(string key)
        {
            return ConfigurationManager.AppSettings[key].Trim();
        }
        /// <summary>
        /// 得到ConnectionStrings中的配置字符串信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConfig(string key)
        {
            return ConfigurationManager.ConnectionStrings[key].ConnectionString;
     
        }

        /// <summary>
        /// 将DataTable数据集转换成Jsno
        /// </summary>
        /// <param name="dt">数据集</param>
        /// <param name="rownum">总行数</param>
        /// <returns></returns>

        public string ToJson(DataTable dt,int rownum)
        {
            
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            foreach (DataRow dr in dt.Rows)
            {
                Dictionary<string, object> result = new Dictionary<string, object>();
                foreach (DataColumn dc in dt.Columns)
                {
                    result.Add(dc.ColumnName.ToLower(), dr[dc].ToString());
                }
                list.Add(result);
            }
           var griddata  = new { total = rownum, rows = list }; 
             
            return serializer.Serialize(griddata);
        }

        /// <summary>
        /// 将DataTable数据集转换成Jsno
        /// </summary>
        /// <param name="dt">数据集</param> 
        /// <returns></returns>

        public string ToJson(DataTable dt)
        {

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            foreach (DataRow dr in dt.Rows)
            {
                Dictionary<string, object> result = new Dictionary<string, object>();
                foreach (DataColumn dc in dt.Columns)
                {
                    result.Add(dc.ColumnName.ToLower(), dr[dc].ToString());
                }
                list.Add(result);
            }
            var griddata = new { rows = list };

            return serializer.Serialize(griddata);
        }



        #endregion
         
        /// <summary>
        /// 将按照formObj对象修改toObj的值，不在formObj对象里的属性不修改
        /// </summary>
        /// <param name="formObj">按照这个对象进行修改</param>
        /// <param name="toObj">目标对象要修改的数据即返回对象</param>
        /// <returns></returns>
        public static object CopyModel(object formObj, object toObj)
        {
            System.Reflection.PropertyInfo[] Propertys = formObj.GetType().GetProperties();
            foreach (var item in Propertys)
            {
                if (toObj.GetType().GetProperty(item.Name) != null)
                {
                    toObj.GetType().GetProperty(item.Name).SetValue(toObj, formObj.GetType().GetProperty(item.Name).GetValue(formObj));
                }
            }

            return toObj;
        }

    }
}