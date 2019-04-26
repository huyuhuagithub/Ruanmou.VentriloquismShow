using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruanmou.Common
{
    public class LogHelper
    {
        /// <summary>
        /// 静态构造函数完成路径的创建  不需要每次都判断路径
        /// 创建后被删除可能有问题
        /// </summary>
        static LogHelper()
        {
            string rootPath = StaticConstant.LogRootPath;
            if (!Directory.Exists(rootPath))
            {
                Directory.CreateDirectory(rootPath);
            }
        }

        /// <summary>
        /// 基础日志方法
        /// </summary>
        /// <param name="msg"></param>
        public static void WriteLog(string msg)
        {
            string rootPath = StaticConstant.LogRootPath;
            string fileName = DateTime.Now.ToString("yyyy-MM-dd.TXT");
            if (!Directory.Exists(rootPath))
            {
                Directory.CreateDirectory(rootPath);
                WriteLog(msg);
            }

            var fullName = Path.Combine(rootPath, fileName);
            using (StreamWriter sw = File.AppendText(fullName))
            {
                sw.WriteLine($"{DateTime.Now}  :  {msg}");
            }
        }



        public static void WriteLogAndConsole(string msg)
        {
            Console.WriteLine(msg);
            //Console.BackgroundColor = ConsoleColor.Blue;
            WriteLog(msg);
        }
    }
}
