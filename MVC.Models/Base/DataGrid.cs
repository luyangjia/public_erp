using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Models
{
    /// <summary>
    /// DataGrid数据集格式
    /// </summary>
    /// <typeparam name="T">数据类型</typeparam>
    public class DataGrid<T>
    {
        /// <summary>
        /// 数据总数
        /// </summary>
        public int total { get; set; }
        /// <summary>
        /// 数据集
        /// </summary>
        public List<T> rows { get; set; } 
    }
}
