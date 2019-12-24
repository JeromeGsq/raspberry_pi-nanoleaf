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
        private string[] args;

        private IAnimation animation;

        public App(WS281x rpi, int ledCount, string[] args)
        {
            this.rpi = rpi;
            this.ledCount = ledCount;
            this.args = args;
        }

        public void Start()
        {
            Console.WriteLine("-- Init");

            switch (this.args[0])
            {
                case "starwars":
                    this.animation = new JediAnimation();
                    break;
                case "off":
                    this.animation = new OffAnimation();
                    break;
                default:
                    this.animation = new RainbowAnimation();
                    break;
            }

            this.animation?.Init(rpi, this.ledCount);
            this.animation?.Start();
        }

        public bool Update()
        {
            return this.animation?.Update() ?? false;
        }

        public void End()
        {
            Console.WriteLine("-- End");
            this.animation?.End();
        }
    }
}
