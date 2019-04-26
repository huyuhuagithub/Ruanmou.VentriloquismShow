using Ruanmou.Common;
using Ruanmou.Common.AttributeExtend;
using Ruanmou.VentriloquismShow.Interface;
using Ruanmou.VentriloquismShow.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ruanmou.VentriloquismShow
{
    /// <summary>
    /// 1 泛型/反射/接口抽象类/虚方法
    /// 2 事件观察者
    /// 3 程序可配置
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("This is Homework VentriloquismShow");

                {
                    EastFactions factions = new EastFactions();
                    factions.Chair = "123";
                    factions.Desk = "1234";
                    factions.Fan = "1235";
                    factions.Person = "1236";
                    factions.Ruler = "1237";
                    Display<EastFactions>(factions);
                    factions.ShowUniskill();
                    factions.FireOn += factions.ImitatePeopleVoice;
                    factions.FireOn += factions.ImitateDogBark;
                    factions.FireOn += () => Console.WriteLine("妇亦起大呼");
                    factions.FireOn += () => Console.WriteLine("两儿齐哭");
                    //for (int i = 0; i < 1000; i++)
                    //{
                    //    Thread.Sleep(100);
                    //    factions.SetTemperature(i);
                    //}
                    factions.SetTemperature(410);
                    //事件的意义：观察者   

                    //事件的发布者只是声明event 触发动作
                    //触发动作：订户
                    //第三方完成注册  订阅动作
                }

                {
                    SouthFactions southFactions = SimpleFactory.Create<SouthFactions>();
                    //WestFactions westFactions = SimpleFactory.Create<WestFactions>();
                    Display<SouthFactions>(southFactions);
                    //Display<WestFactions>(westFactions);
                    southFactions.Person = "1111";
                    southFactions.Desk = "0000";
                    southFactions.Chair = "2222";
                    southFactions.Fan = "3333";
                    southFactions.Ruler = "4444";
                    southFactions.ShowUniskill();
                    southFactions.FireOn += () => { Console.WriteLine("妇亦起大呼"); };
                    southFactions.FireOn += () => Console.WriteLine("两人齐哭");
                    southFactions.FireOn += southFactions.ImitateDogBark;
                    southFactions.FireOn += southFactions.ImitatePeopleVoice;
                    //for (int i = 0; i < 1000; i++)
                    //{
                    //    Thread.Sleep(100);
                    //    southFactions.SetTemperature(i);
                    //}
                    southFactions.SetTemperature(1001);
                }

                {
                    MiddleFactions middleFactions = SimpleFactory.Create<MiddleFactions>();
                    middleFactions.StartOn += () => Console.WriteLine("妇亦起大呼");
                    middleFactions.ClimaxOn += () => Console.WriteLine("妇亦起大呼");
                    middleFactions.EndOn += () => Console.WriteLine("妇亦起大呼");
                    middleFactions.MiddleShow();
                }

                {
                    WestFactions westFactions = SimpleFactory.Create<WestFactions>();
                    westFactions.FireOn += () => Console.WriteLine("妇亦起大呼");
                    westFactions.SetTemperature(900);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }

        private static void Display<T>(T model) where T : AbstractFactions, ICharge
        {
            //model.
            Type t = typeof(T);
            foreach (PropertyInfo info in t.GetProperties())
            {
                LogHelper.WriteLog($"{t.FullName} 的 {info.GetRemark()} 属性值为 {info.GetValue(model)}");
            }
            foreach (FieldInfo field in t.GetFields())
            {
                LogHelper.WriteLog($"{t.FullName} 的 {field.Name} 属性值为 {field.GetValue(model)}");
            }
            foreach (var Methods in t.GetMethods())
            {

            }
            model.Play();
            model.Prologue();
            model.ImitateDogBark();
            model.ImitatePeopleVoice();
            model.ImitateSoundOfWind();
            model.Peroration();

            model.Charge();
        }
    }
}
