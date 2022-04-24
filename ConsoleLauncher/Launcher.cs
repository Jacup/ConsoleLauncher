namespace ConsoleLauncher
{
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
            ConsoleKeyInfo keyAction;
            int pointer = 0;

            if (options.Count < 1)
            {
                throw new NotImplementedException("Option list contains no elements!");
            }

            do
            {
                GenerateView(options, pointer);

                keyAction = GetAction();

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
            }
            while (keyAction.Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// Generate view of provied options with one highlited entry..
        /// </summary>
        /// <param name="options">List of entries to print in menu.</param>
        /// <param name="pointer">Highlighted entry pointer.</param>
        private static void GenerateView(List<Option> options, int pointer)
        {
            Console.Clear();

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

        private static ConsoleKeyInfo GetAction()
        {
            return Console.ReadKey();
        }
    }
}
