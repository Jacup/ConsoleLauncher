using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLauncher.Layout
{
    public static class Settings
    {
        public static ConsoleColor DefaultBackgroundColor = Console.BackgroundColor;
        public static ConsoleColor DefaultForegroundColor = Console.ForegroundColor;

        public static void GetDefaults()
        {
            DefaultBackgroundColor = Console.BackgroundColor;
            DefaultForegroundColor = Console.ForegroundColor;
        }
    }
}
