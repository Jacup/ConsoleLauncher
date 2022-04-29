﻿namespace ConsoleLauncher
{
    using ConsoleLauncher.Layout;

    /// <summary>
    /// ConsoleLauncher Menu feature.
    /// </summary>
    public static class Menu
    {
        /// <summary>
        /// Gets or sets colors of highlited menu entry.
        /// </summary>
        public static (ConsoleColor Background, ConsoleColor Foreground) HighlitedEntryColors { get; set; } =
    (Console.ForegroundColor, Console.BackgroundColor);

        /// <summary>
        /// Run Menu initializer.
        /// </summary>
        /// <param name="options">List of options to make menu.</param>
        internal static void Run(List<Option> options)
        {
            if (options.Count < 1)
            {
                throw new NotImplementedException("Option list contains no elements!");
            }

            ConsoleKeyInfo keyAction;
            int pointer = 0;

            do
            {
                GenerateView(options, pointer);

                keyAction = Console.ReadKey(true);
                pointer = MakeAction(options, keyAction, pointer);
            }
            while (keyAction.Key != ConsoleKey.Escape);
        }

        private static int MakeAction(List<Option> options, ConsoleKeyInfo keyAction, int pointer)
        {
            switch (keyAction.Key)
            {
                case ConsoleKey.Enter:
                    if (options[pointer].Action != null)
                    {
                        options[pointer].Action.Invoke();
                    }

                    break;
                case ConsoleKey.PageUp:
                case ConsoleKey.UpArrow:
                    if (pointer > 0)
                    {
                        pointer--;
                    }

                    break;
                case ConsoleKey.PageDown:
                case ConsoleKey.DownArrow:
                    if (pointer < options.Count - 1)
                    {
                        pointer++;
                    }

                    break;
            }

            return pointer;
        }

        /// <summary>
        /// Generate view of provied options with one highlited entry..
        /// </summary>
        /// <param name="options">List of entries to print in menu.</param>
        /// <param name="pointer">Highlighted entry pointer.</param>
        private static void GenerateView(List<Option> options, int pointer)
        {
            Console.Clear();
            Console.CursorVisible = false;

            if (Header.IsVisible)
            {
                Header.PrintHeader();
            }

            PrintBody(options, pointer);

            if (Footer.IsVisible)
            {
                Footer.PrintFooter();
            }
        }

        private static void PrintBody(List<Option> options, int pointer)
        {
            for (int i = 0; i < options.Count; i++)
            {
                if (pointer == i)
                {
                    SetHighlitedColors();
                    Console.WriteLine($"> " + options[i].Name);

                    Console.ResetColor();
                    continue;
                }

                Console.WriteLine($"  " + options[i].Name);
            }
        }

        private static void SetHighlitedColors()
        {
            Console.BackgroundColor = HighlitedEntryColors.Background;
            Console.ForegroundColor = HighlitedEntryColors.Foreground;
        }
    }
}
