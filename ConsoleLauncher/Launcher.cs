namespace ConsoleLauncher
{
    using ConsoleLauncher.Layout;

    /// <summary>
    /// ConsoleLauncher tool.
    /// </summary>
    public class Launcher
    {
        /// <summary>
        /// Initializes user-friendly, console menu that
        /// allow user to use arrows to navigate thru menu options.
        /// </summary>
        /// <param name="options">List of options to show in menu.</param>
        public static void Menu(List<Option> options)
        {
            Settings.GetDefaults();

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
                PrintHeader();
            }

            PrintBody(options, pointer);

            if (Footer.IsVisible)
            {
                PrintFooter();
            }
        }

        private static void PrintBody(List<Option> options, int pointer)
        {
            for (int i = 0; i < options.Count; i++)
            {
                if (pointer == i)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.WriteLine($"> " + options[i].Name);

                    Console.ResetColor();
                    continue;
                }

                Console.WriteLine($"  " + options[i].Name);
            }
        }

        private static void PrintHeader()
        {
            Header.WriteTitle();

            if (Header.ClockVisible)
            {
                var formattedTime = DateTime.Now.ToString(Header.TimeFormat);
                Console.SetCursorPosition(Console.WindowWidth - formattedTime.Length, Console.CursorTop);
                Console.Write(formattedTime);
            }

            Console.WriteLine();
        }

        private static void PrintFooter()
        {
            if (Footer.Left.Length > 0)
            {
                Console.SetCursorPosition(Console.CursorLeft, Console.WindowTop + Console.WindowHeight - 1);
                Console.Write(Footer.Left);
            }

            if (Footer.Right.Length > 0)
            {
                Console.SetCursorPosition(Console.WindowWidth - Footer.Right.Length, Console.WindowTop + Console.WindowHeight - 1);
                Console.Write(Footer.Right);
            }
        }
    }
}
