using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;

namespace nano.Project.Animations
{
    public class RainbowAnimation : BaseAnimation
    {

        protected override int TickDuration { get; set; } = 100;

        public override void Start()
        {
            base.Start();

            foreach (var led in this.LedGroup)
            {
                led.Color = Color.Beige;
            }

            this.Apply();

            Thread.Sleep(this.TickDuration);
            Thread.Sleep(this.TickDuration);
            Thread.Sleep(this.TickDuration);

            this.Run();
        }

        public override void Run()
        {
            base.Run();

            var rand = new Random(1);

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < this.LedGroup.Count; j++)
                {
                    this.LedGroup[j].Color = Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));
                }

                this.Apply();

                Thread.Sleep(this.TickDuration);
            }

            this.End();
        }

        public override void End()
        {
            base.End();
        }
    }
}
