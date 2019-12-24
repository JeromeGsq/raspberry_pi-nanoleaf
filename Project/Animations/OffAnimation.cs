using System.Drawing;
using System.Threading;

namespace nano.Project.Animations
{
    public class OffAnimation : BaseAnimation
    {
        protected override int TickDuration { get; set; } = 16;

        public override bool Update()
        {
            base.Update();

            for (int i = 0; i < this.LedGroup.Count; i++)
            {
                this.LedGroup[i].Color = Color.White;

                this.Apply();
                Thread.Sleep(this.TickDuration);
            }

            for (int i = 0; i < this.LedGroup.Count; i++)
            {
                this.LedGroup[i].Color = Color.Black;

                this.Apply();
                Thread.Sleep(this.TickDuration);
            }

            return false;
        }
    }
}
