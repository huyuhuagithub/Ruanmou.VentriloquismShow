using Ruanmou.Common;
using Ruanmou.VentriloquismShow.Interface;
using System.Linq;
using System.Reflection;
using System.IO;
using System;

namespace Ruanmou.VentriloquismShow
{
    public class SimpleFactory
    {
        /// <summary>
        /// 简单工厂，用来创建不同门派的口技表演者
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Create<T>() where T : AbstractFactions, ICharge
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                $"ConfigFiles\\{typeof(T).Name}.json");

            string info = File.ReadAllText(path);
            T model = JsonHelper.JsonToObj<T>(info);
            return model;
        }
    }
}