namespace ConsoleLauncher
{
    /// <summary>
    /// ConsoleLauncher tool.
    /// </summary>
    public class Launch
    {
        /// <summary>
        /// Initializes user-friendly, console menu that
        /// allow user to use arrows to navigate thru menu options.
        /// </summary>
        /// <param name="options">List of options to show in menu.</param>
        /// <returns>Position of selected option as integer. </returns>
        public static int Menu(List<string> options)
        {
            var pointer = 0;
            var isSelected = false;
            if (options.Count < 1)
            {
                throw new NotImplementedException("Options list contains no elements!");
            }

            while (!isSelected)
            {
                GenerateView(options, pointer);

                var action = GetAction();

                switch (action.Key)
                {
                    case ConsoleKey.Enter:
                        isSelected = true;
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

            return pointer;
        }

        /// <summary>
        /// Generate view of provied options options with one highlited entry..
        /// </summary>
        /// <param name="options">List of entries to print in menu.</param>
        /// <param name="pointer">Highlighted entry pointer.</param>
        private static void GenerateView(List<string> options, int pointer)
        {
            Console.Clear();

            for (int i = 0; i < options.Count; i++)
            {
                if (pointer == i)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.WriteLine($" > " + options[i]);

                    Console.ResetColor();
                    continue;
                }

                Console.WriteLine($"   " + options[i]);
            }
        }

        private static ConsoleKeyInfo GetAction()
        {
            Console.WriteLine("\nUse arrows to navigate. Enter to select and option.");
            return Console.ReadKey();
        }
    }
}
