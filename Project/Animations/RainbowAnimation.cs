using System;
using System.Drawing;
using System.Threading;

namespace nano.Project.Animations
{
    public class RainbowAnimation : BaseAnimation
    {
        private Random random;

        protected override int TickDuration { get; set; } = 16;

        public override void Start()
        {
            base.Start();
            this.random = new Random();
        }

        public override void Update()
        {
            base.Update();

            for (int j = 0; j < this.LedGroup.Count; j++)
            {
                this.LedGroup[j].Color = Color.FromArgb(this.random.Next(0, 255), this.random.Next(0, 255), this.random.Next(0, 255));
            }

            this.Apply();

            Thread.Sleep(this.TickDuration);
        }

        public override void End()
        {
            base.End();
        }
    }
}
