using System;
using System.Drawing;
using System.Threading;

namespace nano.Project.Animations
{
    public class JediAnimation : BaseAnimation
    {
        private Random random;

        private int movementSpeed = 3;

        protected override int TickDuration { get; set; } = 16;

        public JediAnimation()
        {
            this.random = new Random();
        }

        public override bool Update()
        {
            base.Update();

            int greenPosition = random.Next(0, this.LedCount - 1);
            int redPosition = random.Next(0, this.LedCount - 1);

            while (redPosition == greenPosition)
            {
                redPosition = random.Next(0, this.LedCount - 1);
            }

            while (greenPosition != redPosition)
            {
                // Clear
                this.LedGroup.ForEach(w => w.Color = Color.Black);

                greenPosition += random.Next(-this.movementSpeed, this.movementSpeed);
                if (greenPosition >= this.LedCount)
                {
                    greenPosition = 0;
                }
                else if (greenPosition < 0)
                {
                    greenPosition = this.LedCount - 1;
                }

                redPosition += random.Next(-this.movementSpeed, this.movementSpeed);
                if (redPosition >= this.LedCount)
                {
                    redPosition = 0;
                }
                else if (redPosition < 0)
                {
                    redPosition = this.LedCount - 1;
                }

                this.LedGroup[greenPosition].Color = Color.Green;
                this.LedGroup[redPosition].Color = Color.Red;

                // Apply
                this.Apply();

                Thread.Sleep(this.TickDuration);
                Thread.Sleep(this.TickDuration);
                Thread.Sleep(this.TickDuration);
            }

            this.LedGroup.ForEach(w => w.Color = Color.White);
            this.Apply();

            Thread.Sleep(this.TickDuration * 3);
            this.LedGroup.ForEach(w => w.Color = Color.Green);
            this.Apply();
            Thread.Sleep(this.TickDuration * 3);
            this.LedGroup.ForEach(w => w.Color = Color.White);
            this.Apply();
            Thread.Sleep(this.TickDuration * 3);
            this.LedGroup.ForEach(w => w.Color = Color.Red);
            this.Apply();
            Thread.Sleep(this.TickDuration * 3);
            this.LedGroup.ForEach(w => w.Color = Color.Gray);
            this.Apply();
            Thread.Sleep(this.TickDuration * 3);
            this.LedGroup.ForEach(w => w.Color = Color.DarkGray);
            this.Apply();
            Thread.Sleep(this.TickDuration * 3);

            // Clear
            this.LedGroup.ForEach(w => w.Color = Color.Black);

            // Apply
            this.Apply();
            Thread.Sleep(this.TickDuration);

            return true;
        }
    }
}
