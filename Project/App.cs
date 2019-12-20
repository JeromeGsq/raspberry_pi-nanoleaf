using System;
using nano.Project.Animations;
using nano.Project.Interfaces;
using rpi_ws281x;

namespace nano.Project
{
    public class App
    {
        private const int LedCount = 3;

        private Settings settings;
        private IAnimation animation;

        public App() => this.Init();

        private void Init()
        {
            Console.WriteLine("-- Init nano");

            this.settings = Settings.CreateDefaultSettings();
            this.settings?.AddController(
                ledCount: LedCount,
                pin: Pin.Gpio18,
                stripType: StripType.WS2812_STRIP,
                brightness: 255,
                invert: false);
        }

        public void Launch()
        {
            Console.WriteLine("-- Launch");

            this.animation = new RainbowAnimation();

            using (var rpi = new WS281x(settings))
            {
                Console.WriteLine("-- Run");

                this.animation?.Init(rpi, LedCount);
                this.animation?.Start();
            }

            Console.WriteLine("-- End");
        }

        public void Dispose()
        {
            Console.WriteLine("-- Dispose");
        }
    }
}
