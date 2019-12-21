using System;
using System.Linq;
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

            foreach (var item in args)
            {
                Console.WriteLine("item:" + item);
            }
        }

        public void Start()
        {
            Console.WriteLine("-- Init");

            if (this.args?.Length > 0)
            {
                if (this.args[0].Equals("starwars"))
                {
                    this.animation = new JediAnimation();
                }
                else if (this.args[0].Equals("off"))
                {
                    this.animation = new OffAnimation();
                }
                else
                {
                    this.animation = new RainbowAnimation();
                }
            }
            else
            {
                this.animation = new RainbowAnimation();
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
