using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class Page
    {
        private int _page = 5;
        private int _rows = 5;
        private string _order = "asc";
        /// <summary>
        /// 当前页码
        /// </summary>
        public int page
        {
            get
            {
                return _page;
            }
            set
            {
                _page = value;
            }
        }
        /// <summary>
        /// 当前每页的行数
        /// </summary>
        public int rows
        {
            get
            {
                return _rows;
            }
            set
            {
                _rows = value;
            }
        }
        /// <summary>
        /// 排序字段
        /// </summary>
        public string sort { get; set; }
        /// <summary>
        /// 排序类型 asc/desc
        /// </summary>
        public string order
        {
            get
            {
                return _order;
            }
            set
            {
                _order = value;
            }
        }
    }
}