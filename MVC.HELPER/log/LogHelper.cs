
using System.Reflection;
using log4net;
using System;

namespace MVC.Helper.log
{
    public class LogHelper
    {
        public static void InitLog4Net()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var xml = assembly.GetManifestResourceStream("MVC.Helper.log.Log4net.config");
            log4net.Config.XmlConfigurator.Configure(xml);
        }

        #region   封装log4net,利用Action委托
        /// <summary>
        /// 封装log4net,利用Action委托
        /// </summary>
        /// <param name="log">日志对象</param>
        /// <param name="function">方法名</param>
        /// <param name="errorhandle">异常处理方式</param>
        /// <param name="tryHandle">调试/运行方法</param>
        /// <param name="catchHandle">异常处理=方式</param>
        /// <param name="finallyHandle">最终处理方式</param>
        public static void Logger(ILog log, string function, ErrorHandle errorhandle, Action tryHandle, Action<Exception> catchHandle = null, Action finallyHandle = null)
        {
            try
            {
               
                log.Debug(function);
                tryHandle();
            }
            catch (Exception ex)
            {
                log.Error(function + "失败", ex);
                if (catchHandle != null)
                {
                    catchHandle(ex);
                }
                if (errorhandle == ErrorHandle.Throw)
                {
                    throw ex;
                }
            }
            finally
            {
                if (finallyHandle != null)
                {
                    finallyHandle();
                }
            }

        }


       
        #endregion

       
    }
}