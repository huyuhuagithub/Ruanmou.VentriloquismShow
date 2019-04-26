using Ruanmou.Common;
using Ruanmou.Common.AttributeExtend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ruanmou.VentriloquismShow.Interface
{
    public abstract class AbstractFactions
    {
        [Remark("人")]
        public string Person { get; set; }//人
        public string Desk { get; set; }//卓
        public string Chair { get; set; }//椅
        public string Fan { get; set; }//扇
        public string Ruler { get; set; }//尺

        protected int temperature = 400;

        protected Func<int, bool> FuncJudge = i => i > 400;

        public event Action FireOn;
        public virtual void SetTemperature(int temperature)
        {
            //if (temperature >= this.temperature)//燃点
            if (this.FuncJudge.Invoke(temperature))
            {
                this.FireOnInvoke();
            }
        }


        //套路2
        //1 虚方法重载
        //2 把温度做成属性，构造函数时候初始化
        //3 把燃点这个值写入到配置文件
        //4 委托判断条件

        protected void FireOnInvoke()
        {
            this.FireOn?.Invoke();
        }
        public void ShowUniskill()
        {
            Console.WriteLine("绝活马上开始了。。。");
            this.ShowUniskillCore();
            Console.WriteLine("绝活表演结束，大家鼓掌！！");
        }
        /// <summary>
        /// 套路1
        /// </summary>
        protected virtual void ShowUniskillCore()
        {
            Console.WriteLine("默认绝活儿动作。。。");
        }

        public void Play()
        {
            //"表演开始了"
            //string sf = "表演开始了。。。";
            //sf.ToCharArray().ToList().ForEach(s => { Console.Write(s); Thread.Sleep(150); });
            LogHelper.WriteLogAndConsole("表演开始了。。。");
        }

        public abstract void ImitateDogBark();
        public abstract void ImitatePeopleVoice();
        public abstract void ImitateSoundOfWind();
        /// <summary>
        /// 我是开场白
        /// </summary>
        public virtual void Prologue()
        {
            LogHelper.WriteLogAndConsole("口技表演起");
        }
        /// <summary>
        /// 我是结束语
        /// </summary>
        public virtual void Peroration()
        {
            LogHelper.WriteLogAndConsole("今天的演出到此结束");
        }


    }
}
