namespace ConsoleLauncher.Helpers
{
    using System;

    internal class ConsoleHelper
    {
        public static void WriteItem(string msg, (ConsoleColor Background, ConsoleColor Foreground) itemColors)
        {
            SetColors(itemColors);
            Console.WriteLine("  " + msg);
            Console.ResetColor(); // TODO: replace with custom reset?
        }

        internal static void WriteHighlitedItem(string msg, (ConsoleColor Background, ConsoleColor Foreground) itemColors, char pointer = '>')
        {
            SetColors(itemColors);
            Console.WriteLine(pointer + " " + msg);
            Console.ResetColor(); // TODO: replace with custom reset?
        }

        internal static void SetColors((ConsoleColor Background, ConsoleColor Foreground) colors)
        {
            Console.BackgroundColor = colors.Background;
            Console.ForegroundColor = colors.Foreground;
        }
    }
}
