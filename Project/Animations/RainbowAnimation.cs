using System;
using System.Drawing;
using System.Threading;

namespace nano.Project.Animations
{
    public class RainbowAnimation : BaseAnimation
    {
        private Random random;

        protected override int TickDuration { get; set; } = 16;

        public RainbowAnimation()
        {
            this.random = new Random();
        }

        public override void Start()
        {
            base.Start();
            this.LedGroup.ForEach(w => w.Color = Color.FromArgb(this.random.Next(255), this.random.Next(255), this.random.Next(255)));
        }

        public override bool Update()
        {
            base.Update();

            this.LedGroup.ForEach(w =>
                {
                    double h, s, v;
                    Colors.ColorToHSV(w.Color, out h, out s, out v);

                    h += 2;
                    v += random.Next(-100, 100) / 1000;
                    v = Math.Clamp(v, 0.5f, 1);

                    w.Color = Colors.ColorFromHSV(h, s, v);
                }
            );

            // Apply
            this.Apply();
            Thread.Sleep(this.TickDuration);

            return true;
        }
    }
}
