using nano.Project;
using rpi_ws281x;
using System;

namespace nano
{
    class Program
    {
        private static WS281x rpi;
        private static App app;

        private static Settings settings;
        private static int LedCount = 33;

        static void Main(string[] args)
        {
            Console.CancelKeyPress += OnCancel;

            settings = Settings.CreateDefaultSettings();
            settings?.AddController(
                LedCount,
                Pin.Gpio18,
                StripType.WS2812_STRIP,
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
            app.End();
            rpi.Dispose();
            Environment.Exit(-1);
        }
    }
}
