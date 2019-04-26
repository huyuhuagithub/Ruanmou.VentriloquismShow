using System;
using Ruanmou.Common;
using Ruanmou.VentriloquismShow.Interface;

namespace Ruanmou.VentriloquismShow.Service
{
    public class NorthFactions : AbstractFactions, ICharge
    {
        public override void SetTemperature(int temperature)
        {
            if (temperature >= 1000)
            {
                base.FireOnInvoke();
            }
        }

        public override void ImitateDogBark()
        {
            //Console.WriteLine("狗叫声。。。");
            LogHelper.WriteLogAndConsole("狗叫声。。。");
        }

        public override void ImitatePeopleVoice()
        {
            LogHelper.WriteLogAndConsole($"咒骂声...");
        }

        public override void ImitateSoundOfWind()
        {
            LogHelper.WriteLogAndConsole($"呜...呜...呜...");
        }

        public void Charge()
        {
            LogHelper.WriteLogAndConsole($"本次表演收费{new Random().Next(10, 15)}$，微信支付麻烦左边，支付宝支持麻烦右边，现金和刷卡的麻烦排中间。");
        }

        public override void Peroration()
        {
            LogHelper.WriteLogAndConsole($"结束语");
        }
    }
}