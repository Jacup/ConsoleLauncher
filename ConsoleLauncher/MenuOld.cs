namespace ConsoleLauncher
{
    using ConsoleLauncher.Interfaces;
    using ConsoleLauncher.Layout;

    /// <summary>
    /// ConsoleLauncher Menu feature.
    /// </summary>
    public static class MenuOld
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
        internal static void Run(IEnumerable<IMenuItem> options)
        {
            if (options.Count < 1)
            {
                throw new NotImplementedException("Option list contains no elements!");
            }

            Console.CursorVisible = false;
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

        private static int MakeAction(List<MenuItem> options, ConsoleKeyInfo keyAction, int pointer)
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

        private static void GenerateView(List<MenuItem> options, int pointer)
        {
            Console.Clear();

            Header.PrintHeader();
            PrintBody(options, pointer);

            if (Footer.IsVisible)
            {
                Footer.PrintFooter();
            }
        }

        private static void PrintBody(List<MenuItem> options, int pointer)
        {
            for (int i = 0; i < options.Count; i++)
            {
                if (pointer == i)
                {
                    Settings.SetColors(HighlitedEntryColors);

                    Console.WriteLine($"> " + options[i].Description);

                    Console.ResetColor();
                    continue;
                }

                Console.WriteLine($"  " + options[i].Description);
            }
        }
    }
}
