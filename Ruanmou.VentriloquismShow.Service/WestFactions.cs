using System;
using Ruanmou.Common;
using Ruanmou.VentriloquismShow.Interface;

namespace Ruanmou.VentriloquismShow.Service
{
    public class WestFactions : AbstractFactions, ICharge
    {
        public WestFactions()
        {
            base.FuncJudge = i => i >= 600;

            //不符合观察者
            //base.FireOn += this.ImitatePeopleVoice;
            //base.FireOn += this.ImitateDogBark;
            //base.FireOn += () => Console.WriteLine("妇亦起大呼");
        }

        public override void ImitateDogBark()
        {
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

        public override void Prologue()
        {
            LogHelper.WriteLogAndConsole($"南来的北往的，哈尔滨的香港的，走过路过千万不要错过啊");
        }
        public override void Peroration()
        {
            LogHelper.WriteLogAndConsole($"有钱的捧个钱场，没钱的就当买个门票，左边排队啊");
        }
    }
}