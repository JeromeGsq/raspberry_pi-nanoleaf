using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;

namespace nano.Project.Animations
{
    public class OffAnimation : BaseAnimation
    {
        protected override int TickDuration { get; set; } = 16;

        public OffAnimation()
        {
        }

        public override void Start()
        {
            base.Start();
        }

        public override bool Update()
        {
            base.Update();

            for (int i = 0; i < this.LedGroup.Count; i++)
            {
                this.LedGroup[i].Color = Color.White;
                // Apply
                this.Apply();
                Thread.Sleep(this.TickDuration);
            }

            for (int i = 0; i < this.LedGroup.Count; i++)
            {
                this.LedGroup[i].Color = Color.Black;
                // Apply
                this.Apply();
                Thread.Sleep(this.TickDuration);
            }

            return false;
        }
    }
}
