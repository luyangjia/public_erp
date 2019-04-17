using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using System.Web.Optimization;
namespace MVC.UI
{ 
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {  
            //echart
            bundles.Add(new ScriptBundle("~/Content/eChart").Include(
                         "~/Content/echart/echarts.js",
                         "~/Content/echart/macarons.js"));

        }
    }
}