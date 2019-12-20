using nano.Project;
using System;
using System.Threading;

namespace nano
{
    class Program
    {
        private static App app;

        static void Main(string[] args)
        {
            app = new App();
            app.Launch();
            app.Dispose();
        }
    }
}
