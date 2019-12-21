using BeetleX;
using BeetleX.EventArgs;
using nano.Project;
using rpi_ws281x;
using System;
using System.Threading;

namespace nano
{
    class Program
    {
        private static WS281x rpi;
        private static App app;

        private static Settings settings;
        private static int LedCount = 33;

        private static bool isRunning = true;

        static void Main(string[] args)
        {
            Console.CancelKeyPress += new ConsoleCancelEventHandler(OnCancel);

            // LEDS
            settings = Settings.CreateDefaultSettings();
            settings?.AddController(
                ledCount: LedCount,
                pin: Pin.Gpio18,
                stripType: StripType.WS2812_STRIP,
                brightness: 255,
                invert: false);

            rpi = new WS281x(settings);
            app = new App(rpi, LedCount, args);
            app.Start();

            while (app.Update())
            {
            }

            Close();
        }

        private static void OnCancel(object sender, ConsoleCancelEventArgs e)
        {
            Close();
        }

        private static void Close()
        {
            isRunning = false;
            app.End();
            rpi.Dispose();
            Environment.Exit(-1);
        }
    }
}
