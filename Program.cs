using rpi_ws281x;
using System;
using System.Drawing;
using System.Threading;

namespace nano
{
    class Program
    {
        private const int LedCount = 3;
        private const int LoopCount = 255;

        static void Main(string[] args)
        {
            Console.WriteLine("-- Init -- ");

            var settings = Settings.CreateDefaultSettings();
            settings.AddController(ledCount: 3, pin: Pin.Gpio18, stripType: StripType.WS2812_STRIP, brightness: 255, invert: false);

            Console.WriteLine("-- Run -- ");

            using (var rpi = new WS281x(settings))
            {
                int[] rgb = new int[3] { 255, 255, 255 };

                for (int i = 0; i < LoopCount; i++)
                {
                    Loop(rpi, rgb);

                    rgb[0] = rgb[0] - 1;
                    rgb[1] = rgb[1] - 1;
                    rgb[2] = rgb[2] - 1;
                }

                Console.WriteLine("-- End -- ");
                Clear(rpi);
            }
        }

        private static void Loop(WS281x rpi, int[] rgb)
        {
            for (int i = 0; i < LedCount; i++)
            {
                rpi.GetController().SetLED(i, Color.FromArgb(rgb[0], rgb[1], rgb[2]));
            }

            rpi.Render();

            Thread.Sleep(16);
        }

        private static void Clear(WS281x rpi)
        {
            for (int i = 0; i < LedCount; i++)
            {
                rpi.GetController().SetLED(i, Color.Black);
            }

            rpi.Render();
        }
    }
}
