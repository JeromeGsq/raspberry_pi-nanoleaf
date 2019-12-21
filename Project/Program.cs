using nano.Project;
using rpi_ws281x;
using System;
using System.Threading;

namespace nano
{
    class Program
    {
        private static App app;
        private static Settings settings;
        private static int LedCount = 33;

        private static bool isRunning = true;
        private static WS281x rpi;

        static void Main(string[] args)
        {
            Console.CancelKeyPress += new ConsoleCancelEventHandler(OnCancel);

            settings = Settings.CreateDefaultSettings();
            settings?.AddController(
                ledCount: LedCount,
                pin: Pin.Gpio18,
                stripType: StripType.WS2812_STRIP,
                brightness: 255,
                invert: false);

            rpi = new WS281x(settings);
            app = new App(rpi, LedCount);
            app.Start();

            while (isRunning)
            {
                app.Update();
            }
        }

        private static void OnCancel(object sender, ConsoleCancelEventArgs e)
        {
            isRunning = false;
            app.End();
            rpi.Dispose();
        }
    }
}
