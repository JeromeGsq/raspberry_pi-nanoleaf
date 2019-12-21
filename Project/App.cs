using System;
using nano.Project.Animations;
using nano.Project.Interfaces;
using rpi_ws281x;

namespace nano.Project
{
    public class App
    {
        private WS281x rpi;
        private int ledCount;

        private IAnimation animation;

        public App(WS281x rpi, int ledCount)
        {
            this.rpi = rpi;
            this.ledCount = ledCount;
        }

        public void Start()
        {
            Console.WriteLine("-- Init");
            this.animation = new RainbowAnimation();

            this.animation?.Init(rpi, this.ledCount);
            this.animation?.Start();
        }

        public void Update()
        {
            this.animation?.Update();
        }

        public void End()
        {
            Console.WriteLine("-- End");
            this.animation?.End();
        }
    }
}
