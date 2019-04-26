using System;
using Ruanmou.Common;
using Ruanmou.VentriloquismShow.Interface;

namespace Ruanmou.VentriloquismShow.Service
{
    public class MiddleFactions : AbstractFactions, ICharge
    {

        public string Remark = null;
        public string Majiangji { get; set; }
        public void Majiang()
        {
            Console.WriteLine("模拟多人打麻将的绝活儿~~");
        }

        public event Action StartOn;
        public event Action ClimaxOn;
        public event Action EndOn;

        /// <summary>
        /// 完整show  把各种固定环节都完成
        /// </summary>
        public void MiddleShow()
        {
            base.Prologue();

            this.StartOn?.Invoke();

            this.ImitateDogBark();
            this.ImitatePeopleVoice();
            this.ImitateSoundOfWind();

            this.Majiang();
            this.ClimaxOn?.Invoke();

            this.Charge();
            this.EndOn?.Invoke();
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
            LogHelper.WriteLogAndConsole($"开场白");
        }

    }
}